using UnityEngine;
using System.Collections;

public class Floater : MonoBehaviour {
	public float waterLevel, floatHeight;
	public Vector3 buoyancyCentreOffset;
	public float bounceDamp;
	

	void FixedUpdate () {

		if (!Input.GetKey(KeyCode.Space)) {
		 

			Vector3 actionPoint = transform.position + transform.TransformDirection (buoyancyCentreOffset);
			float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
			Debug.Log (actionPoint.y - waterLevel);
			if (forceFactor > 0f) {
				Vector3 uplift = -Physics.gravity * (forceFactor - GetComponent<Rigidbody> ().position.y * bounceDamp);
				GetComponent<Rigidbody> ().AddForceAtPosition (uplift, actionPoint);
			}
		}
	}


}
