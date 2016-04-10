using UnityEngine;

public class Gravitron : MonoBehaviour {
    public AnimationCurve GravityCurve;
    public float MaximalPull;
    public float Radius;

    public Rigidbody2D Target;
    public SpriteRenderer Effect;

    private void Update() {
        if (!Effect)
            return;

        var curveRatio = GravityCurve.Evaluate(Ratio());
        SizeEffect(curveRatio);
        SetAlpha(curveRatio);
        PlaceEffect();
    }

    private void PlaceEffect() {
        Effect.transform.position = transform.position;
        Effect.transform.LookAt(Target.transform);
    }

    private void SizeEffect(float size) {
        var clampedSize = Mathf.Clamp(size, 0.1f, 1f);
        Effect.transform.localScale = new Vector3(clampedSize, clampedSize, 1);
    }

    private void SetAlpha(float alpha) {
        var color = Effect.color;
        color.a = alpha;
        Effect.color = color;
    }

    private float Ratio() {
        var dist = Vector2.Distance(Target.position, transform.position);
        var ratio = Mathf.Clamp01(1 - dist/Radius);
        return ratio;
    }

    private void FixedUpdate() {
        var force = GravityCurve.Evaluate(Ratio())*MaximalPull*Time.fixedDeltaTime;
        var dir = (Vector2)transform.position - Target.position;

        Target.AddForce(force * dir, ForceMode2D.Force);
    }
}
