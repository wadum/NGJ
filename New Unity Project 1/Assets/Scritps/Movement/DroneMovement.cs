using UnityEngine;

public class DroneMovement : MonoBehaviour {

    public Rigidbody2D Drone, LeftThruster, RightThruster;

    public KeyCode LeftBoost;
    public KeyCode RightBoost;

    public KeyCode ToggleThrusters;

    public float BaseAcceleration;
    public float BoostAcceleration;
    public float Drag;

    private bool _boostingLeft;
    private bool _boostingRight;
    private bool _thrustersOn = true;

    private void Start () {
        Drone.drag = Drag;
        Drone.mass = 1;
        LeftThruster.drag = Drag;
        LeftThruster.mass = 1;
        RightThruster.drag = Drag;
        RightThruster.mass = 1;
    }

    // Update is called once per frame
    private void Update () {
        _boostingLeft = Input.GetKey(LeftBoost);
        _boostingRight = Input.GetKey(RightBoost);

        if (Input.GetKeyDown(ToggleThrusters))
            _thrustersOn = !_thrustersOn;
    }

    private void FixedUpdate () {
        if (!_thrustersOn)
            return;

        var leftForce = _boostingLeft?
            BoostAcceleration:
            BaseAcceleration;
        var rightForce = _boostingRight?
            BoostAcceleration:
            BaseAcceleration;

        LeftThruster
            .AddForce(LeftThruster.transform.up * leftForce * Time.fixedDeltaTime, ForceMode2D.Force);
        RightThruster
            .AddForce(RightThruster.transform.up * rightForce * Time.fixedDeltaTime, ForceMode2D.Force);
    }
}