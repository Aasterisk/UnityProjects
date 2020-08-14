using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class MuscalShooting : MonoBehaviour {

    private CompleteProject.PlayerShooting playerShooting;
    public string eventID;

	// Use this for initialization
	void Start () {
        playerShooting = GetComponent<CompleteProject.PlayerShooting>();
        Koreographer.Instance.RegisterForEvents(eventID, PlayerCanShoot);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PlayerCanShoot(KoreographyEvent koreographyEvent)
    {
        if (Input.GetButton("Fire1"))
        {
            playerShooting.Shoot();
        }
    }
}
