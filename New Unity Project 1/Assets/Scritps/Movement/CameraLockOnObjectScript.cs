﻿using UnityEngine;
using System.Collections;

public class CameraLockOnObjectScript : MonoBehaviour {


    public GameObject Drone;
    public GameObject Drone2;
    public float MinDistanceFromDrone;
	// Use this for initialization
	
	// Update is called once per frame

	void Update () {
        this.transform.position = Drone.transform.position + new Vector3(0, 0, -MinDistanceFromDrone);
    }
}
