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
					case 0: newLat = 48.30791f; newLon = 18.08611f; millenium_item.tag = "MI0"; break;
					case 1: newLat = 48.30792f; newLon = 18.09080f; millenium_item.tag = "MI1"; break;
					case 2: newLat = 48.31775f; newLon = 18.08789f; millenium_item.tag = "MI2"; break;

					case 3: newLat = 48.32232f; newLon = 18.09462f; millenium_item.tag = "MI3"; break;
					case 4: newLat = 48.32232f; newLon = 18.09538f; millenium_item.tag = "MI4"; break;
					case 5: newLat = 48.34327f; newLon = 18.10541f; millenium_item.tag = "MI5"; break;

					case 6: newLat = 48.30857f; newLon = 18.10280f; millenium_item.tag = "MI6"; break;
					case 7: newLat = 48.29681f; newLon = 18.08975f;  millenium_item.tag = "MI7"; break;
					case 8: newLat = 48.29690f; newLon = 18.06753f;  millenium_item.tag = "MI8"; break;

					case 9: newLat = 48.31053f; newLon = 18.06865f;  millenium_item.tag = "MI9"; break;
					case 10: newLat = 48.31470f; newLon = 18.06859f; millenium_item.tag = "MI10"; break;
					case 11: newLat = 48.3215f; newLon = 18.08550f;  millenium_item.tag = "MI11"; break;

					case 12: newLat = 48.35674f; newLon = 18.05522f; millenium_item.tag = "MI12"; break;
					case 13: newLat = 48.30697f; newLon = 18.07781f; millenium_item.tag = "MI13"; break;
					case 14: newLat = 48.31539f; newLon = 18.09034f; millenium_item.tag = "MI14"; break;

					case 15: newLat = 48.31391f; newLon = 18.08823f; millenium_item.tag = "MI15"; break;
					case 16: newLat = 48.31821f; newLon = 18.08650f; millenium_item.tag = "MI16"; break;
					case 17: newLat = 48.31636f; newLon = 18.08868f; millenium_item.tag = "MI17"; break;

					case 18: newLat = 48.31575f; newLon = 18.09592f; millenium_item.tag = "MI18"; break;
					case 19: newLat = 48.30861f; newLon = 18.08642f; millenium_item.tag = "MI19"; break;
					case 20: newLat = 48.30742f; newLon = 18.09286f; millenium_item.tag = "MI20"; break;
				}
				/// OUR LAT: 48.32232 OUR LON: 18.09462
		
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
