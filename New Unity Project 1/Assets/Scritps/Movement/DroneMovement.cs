using UnityEngine;

public class DroneMovement : MonoBehaviour {

    public Rigidbody2D Drone, LeftThruster, RightThruster;

    public float Acceleration = 2f;
    public float Drag = 0.2f;
    public float AngularDrag = 50;

    private bool _thrustingLeft;
    private bool _thrustingRight;

    void Start () {
        Drone.drag = Drag;
        Drone.mass = 1;
        LeftThruster.drag = Drag;
        LeftThruster.mass = 1;
        RightThruster.drag = Drag;
        RightThruster.mass = 1;
    }

    // Update is called once per frame
    void Update () {
        _thrustingLeft = Input.GetKey(KeyCode.A);
        _thrustingRight = Input.GetKey(KeyCode.D);
    }

    void FixedUpdate () {
        if (_thrustingLeft)
            LeftThruster.AddForce(LeftThruster.transform.up * Acceleration, ForceMode2D.Force);
        if (_thrustingRight)
            RightThruster.AddForce(RightThruster.transform.up * Acceleration, ForceMode2D.Force);
    }
}
