using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour {
	
	public GameObject MatrixCube;
	/*private SteamVR_Controller.Device device;
	private SteamVR_TrackedObject TrackedObject;
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private bool triggerButtonDown = false;
	*/
	public SteamVR_TrackedController device;
	public SteamVR_TrackedController device2;

	void Gripper(object sender, ClickedEventArgs e) {
		Instantiate(MatrixCube, new Vector3(0,0,0), Quaternion.identity);
		Debug.Log("something");
	}

	// Use this for initialization
	void Start () {
		//trackedObject = GetComponent<SteamVR_TrackedObject>();
		device = GetComponent<SteamVR_TrackedController>();
		device.Gripped += Gripper;
		device2 = GetComponent<SteamVR_TrackedController>();
		device2.Gripped += Gripper;
	}
	
	// Update is called once per frame
	void Update () {
		//device = SteamVR_Controller.Input((int)trackedObject.index);
		/*if (device.GetAxis().x != 0) {

		}*/
		/*triggerButtonDown = controller.GetPressDown(triggerButton);
		if (triggerButtonDown) {
			// Fire
		}
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.))
		gripButtonDown = controller.GetPressDown()
		if (Pre)*/
	}
}
