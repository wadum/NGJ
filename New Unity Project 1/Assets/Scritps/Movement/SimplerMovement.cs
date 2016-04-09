using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SimplerMovement : MonoBehaviour {

    public KeyCode LeftThruster;
    public KeyCode RightThruster;
    public KeyCode ForwardThruster;

    public float MaximumVelocity;
    public float TimeToMaximumVelocity;

    public float TurnForce;
    public float MaximumTurnSpeed;

    private Rigidbody2D _drone;

    private bool _leftThrusterOn;
    private bool _rightThrusterOn;
    private bool _forwardThrusterOn;

    private void Start() {
        _drone = GetComponent<Rigidbody2D>();
    }

    private void Update () {
        _leftThrusterOn = Input.GetKey(LeftThruster);
        _rightThrusterOn = Input.GetKey(RightThruster);
        _forwardThrusterOn = Input.GetKey(ForwardThruster);
    }

    private Vector2 CalculateNextVelocity() {
        // decompose the velocities from forward and other;
        var forward = Vector2.Dot(_drone.velocity, _drone.transform.up) * _drone.transform.up;
        var other = Vector2.Dot(_drone.velocity, _drone.transform.right) * _drone.transform.right;

        var velocity = forward.magnitude + MaximumVelocity * Time.fixedDeltaTime / TimeToMaximumVelocity;
        if (velocity > MaximumVelocity)
            velocity = MaximumVelocity;

        return _drone.transform.up*velocity + other;
    }

    private void FixedUpdate() {
        if (_forwardThrusterOn)
            _drone.velocity = CalculateNextVelocity();

        if (_leftThrusterOn && !_rightThrusterOn)
            _drone.AddTorque(TurnForce * Time.fixedDeltaTime, ForceMode2D.Force);

        if (_rightThrusterOn && !_leftThrusterOn)
            _drone.AddTorque(-TurnForce * Time.fixedDeltaTime, ForceMode2D.Force);

        if (_drone.angularVelocity > MaximumTurnSpeed)
            _drone.angularVelocity = MaximumTurnSpeed;
    }
}