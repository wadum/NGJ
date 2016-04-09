using UnityEngine;
using System.Collections;

public class HookControl : MonoBehaviour {

    //Works
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HookableObject")
        {
            other.transform.parent = this.transform;
        }
    }*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HookableObject")
        {
            other.GetComponent<HingeJoint2D>().connectedBody = this.transform.parent.gameObject.GetComponent<Rigidbody2D>();
            other.GetComponent<HingeJoint2D>().enabled = true;
        }
    }
}
