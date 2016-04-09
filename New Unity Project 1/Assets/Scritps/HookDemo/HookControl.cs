using UnityEngine;
using System.Collections;

public class HookControl : MonoBehaviour {

    public RopeController Rope;

    private HingeJoint2D _hook;

    private bool _FreeHook = true;

    void start()
    {
        _hook = this.GetComponent<HingeJoint2D>();
    }

    void FixedUpdate()
    {

       // this.transform.position = Rope.RopeLinks[Rope.RopeDistance].transform.position;
       //_hook.connectedBody = Rope.RopeLinks[Rope.RopeDistance-].gameObject.GetComponent<Rigidbody2D>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HookableObject" && _FreeHook)
        {
            other.transform.parent = this.transform;
        }
    }
}
