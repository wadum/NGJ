using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class WallColliderController : MonoBehaviour {

	public AudioClip[] Sounds;
	public AudioClip[] Voices;

	public AudioSource SoundSource;
	public AudioSource VoiceSource;

	public int ChanceToPlayVoice = 25;

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Hit!");
		if(other.tag == "Player" && !SoundSource.isPlaying)
		{
			SoundSource.PlayOneShot(Sounds[Random.Range(0,Sounds.Length-1)]);
			if(Random.Range(0,100) > ChanceToPlayVoice)
			{
				VoiceSource.clip = Voices[Random.Range(0,Voices.Length-1)];
				VoiceSource.PlayDelayed(1);
			}
		}
	}
}
