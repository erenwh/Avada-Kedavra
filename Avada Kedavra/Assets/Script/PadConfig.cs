﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PadConfig : MonoBehaviour {
    public GameObject Menu;
	public GameObject RMenu;
    private SteamVR_TrackedController controller;
    public GameObject ControllerLeft;
    SteamVR_TrackedObject trackedObj;
	SteamVR_Controller.Device device;
	public GameObject wand;
	public GameObject scoreManager;
    public GameObject PlayerHealth;
    public bool isLeft;
    private bool menuTrack;
	private bool rmenuTrack;

	void Awake() {
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	// Use this for initialization
	void Start () {
        menuTrack = false;
		rmenuTrack = false;
        Menu.SetActive(false);
		RMenu.SetActive(false);
        controller = ControllerLeft.GetComponent<SteamVR_TrackedController>();
        controller.MenuButtonClicked += MBC;
    }

	void FixedUpdate() {
		device = SteamVR_Controller.Input((int)trackedObj.index);
	}

    private void MBC(object sender, ClickedEventArgs e)
    {
        MenuUp();
    }

    private void MenuUp()
    {
		if (isLeft == true) {
			if (menuTrack == false)
			{
				Menu.SetActive(true);
				menuTrack = true;
			}
			else if (menuTrack == true)
			{
				Menu.SetActive(false);
				menuTrack = false;
			}
		}
		else {
			if (rmenuTrack == false)
			{
				RMenu.SetActive(true);
				rmenuTrack = true;
			}
			else if (rmenuTrack == true)
			{
				RMenu.SetActive(false);
				rmenuTrack = false;
			}
		}
    }

    IEnumerator DamageCoroutine() {
		//yield return new WaitForSeconds(.5f);
		if (isLeft == false) {
			while (scoreManager.GetComponent<Score>().score > 0) {
                if (scoreManager.GetComponent<Score>().scoreLock == false) break;
				scoreManager.GetComponent<Score>().score -= 1;
				wand.GetComponent<GunController>().damage += 1;
				break;
			}
		}
		yield return new WaitForSeconds(.5f);
	}

    IEnumerator HealthCoroutine()
    {
        //yield return new WaitForSeconds(.5f);
        if (isLeft == false)
        {
            while (scoreManager.GetComponent<Score>().score > 0)
            {
                if (scoreManager.GetComponent<Score>().scoreLock == false) break;
                scoreManager.GetComponent<Score>().score -= 1;
                PlayerHealth.GetComponent<Target>().health += 1;
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
				StartCoroutine(DamageCoroutine());
			}

			if (touchpad.x > 0.7f)
			{
                StartCoroutine(DamageCoroutine());

            }

			else if (touchpad.x < -0.7f)
			{
				// pressing left
				StartCoroutine(DamageCoroutine());

			}
		}
	}
}
