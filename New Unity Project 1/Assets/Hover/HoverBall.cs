using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HoverBall : MonoBehaviour {

    public KeyCode Up;
    public KeyCode Left;
    public KeyCode Right;

    public float Mass;
    public float Drag;
    public float Gravity;

    public float HoverForce;
    public float SidewaysForce;

    private bool _left;
    private bool _right;
    private bool _up;

    private Rigidbody2D _rb;

    private void Update () {
        _up = Input.GetKey(Up);
        _left = Input.GetKey(Left);
        _right = Input.GetKey(Right);

        _rb = GetComponent<Rigidbody2D>();

        _rb.mass = Mass;
        _rb.drag = Drag;
        _rb.gravityScale = Gravity;
    }

    private void FixedUpdate() {
        if (_up)
            _rb.AddForce(HoverForce * Time.fixedDeltaTime * Vector2.up, ForceMode2D.Force);

        if (_left)
            _rb.AddForce(SidewaysForce * Time.fixedDeltaTime * Vector2.left, ForceMode2D.Force);

        if (_right)
            _rb.AddForce(SidewaysForce * Time.fixedDeltaTime * -Vector2.left, ForceMode2D.Force);
    }
}
