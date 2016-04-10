using UnityEngine;
using System.Collections;

public class HookControl : MonoBehaviour {


    public SoundFilesController SoundFiles;
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
            if(this.gameObject.transform.root.name == "HappyBot")
            {
                SoundFiles.PlayMagnet_Happy();
            }

            if (this.gameObject.transform.root.name == "AngryBot")
            {
                SoundFiles.PlayMagnet_Angry();
            }
        }
    }
}
