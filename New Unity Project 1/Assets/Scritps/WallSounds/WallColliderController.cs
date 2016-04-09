using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class WallColliderController : MonoBehaviour {

	public AudioClip[] Sounds;
	public AudioClip[] Voices;

	public AudioSource SoundSource;
	public AudioSource VoiceSource;

	public int ChanceToPlayVoice = 25;

	private bool _isTriggered = false; 

	void OnTriggerExit2D (Collider2D other)
	{
		_isTriggered  = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Hit!");
		if(other.tag == "Player" && !SoundSource.isPlaying && !_isTriggered)
		{
			SoundSource.clip = Sounds[Random.Range(0,Sounds.Length-1)];
			SoundSource.Play();
			if(Random.Range(0,100) > ChanceToPlayVoice)
			{
				VoiceSource.clip = Voices[Random.Range(0,Voices.Length-1)];
				VoiceSource.PlayDelayed(1);
			}
			_isTriggered = true;
		}
	}
}
