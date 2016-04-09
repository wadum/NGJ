using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Thruster : MonoBehaviour {

    private Rigidbody2D _thruster;

    private bool _on;
    private bool _boosting;

    private float _baseThrust;
    private float _boostThrust;
    private float _hoverThrust;

    private float _hoverDistance;

    private float _boostFactor;
    private float _timeToMax;
    private float _timeToBase;

    private void Awake() {
        _thruster = GetComponent<Rigidbody2D>();
    }

    public void SetThrusterDrag(float drag) {
        _thruster.drag = drag;
    }

    public void SetThrusterMass(float mass) {
        _thruster.mass = mass;
    }

    public void SetEngine(bool on) {
        _on = on;

        if (!_on)
            _boostFactor = 0f;
    }

    public void SetBoost(bool on) {
        _boosting = on;
    }

    public void ToggleEngine() {
        _on = !_on;

        if (!_on)
            _boostFactor = 0f;
    }

    public void ToggleBoost() {
        _boosting = !_boosting;
    }

    public void SetHoverThrust(float force) {
        _hoverThrust = force;
    }

    public void SetHoverDistance(float distance) {
        _hoverDistance = distance;
    }

    public void SetBoostThrust(float force) {
        _boostThrust = force;
    }

    public void SetBaseThrust(float force) {
        _baseThrust = force;
    }

    public void SetTimeToMaxBoost(float seconds) {
        _timeToMax = seconds;
    }

    public void SetTimeToBase(float seconds) {
        _timeToBase = seconds;
    }

    private void BoostStep() {
        if (_boosting) {
            _boostFactor += Time.fixedDeltaTime/_timeToMax;
        }
        else {
            _boostFactor -= Time.fixedDeltaTime/_timeToBase;
        }

        _boostFactor = Mathf.Clamp01(_boostFactor);
    }

    private float CalculateBaseThrust() {
        return (1 - Mathf.Sqrt(_boostFactor))*_baseThrust;
    }

    private float CalculateBoostThrust() {
        return Mathf.Sqrt(_boostFactor)*_boostThrust;
    }

    private float CalculateHoverThrust() {
        var hit = Physics2D.Raycast(transform.position, -transform.up, _hoverDistance);
        if (!hit)
            return 0;

        var ratio = 1 - hit.distance / _hoverDistance;

        return Mathf.Sqrt(ratio)*_hoverThrust;
    }

    private void FixedUpdate () {
        if (!_on)
            return;

        BoostStep();

        var force = CalculateBaseThrust() + CalculateBoostThrust() + CalculateHoverThrust();
        _thruster.AddForce(transform.up * force * Time.fixedDeltaTime, ForceMode2D.Force);
    }
}
