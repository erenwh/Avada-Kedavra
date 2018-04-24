using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PadConfig : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public GameObject wand;
	public bool isLeft;

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate() {
		device = SteamVR_Controller.Input((int)trackedObj.index);
	}
	
	// Update is called once per frame
	void Update () {
		if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
		{
			Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));

			if (touchpad.y > 0.7f)
			{
				// pressing up
				if (isLeft == false) {
					wand.GetComponent<GunController>().damage += 10;
				}
				
			}

			else if (touchpad.y < -0.7f)
			{
				// pressing down
			}

			if (touchpad.x > 0.7f)
			{
				// pressing right

			}

			else if (touchpad.x < -0.7f)
			{
				// pressing left

			}
		}
	}
}
