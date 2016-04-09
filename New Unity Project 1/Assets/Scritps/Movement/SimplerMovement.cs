using System.Runtime.InteropServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplerMovement : MonoBehaviour {

    public KeyCode LeftThruster;
    public KeyCode RightThruster;

    public float ForwardForce;
    public float RotationForce;

    private Rigidbody2D _drone;

    private bool _leftThrusterOn;
    private bool _rightThrusterOn;

    private void Start() {
        _drone = GetComponent<Rigidbody2D>();
    }

    private void Update () {
        _leftThrusterOn = Input.GetKey(LeftThruster);
        _rightThrusterOn = Input.GetKey(RightThruster);
    }

    private void FixedUpdate() {
        if (!_leftThrusterOn && !_rightThrusterOn) {
            return;
        }

        var force = _leftThrusterOn && _rightThrusterOn ? ForwardForce : 0.75f*ForwardForce;

        _drone.AddForce(force*_drone.transform.up*Time.fixedDeltaTime, ForceMode2D.Force);

        if (_leftThrusterOn && !_rightThrusterOn)
            _drone.AddTorque(RotationForce*Time.fixedDeltaTime, ForceMode2D.Force);

        if (_rightThrusterOn && !_leftThrusterOn)
            _drone.AddTorque(-RotationForce*Time.fixedDeltaTime, ForceMode2D.Force);
    }
}