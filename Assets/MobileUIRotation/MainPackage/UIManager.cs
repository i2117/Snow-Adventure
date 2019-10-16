using UnityEngine;

public class UIManager : MonoBehaviour {
	public Animator animatorUI; //Canvas animator reference
	public float orientationCheckFreq = .5f; //How often are we checking to update orientation (performance)
	private DeviceOrientation savedDO = DeviceOrientation.Unknown; //Saved orientation reference for comparing if orientation changed
	private DeviceOrientation currentDO = DeviceOrientation.Unknown; //Current orientation to compare with saved orientation

	void Start(){
		savedDO = Input.deviceOrientation; //save initial orientation
		animatorUI.SetTrigger(savedDO.ToString());//update device orientation with initial savedDO
		InvokeRepeating("OrientationCheck", .001f, orientationCheckFreq); //Keep checking orientation with set frequency
	}

	void OrientationCheck(){
		currentDO = Input.deviceOrientation; //save current orientation
		if((currentDO != savedDO) && (currentDO != DeviceOrientation.FaceUp) && (currentDO != DeviceOrientation.FaceDown) && (currentDO != DeviceOrientation.Unknown)){//check if currentDO orientation is different from saved and is a valid mobile orientation
			animatorUI.SetTrigger(currentDO.ToString());//update device orientation with currentDO
			savedDO = currentDO;//replace savedDO with currentDO for next check
		}
	}
}
