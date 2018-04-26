using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZEffects;

public class GunController : MonoBehaviour {
	public GameObject ControllerRight;

	private SteamVR_TrackedObject trackObj;
	private SteamVR_Controller.Device device;

	private SteamVR_TrackedController controller;

    public float damage;
	public bool menuShown;
    public Camera cam;

    public GameObject heartPrefab;
    public Transform bulletSpawn;

	public GameObject cPrefab;
	public GameObject downPrefab;

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

    public void Fire(int num)
    {
		if (num == 1) {
	        var bullet = (GameObject)Instantiate(
		        downPrefab,
			    bulletSpawn.position,
				bulletSpawn.rotation);
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;
			Destroy(bullet, 2.0f);
		}
		else if (num == 2) {
	        var bullet = (GameObject)Instantiate(
		        cPrefab,
			    bulletSpawn.position,
				bulletSpawn.rotation);
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;
			Destroy(bullet, 2.0f);
		}
		else if (num == 10) {
	        var bullet = (GameObject)Instantiate(
				heartPrefab,
			    bulletSpawn.position,
				bulletSpawn.rotation);
			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 30;
			Destroy(bullet, 2.0f);
		}
    }

    public IEnumerator notime(int num)
    {
        
        int x = 0;
        while (x < num)
        {
            Fire(num);
            yield return new WaitForSeconds(.1f);
            x++;
        }
    }

    private void fireNow()
    {

        //Ray ray = new Ray(muzzleTransform.position, muzzleTransform.forward);
        device = SteamVR_Controller.Input((int)trackObj.index);
        device.TriggerHapticPulse(1500);
        //TracerEffect.ShowTracerEffect(muzzleTransform.position, muzzleTransform.forward, 250f);

        /*if (Physics.Raycast(muzzleTransform.transform.position, muzzleTransform.transform.forward, out hit, 5000f))
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
        }*/
    }
}
