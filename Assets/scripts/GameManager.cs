﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject catPrefab;
	public GameObject mousePrefab;
	public static List<GameObject> allTheCats = new List<GameObject>();
	public static List<GameObject> allTheMice = new List<GameObject>();

	void Start () {
		allTheCats.Clear ();
		allTheMice.Clear ();
	}
	
	void Update () {
	
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit mouseRayHit = new RaycastHit();
		if (Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast (mouseRay, out mouseRayHit, 1000f)) {
				GameObject newCat = (GameObject) Instantiate (catPrefab, mouseRayHit.point + new Vector3 (0f, 1f, 0f), Quaternion.identity);
				allTheCats.Add (newCat); 
			}
		}
		if (Input.GetMouseButtonDown(1)) {
			if (Physics.Raycast (mouseRay, out mouseRayHit, 1000f)) {
				GameObject newMouse = (GameObject) Instantiate (mousePrefab, mouseRayHit.point + new Vector3 (0f, 1f, 0f), Quaternion.identity);
				allTheMice.Add (newMouse);
			}
		}
	}
}
