using UnityEngine;
using System.Collections;

public class ReactionSoundsController : MonoBehaviour {

	public AudioClip[] Sounds;
	public AudioClip[] Voices;

	public AudioSource SoundSource;
	public AudioSource VoiceSource;

	public int ChanceToPlayVoice = 25;
	public float VoiceDelay = 1f;

	public void PlayWallHitSound()
	{
		if(SoundSource.isPlaying) return;
		SoundSource.clip = Sounds[Random.Range(0,Sounds.Length-1)];
		SoundSource.Play();
	}

	public void PlayTalkingSound()
	{
		if(VoiceSource.isPlaying) return;
		VoiceSource.clip = Voices[Random.Range(0,Voices.Length-1)];
		VoiceSource.PlayDelayed(VoiceDelay);
	}
}
