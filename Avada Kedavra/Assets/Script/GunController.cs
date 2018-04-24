using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZEffects;

public class GunController : MonoBehaviour {
	public GameObject ControllerRight;

	private SteamVR_TrackedObject trackObj;
	private SteamVR_Controller.Device device;

	private SteamVR_TrackedController controller;

	public EffectTracer TracerEffect;
	public Transform muzzleTransform;

    public float damage;
	public bool menuShown;
    public Camera cam;

	// Use this for initialization
	void Start () {
		menuShown = false;
		controller = ControllerRight.GetComponent<SteamVR_TrackedController>();
		controller.TriggerClicked += TriggerPressed;
		controller.Gripped += GripHeld;
		trackObj = ControllerRight.GetComponent<SteamVR_TrackedObject>();
	}

	private void TriggerPressed(object sender, ClickedEventArgs e) {
        fireNow();
	}

	private void GripHeld(object sender, ClickedEventArgs e) {
		OpenMenu();
	}

	private void OpenMenu() {
		menuShown = true;
	}

    private void fireNow()
    {
        RaycastHit hit;

        Ray ray = new Ray(muzzleTransform.position, muzzleTransform.forward);
        device = SteamVR_Controller.Input((int)trackObj.index);
        device.TriggerHapticPulse(1500);
        TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, 250f);

        if (Physics.Raycast(muzzleTransform.transform.position, muzzleTransform.transform.forward, out hit, 5000f))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                if (target.health <= 0)
                {
                    target.dead = true;
                }
            }
        }
    }

	/*public void ShootWeapon() {
		RaycastHit hit = new RaycastHit();
		Ray ray = new Ray(muzzleTransform.position, muzzleTransform.forward);
        Debug.Log(hit.transform.name);

		device = SteamVR_Controller.Input((int)trackObj.index);
		device.TriggerHapticPulse(1500);
		TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, 250f);
		if (Physics.Raycast(ray, out hit, 5000f)) {
            Debug.Log(hit.transform.name);
            if (hit.collider.attachedRigidbody) {
				Debug.Log("hit" + hit.collider.gameObject.name);
			}
		}
	}*/
	
}
