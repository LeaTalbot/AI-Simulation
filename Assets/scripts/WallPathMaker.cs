using UnityEngine;
using System.Collections;

public class WallPathMaker : MonoBehaviour {
	
	int counter = 0;
	public Transform wallPrefab;
	public Transform pathmakerPrefab;
		

	void Update () {
		
		if (counter < 7) {
			
			float rand = Random.Range (0.0f, 1.0f);
			
			if (rand < 0.49f) { 
				transform.Rotate (0f, 90f, 0f);
			}
			else if (rand > 0.49f && rand < 0.98f) { 
					transform.Rotate (0f, 90f, 0f);
				}
			else if (rand > 0.98f) { 
				Instantiate (pathmakerPrefab, transform.position, transform.rotation);
			}
			
			Instantiate (wallPrefab, transform.position, transform.rotation);
			transform.Translate (0f, 0f, Random.Range (10f, 30f));
			counter++;
		}
		
		else {
			Destroy (this.gameObject); 
		}
	}
}