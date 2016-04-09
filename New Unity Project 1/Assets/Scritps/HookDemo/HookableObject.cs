using UnityEngine;
using System.Collections;

public class HookableObject : MonoBehaviour {

    private FixedJoint2D _joint;

	// Use this for initialization
	/*void Start () {
        _joint = this.gameObject.GetComponent<FixedJoint2D>();
	}*/
	
	// Update is called once per frame
	/*void Update () {
	
	}

    void OnColliderEnter(Collider other)
    {
        if(other.gameObject.tag == "Hook")
        {
            _joint.connectedBody = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }*/
}
