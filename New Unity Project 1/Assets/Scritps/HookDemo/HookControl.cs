using UnityEngine;
using System.Collections;

public class HookControl : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HookableObject")
        {
            other.transform.parent = this.transform;
        }
    }
}
