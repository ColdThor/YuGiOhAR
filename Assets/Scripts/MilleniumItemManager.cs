using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MilleniumItemManager : MonoBehaviour {
	private TileManager tileManager;
	[SerializeField]
	private float waitSpawnTime, minIntervalTime, maxIntervalTime;

	private List<MilleniumPuzzle> items = new List<MilleniumPuzzle>();
	
	void Start () {
		tileManager = GameObject.FindGameObjectWithTag ("TileManager").GetComponent<TileManager> ();
	}

	void Update () {
		if (waitSpawnTime < Time.time) {
			waitSpawnTime = Time.time + UnityEngine.Random.Range (minIntervalTime, maxIntervalTime);
			SpawnItem ();
		}

		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Stationary) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

			if (Physics.Raycast (ray, out hit, 100f)) {
				if (hit.transform.tag == "MilleniumItem") {
                    MilleniumPuzzle item = hit.transform.GetComponent<MilleniumPuzzle> ();
                    FlipCard(item.milleniumType);
				}
			}
		}
	}

	void FlipCard(MilleniumItemType type) {
		string t = type.ToString ();
		//PlayerPrefs.SetString ("POKEMON_KEY", t);
		SceneManager.LoadScene (5);
	}

	void SpawnItem() {
        MilleniumItemType type = (MilleniumItemType)(int)UnityEngine.Random.Range (0, Enum.GetValues (typeof(MilleniumItemType)).Length);
		float newLat = tileManager.getLat + UnityEngine.Random.Range (-0.0001f, 0.0001f);
		float newLon = tileManager.getLon + UnityEngine.Random.Range (-0.0001f, 0.0001f);

        MilleniumPuzzle prefab = Resources.Load ("MilleniumItems/puzzle", typeof(MilleniumPuzzle)) as MilleniumPuzzle;
        MilleniumPuzzle millenium_item = Instantiate (prefab, Vector3.zero, Quaternion.Euler(-100, 0, 0)) as MilleniumPuzzle;

     

        millenium_item.tileManager = tileManager;
        
        millenium_item.Init (newLat, newLon);




        items.Add (millenium_item);
	}


    void cardClicked()
    {
        SceneManager.LoadScene(5);
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
