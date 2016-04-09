using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class WallColliderController : MonoBehaviour {

	public AudioClip[] Sounds;

	private AudioSource _source;

	void Start()
	{
		_source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Hit!");
		if(other.tag == "Player" && !_source.isPlaying)
		{
			_source.clip = Sounds[Random.Range(0,Sounds.Length-1)];
			_source.Play();
		}
	}
}
