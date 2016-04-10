using UnityEngine;
using System.Collections;

public class EnableAll : MonoBehaviour {

	public GameObject[] ObjectsToEnable;
	public GameObject[] ObjectsToDisable;
	public Animator animator;

	void OnEnable()
	{
		animator.enabled = false;
		foreach(var obj in ObjectsToEnable)	{
			obj.SetActive(true);
		}
		foreach(var obj in ObjectsToDisable)	{
			obj.SetActive(false);
		}
	}
}
