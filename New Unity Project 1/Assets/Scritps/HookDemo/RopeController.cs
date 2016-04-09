using UnityEngine;
using System.Collections;

public class RopeController : MonoBehaviour
{

    public GameObject Drone;
    public GameObject Hook;
    

    private bool _AddLength;
    private bool _DecreaseLength;
    public float RopeSpeed = 0.1f;

    public float MinDistance = 0;
    public float MaxDistance = 10;

    public float RopeDistance = 1;
    private HingeJoint2D[] joints;
    // Use this for initialization
    void Awake()
    {
        joints = this.gameObject.GetComponentsInChildren<HingeJoint2D>();
        AlterRopeDistance(RopeDistance);
        //_Hook = GameObject.FindGameObjectWithTag("Hook").GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.S))
        {
            RopeDistance = RopeDistance + RopeSpeed;
            AlterRopeDistance(RopeDistance);
        }
        if (Input.GetKey(KeyCode.W))
        {
            RopeDistance = RopeDistance - RopeSpeed;
            AlterRopeDistance(RopeDistance);
        }

    }

    private void AlterRopeDistance(float distance)
    {
        foreach( var joint in joints)
        {
            joint.connectedAnchor = new Vector2(0,-distance);
        }
    }

    /*void FixedUpdate()
    {
        if (_AddLength && RopeDistance < RopeLinks.Length)
            RopeDistance = RopeDistance + 1;
        if (_DecreaseLength && RopeDistance > 0)
            RopeDistance = RopeDistance - 1;

        for(int i = 0; i < RopeLinks.Length; i++)
        {
            if(i <= RopeDistance)
            {
                RopeLinks[i].SetActive(true);
            } else
            {
                RopeLinks[i].SetActive(false);
            }
        }
    }*/
}
