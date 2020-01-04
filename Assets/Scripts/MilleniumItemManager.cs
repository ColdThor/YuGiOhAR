using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Proyecto26;

public class MilleniumItemManager : MonoBehaviour {
	private TileManager tileManager;
	public static int itemindex;

	[SerializeField]
	private int count;

	private List<MilleniumPuzzle> items = new List<MilleniumPuzzle>();
	
	void Start () {
		tileManager = GameObject.FindGameObjectWithTag ("TileManager").GetComponent<TileManager> ();
		SpawnItems();
	}

	void Update () {
	
			
		

		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

			if (Physics.Raycast (ray, out hit, 100f)) {
				if (hit.transform.tag.Substring(0,2) == "MI") {

				 itemindex = Int32.Parse(hit.transform.tag.Substring(2));
					
				
					Player player = new Player();
					RestClient.Get<Player>("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json").Then(response =>
					{

						player = response;
						googleSignIn.locationdata[itemindex] = true;
						switch (itemindex)
						{
							case 0: player.mlyny = true;  break;
							case 1: player.ukf= true; break;
							case 2: player.marian = true; break;
							case 3: player.kniznica = true; break;
							case 4: player.amfiteater = true; break;
							case 5: player.pyramida = true; break;
							case 6: player.agro = true; break;
							case 7: player.kalvaria = true; break;
							case 8: player.hala = true; break;
							case 9: player.tesco = true; break;
							case 10: player.hidepark = true; break;
							case 11: player.zaba = true; break;
							case 12: player.kostol = true; break;
							case 13: player.hotel = true; break;
							case 14: player.mostna = true; break;
							case 15: player.fontana = true; break;
							case 16: player.hrad = true; break;
							case 17: player.corgon = true; break;
							case 18: player.lavicka = true; break;
							case 19: player.epicure = true; break;
							case 20: player.spu = true; break;
						}

						RestClient.Put("https://yu-gi-oh-ar.firebaseio.com/" + googleSignIn.userid + ".json", player);
					});
					MilleniumPuzzle item = hit.transform.GetComponent<MilleniumPuzzle> ();
                    FlipCard(item.milleniumType);
				}
			}
		}
	}

	void FlipCard(MilleniumItemType type) {
		string t = type.ToString ();
		SceneManager.LoadScene (2);
	}

	void SpawnItems() {

		itemindex = 100;

		for(int i = 0; i < count; i++)
		{
			if (googleSignIn.locationdata[i] == false)
			{
			MilleniumItemType type = (MilleniumItemType)(int)UnityEngine.Random.Range(0, Enum.GetValues(typeof(MilleniumItemType)).Length);
			float newLat = 0; 
			float newLon = 0;

			MilleniumPuzzle prefab = Resources.Load("MilleniumItems/puzzle", typeof(MilleniumPuzzle)) as MilleniumPuzzle;
			MilleniumPuzzle millenium_item = Instantiate(prefab, Vector3.zero, Quaternion.Euler(-100, 0, 0)) as MilleniumPuzzle;
			millenium_item.tileManager = tileManager;

				switch (i)
				{
					case 0: newLat = 48.307905f; newLon = 18.086105f; millenium_item.tag = "MI0"; break;
					case 1: newLat = 48.307915f; newLon = 18.090796f; millenium_item.tag = "MI1"; break;
					case 2: newLat = 48.317748f; newLon = 18.087894f; millenium_item.tag = "MI2"; break;

					case 3: newLat = 48.322711f; newLon = 18.093299f; millenium_item.tag = "MI3"; break;
					case 4: newLat = 48.323635f; newLon = 18.095375f; millenium_item.tag = "MI4"; break;
					case 5: newLat = 48.343268f; newLon = 18.105408f; millenium_item.tag = "MI5"; break;

					case 6: newLat = 48.308567f; newLon = 18.102795f; millenium_item.tag = "MI6"; break;
					case 7: newLat = 48.296811f; newLon = 18.08975f;  millenium_item.tag = "MI7"; break;
					case 8: newLat = 48.296903f; newLon = 18.06753f;  millenium_item.tag = "MI8"; break;

					case 9: newLat = 48.310528f; newLon = 18.068646f;  millenium_item.tag = "MI9"; break;
					case 10: newLat = 48.314702f; newLon = 18.068593f; millenium_item.tag = "MI10"; break;
					case 11: newLat = 48.32148f; newLon = 18.085502f;  millenium_item.tag = "MI11"; break;

					case 12: newLat = 48.356736f; newLon = 18.055215f; millenium_item.tag = "MI12"; break;
					case 13: newLat = 48.306974f; newLon = 18.077813f; millenium_item.tag = "MI13"; break;
					case 14: newLat = 48.315392f; newLon = 18.090343f; millenium_item.tag = "MI14"; break;

					case 15: newLat = 48.313908f; newLon = 18.088234f; millenium_item.tag = "MI15"; break;
					case 16: newLat = 48.318210f; newLon = 18.086502f; millenium_item.tag = "MI16"; break;
					case 17: newLat = 48.316364f; newLon = 18.088675f; millenium_item.tag = "MI17"; break;

					case 18: newLat = 48.315754f; newLon = 18.095918f; millenium_item.tag = "MI18"; break;
					case 19: newLat = 48.308612f; newLon = 18.086423f; millenium_item.tag = "MI19"; break;
					case 20: newLat = 48.307421f; newLon = 18.092865f; millenium_item.tag = "MI20"; break;
				}


				millenium_item.Init(newLat, newLon);
			items.Add(millenium_item);
		}

		}
	}


    public void UpdateItemPosition() {
		if (items.Count == 0)
			return;

        MilleniumPuzzle[] item = items.ToArray ();
		for (int i = 0; i < item.Length; i++) {
            item[i].UpdatePosition ();
		}
	}
}
