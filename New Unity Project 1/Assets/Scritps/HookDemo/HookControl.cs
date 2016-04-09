using UnityEngine;
using System.Collections;

public class HookControl : MonoBehaviour {

    public GameObject Drone;
    public float MaxHookDistance;

    private bool _AddLength;
    private bool _DecreaseLength;

    private SpringJoint2D _hook;
    // Use this for initialization
    void Start () {
        _hook = this.gameObject.GetComponent<SpringJoint2D>();
    }
	
	// Update is called once per frame
	void Update () {
        _AddLength = Input.GetKey(KeyCode.S);
        _DecreaseLength = Input.GetKey(KeyCode.W);
    }

    void FixedUpdate()
    {
        if (_AddLength && _hook.distance < MaxHookDistance)
            _hook.distance = _hook.distance + 0.05f;
        if (_DecreaseLength && _hook.distance > 0.2f)
            _hook.distance = _hook.distance - 0.05f;
        if(this.gameObject.transform.position.y > _hook.connectedBody.transform.position.y)
        {
            this.transform.position = new Vector3(this.transform.position.x, _hook.connectedBody.transform.position.y);
            

        }
    }
}
