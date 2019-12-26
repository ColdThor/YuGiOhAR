using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public string enemy_special_attack = "";
    public string player_special_attack = "";

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
  
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(setupBattle());
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

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
       bool isDead = enemyUnit.takeDamage(playerUnit.damage);

        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = player_special_attack +" attack!";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        } 
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

        yield return new WaitForSeconds(2f);
    }
     
    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "Duel won!";
        } else if(state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated";
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyUnit.unitName + " uses " + enemy_special_attack +"!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.takeDamage(enemyUnit.damage);

        playerHUD.setHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
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
        playerUnit.Defend(6000);
        playerHUD.setHP(playerUnit.currentHP);

        dialogueText.text = playerUnit.unitName + " defense mode!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

  
}
