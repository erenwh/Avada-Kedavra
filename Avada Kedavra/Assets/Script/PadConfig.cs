using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PadConfig : MonoBehaviour {

	SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public GameObject wand;
	public GameObject scoreManager;
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
	
	IEnumerator DamageCoroutine() {
		//yield return new WaitForSeconds(.5f);
		if (isLeft == false) {
			while (scoreManager.GetComponent<Score>().score > 0) {
				scoreManager.GetComponent<Score>().score -= 1;
				wand.GetComponent<GunController>().damage += 1;
				break;
			}
		}
		yield return new WaitForSeconds(.5f);
	}

	// Update is called once per frame
	void Update () {
		if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
		{
			Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));

			if (touchpad.y > 0.7f)
			{
				StartCoroutine(DamageCoroutine());
				
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
