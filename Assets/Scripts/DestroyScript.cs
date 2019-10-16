using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {

    float distanceToDestroy = 30;
	
	void Update () {
        if (transform.position.z + distanceToDestroy < PlayerController._transform.position.z)
            Destroy(gameObject);
	}
}
