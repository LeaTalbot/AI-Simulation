using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour {
		
	public Transform mouse;
	public Rigidbody rbodyCat;
	
	void FixedUpdate () {
		
		Vector3 directionToMouse = mouse.transform.position - transform.position;
		float angle = Vector3.Angle (directionToMouse, transform.forward);  
		
		if (angle < 90f) {
			Ray catRay = new Ray (transform.position, directionToMouse);
			RaycastHit catRayHitInfo = new RaycastHit ();
			
			if (Physics.Raycast (catRay, out catRayHitInfo, 50f)) {
				Debug.DrawRay (catRay.origin, catRay.direction);

				if (catRayHitInfo.collider.tag == "Mouse") {
					if (catRayHitInfo.distance < 1f) {
						Destroy (mouse.gameObject);
					} else {
						rbodyCat.AddForce (directionToMouse.normalized * 1000f);
					}
				}
			}
		}
	}	
}
