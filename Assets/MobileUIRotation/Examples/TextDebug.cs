using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDebug : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		this.GetComponent<UnityEngine.UI.Text>().text = Input.deviceOrientation.ToString();
	}

}
