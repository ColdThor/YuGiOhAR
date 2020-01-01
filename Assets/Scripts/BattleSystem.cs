using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum BattleState
{
    START, PLAYERTURN, ENEMYTURN, WON, LOST
}


public class BattleSystem : MonoBehaviour
{


    public BattleState state;

    public GameObject player;
    public GameObject enemy;

    Unit playerUnit;
    Unit enemyUnit;

    public Text specialattack;
    public Text dialogueText2;

    public string enemy_special_attack = "";
    public string player_special_attack = "";

    public Text dialogueText;

    public GameObject actionbar;
    public GameObject attackbar;


    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    public AudioSource battlemusic;
    public AudioSource enemy_attack;
    public AudioSource player_attack;
  
    void Start()
    {
        state = BattleState.START;
        attackbar.SetActive(false);
        actionbar.SetActive(true);
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        StartCoroutine(setupBattle());


        var music = PlayerPrefs.GetString("Music", "Default value");
        if (music.Equals("yes"))
        {
            Instantiate(battlemusic);
        }
       
    }



    IEnumerator setupBattle()
    {
       GameObject playerGO = Instantiate(player);
       playerUnit = playerGO.GetComponent<Unit>();

       GameObject enemyGO  = Instantiate(enemy);
       enemyUnit = enemyGO.GetComponent<Unit>();

       dialogueText.text = "" + enemyUnit.unitName + " Appears!";

        playerHUD.setHUD(playerUnit);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        playerTurn();
    }

    void playerTurn()
    {
        dialogueText.text = "Choose an action: ";
    }


    public void onAttack()
    {
        if(state != BattleState.PLAYERTURN)
            return;
        attackbar.SetActive(true);
        specialattack.text = "Special (" + playerUnit.special_mana_cost + " mana)";
        actionbar.SetActive(false);
        
    }


    public void onAttackChoice(bool choice)
    {
        
        if (choice && playerUnit.currentMana < playerUnit.special_mana_cost)
        {
            dialogueText2.text = "You dont have enough mana!";
        } 
        else
        StartCoroutine(PlayerAttack(choice));
    }


    public void onBack()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        dialogueText2.text = "Choose your attack...";
        attackbar.SetActive(false);
        actionbar.SetActive(true);
    }


    IEnumerator PlayerAttack(bool special)
    {
        var mydamage = playerUnit.damage;

        if (special)
        {
            mydamage *= 2;
            playerUnit.useMana(playerUnit.special_mana_cost);
            playerHUD.setMana(playerUnit.currentMana);
        }
   

        if(enemyUnit.isDefending)
        {
            mydamage = mydamage / 60;
            enemyUnit.isDefending = false;
        }

        Debug.Log("Damage given: " + mydamage);

       bool isDead = enemyUnit.takeDamage(mydamage);

        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = player_special_attack +" attack!";

        Handheld.Vibrate();

        player_attack.Play();

        attackbar.SetActive(false);
        actionbar.SetActive(true);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        } 
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        enemyUnit.isDefending = false;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "Duel won!";
            yield return new WaitForSeconds(1f);
            googleSignIn.story_progress++;
            Player player = new Player();
            RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
            {
                player.story_progress = googleSignIn.story_progress;
                RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
            });

            if (googleSignIn.story_progress == 7)
            {
                SceneManager.LoadScene(7);
            }
            else
            {
                SceneManager.LoadScene(5);
            }




        } else if(state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated!";
            dialogueText2.text = "You were defeated!";
            yield return new WaitForSeconds(1f);
            if (googleSignIn.story_progress == 7)
            {
                SceneManager.LoadScene(7);
            }
            else
            {
                SceneManager.LoadScene(5);
            }
        }
    }

    IEnumerator EnemyTurn()
    {

        int random = UnityEngine.Random.Range(0, 3);
        bool isDead = false;
        var mydamage = enemyUnit.damage;
        Debug.Log("Random is: " + random);

        if (random == 1 || random == 0)
        {
            if(random == 1)
            {
                mydamage *= 2;
                enemyUnit.useMana(enemyUnit.special_mana_cost);
                enemyHUD.setMana(enemyUnit.currentMana);
            }
            enemy_attack.Play();
            dialogueText.text = enemyUnit.unitName + " uses " + enemy_special_attack + "!";
            Handheld.Vibrate();

            if (playerUnit.isDefending)
            {
                playerUnit.isDefending = false;
                mydamage = mydamage / 60;   
            }

            

            isDead = playerUnit.takeDamage(mydamage);
            playerHUD.setHP(playerUnit.currentHP);
            playerUnit.isDefending = false;


        }

        if(random == 2)
        {
            enemyUnit.Defend();
            enemyUnit.currentMana += 30;
            if(enemyUnit.currentMana>100)
            {
                enemyUnit.currentMana = 100;
            }
            enemyHUD.setMana(enemyUnit.currentMana);
            dialogueText.text = enemyUnit.unitName + " defense mode!";
        }






        yield return new WaitForSeconds(1f);


        if (isDead)
        {
            state = BattleState.LOST;
            Debug.Log("Player is dead");
            StartCoroutine(EndBattle());
        } else
        {
            state = BattleState.PLAYERTURN;
            playerTurn();
        }

    


    }


    public void onDefend()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerDefend());
    }

    IEnumerator PlayerDefend()
    {
        playerUnit.Defend();
        playerUnit.currentMana += 30;
        if(playerUnit.currentMana>100)
        {
            playerUnit.currentMana = 100;
        }
        playerHUD.setMana(playerUnit.currentMana);
        dialogueText.text = playerUnit.unitName + " defense mode!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

  
}
