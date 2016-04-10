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
            Debug.Log(this.gameObject.transform.root.gameObject.name);
            if (this.gameObject.transform.root.gameObject.name == "PlayerAWD")
            {
                int randomNumber = Random.Range(0, 2);
                StartCoroutine(HappyGrabbingConversation(randomNumber));               
            }

            if (this.gameObject.transform.root.gameObject.tag == "PlayerArrows")
            {
                int randomNumber = Random.Range(0, 2);
                StartCoroutine(AngryGrabbingConversation(randomNumber));
            }
        }
    }

    IEnumerator HappyGrabbingConversation(int RN)
    {
        Debug.Log("Play sound");
        if (RN == 0) SoundFiles.PlayH_Talk_1();
        if (RN == 1) SoundFiles.PlayH_Talk_2();
        if (RN == 2) SoundFiles.PlayH_Talk_3();

        yield return new WaitForSeconds(1.5f);

        if (RN == 0) SoundFiles.PlayA_Talk_1();
        if (RN == 1) SoundFiles.PlayA_Talk_2();
        if (RN == 2) SoundFiles.PlayA_Talk_3();

        yield return null;
    }

    IEnumerator AngryGrabbingConversation(int RN)
    {
        if (RN == 0) SoundFiles.PlayA_Talk_1();
        if (RN == 1) SoundFiles.PlayA_Talk_2();
        if (RN == 2) SoundFiles.PlayA_Talk_3();

        yield return new WaitForSeconds(1.5f);

        if (RN == 0) SoundFiles.PlayH_Talk_1();
        if (RN == 1) SoundFiles.PlayH_Talk_2();
        if (RN == 2) SoundFiles.PlayH_Talk_3();

        yield return null;
    }
}
