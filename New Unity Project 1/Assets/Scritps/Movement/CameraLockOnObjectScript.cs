using UnityEngine;
using System.Collections;

public class CameraLockOnObjectScript : MonoBehaviour {


    public GameObject Drone;
    public GameObject Drone2;
    public float MinDistanceFromDrone;
	// Use this for initialization
	
	// Update is called once per frame
    void Start()
    {
        this.transform.position = Drone.transform.position - (Drone.transform.position - Drone2.transform.position) / 2 + new Vector3(0, 0, -MinDistanceFromDrone);
    }

	void Update () {
        this.transform.position = Drone.transform.position - (Drone.transform.position - Drone2.transform.position)/2 + new Vector3(0, 0, -MinDistanceFromDrone);

        if (Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
