using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
		
	public Transform mouse;
	public Rigidbody rbodyCat;
	public AudioSource boss1;	
	public AudioSource eating;

	
	void FixedUpdate () {
		
		Vector3 directionToMouse = mouse.transform.position - transform.position;
		float angle = Vector3.Angle (directionToMouse, transform.forward);  
		
		if (angle < 90f) {
			Ray catRay = new Ray (transform.position, directionToMouse);
			RaycastHit catRayHitInfo = new RaycastHit ();
			
			if (Physics.Raycast (catRay, out catRayHitInfo, 30f)) {
				Debug.DrawRay (catRay.origin, catRay.direction);

				if (catRayHitInfo.collider.tag == "Mouse") {
					if (catRayHitInfo.distance < 3f) {
						Destroy (mouse.gameObject);
						eating.Play();
					} else {
						rbodyCat.AddForce (directionToMouse.normalized * 1000f);
						boss1.Play();
					}
				}
			}
		}
	}	
}
