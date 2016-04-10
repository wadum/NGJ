using UnityEngine;
using System.Collections;

public class WinningBowl : MonoBehaviour {

    public GameObject WinningScreen;

    bool winning = false;
    float timer = 0;
	// Use this for initialization
	
	void TriggerEnter2D(Collider other)
    {
        if(other.gameObject.tag == "HookableObject")
        {
            winning = true;
            if (timer == 0) {
                StartCoroutine(CheckTime());
            }
        }
    }

    void TriggerExit2D(Collider other)
    {
        if (other.gameObject.tag == "HookableObject")
        {
            winning = false;
            timer = 0;
        }
    }

    IEnumerator CheckTime()
    {
        while (winning)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                WinningScreen.SetActive(true);
            }
        }
        yield return null;
    }
}
