using System.Runtime.InteropServices;
using UnityEngine;

public class Gyrostabilizer : MonoBehaviour {

    public Rigidbody2D Target;
    public float AngularDrag;
    public float MaxForce;
    public float Deadzone;
    public float MaxZone;
    public AnimationCurve DampeningCurve;

    private void Start() {
        Target.angularDrag = AngularDrag;
    }

	// Update is called once per frame
    private void FixedUpdate () {
        var angle = Vector2.Angle(Vector2.up, transform.up);
        if (angle < Deadzone)
            return;

        var offset = angle - Deadzone;
        var maxOffset = MaxZone - Deadzone;
        var badness = offset/maxOffset;
        if (badness > 1)
            badness = 1;

        var left = transform.right.y > 0 ? -1 : 1;
        var correction = DampeningCurve.Evaluate(badness) * MaxForce * left;

        Target.AddTorque(correction * Time.fixedDeltaTime, ForceMode2D.Force);
    }
}
