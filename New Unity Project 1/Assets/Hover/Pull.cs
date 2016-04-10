using UnityEngine;

public class Pull : MonoBehaviour {

    public AnimationCurve PullCurve;
    public float MaximalPull;
    public float Radius;

    public Rigidbody2D[] _bodies;

    private void FixedUpdate() {
        for (var i = 0; i < _bodies.Length; i++) {
            var dist = Vector2.Distance(_bodies[i].position, transform.position);

            if (dist >= Radius)
                continue;

            var ratio = Mathf.Clamp01(1 - dist/Radius);
            var force = PullCurve.Evaluate(ratio)*MaximalPull*Time.fixedDeltaTime;
            var dir = (Vector2)transform.position - _bodies[i].position;

            _bodies[i].AddForce(force * dir, ForceMode2D.Force);
        }
    }
}
