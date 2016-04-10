using UnityEngine;
using System.Collections;

public class LoadGameScene : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			UnityEngine.SceneManagement.SceneManager.LoadScene("CobotsGrab");
		}
	}
}
