using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

	private Animator anim;
	public GameObject obj; 
	private Animator anim2;
	// Use this for initialization
	void Start () {

		anim = obj.GetComponent<Animator>();
		anim2 = gameObject.GetComponent<Animator>();
		anim2.speed = 1.7f;
		anim2.SetTrigger("start");
		anim.SetTrigger("Start"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
