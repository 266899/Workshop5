using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float speed = 10f;

	[HideInInspector]
	public bool clockwise = true;
	[HideInInspector]
	public float direction = 1f;
	[HideInInspector]
	public float directionChangeSpeed = 2f;

	// Update is called once per frame
	void Update() {

        transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
			
    }
    //if (spin) {
    //    if (clockwise) {
    //        if (spinParent)
    //            transform.parent.transform.Rotate(Vector3.up, (speed* direction) * Time.deltaTime);
    //        else
    //            transform.Rotate(Vector3.up, (speed* direction) * Time.deltaTime);
    //    } else {
    //        if (spinParent)
    //            transform.parent.transform.Rotate(-Vector3.up, (speed* direction) * Time.deltaTime);
    //        else
    //            transform.Rotate(-Vector3.up, (speed* direction) * Time.deltaTime);
    //    }
    //}
}


