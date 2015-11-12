using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

	//public Transform cat;
	public Rigidbody rbodyMouse;
	public AudioSource sound1;
	
	void FixedUpdate () {

		foreach (GameObject catObject in GameManager.allTheCats) {

			Transform catTransform = catObject.transform;
			Vector3 directionToCat = catTransform.transform.position - transform.position;
			float angle = Vector3.Angle (directionToCat, transform.forward);  

			if (angle < 180f) {
				Ray mouseRay = new Ray (transform.position, directionToCat);
				RaycastHit mouseRayHitInfo = new RaycastHit ();

				if (Physics.Raycast (mouseRay, out mouseRayHitInfo, 30f)) {
					Debug.DrawRay (mouseRay.origin, mouseRay.direction);

					if (mouseRayHitInfo.collider.tag == "Cat") {
						rbodyMouse.AddForce (-directionToCat.normalized * 1000f);
						sound1.Play();
					}
				}
			}
		}
	}	
}