using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScr : MonoBehaviour {

    GvrControllerInput gvrControllerInputDevice;

    public Text txt;

    private void Awake()
    {
        gvrControllerInputDevice = GetComponent<GvrControllerInput>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = GvrControllerInput.Orientation.eulerAngles.ToString();
	}
}
