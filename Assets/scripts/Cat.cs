using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
		
	//public GameObject mouse; 
	public Rigidbody rbodyCat;
	public AudioSource boss1;	
	public AudioSource eating;
	
	void FixedUpdate () {

//		foreach (GameObject, mouseObject in GameManager.allTheMice, GameManager.alltheMice) {
		for (int i=0; i<GameManager.allTheMice.Count; i++) {

			GameObject mouseTransform = GameManager.allTheMice[i];
			Vector3 directionToMouse = mouseTransform.transform.position - transform.position;
			float angle = Vector3.Angle (directionToMouse, transform.forward);  

			if (angle < 90f) {
				Ray catRay = new Ray (transform.position, directionToMouse);
				RaycastHit catRayHitInfo = new RaycastHit ();

				if (Physics.Raycast (catRay, out catRayHitInfo, 30f)) {
					Debug.DrawRay (catRay.origin, catRay.direction);

					if (catRayHitInfo.collider.tag == "Mouse") {

						if (catRayHitInfo.distance < 3f) {
							GameManager.allTheMice.Remove(mouseTransform);
							Destroy (mouseTransform);
							eating.Play();
						} 
						else {
							rbodyCat.AddForce (directionToMouse.normalized * 1000f);
							boss1.Play();
						}
					}
				}
			}
		}
	}
}
