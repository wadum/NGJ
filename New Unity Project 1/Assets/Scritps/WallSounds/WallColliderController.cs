using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class WallColliderController : MonoBehaviour {

	public AudioClip[] Sounds;
	public AudioClip[] Voices;

    public SoundFilesController SoundFiles;

	public AudioSource SoundSource;
	public AudioSource VoiceSource;

    public Animator DeathAnimation;

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

        if(other.tag == "Reactor")
        {
            other.gameObject.GetComponent<ReactorState>().ReactorDmg +=1;

            if(other.gameObject.GetComponent<ReactorState>().ReactorDmg == 4)
            {
                SoundFiles.MuteMusic_MainTheme(true);
                SoundFiles.MuteMusic_Layer(false);
            }
       
            else if (other.gameObject.GetComponent<ReactorState>().ReactorDmg == 7)
            {
                SoundFiles.MuteMusic_Layer(true);
                SoundFiles.MuteMusic_MainFastLayer(false);
            }

                if (other.gameObject.GetComponent<ReactorState>().ReactorDmg >= other.gameObject.GetComponent<ReactorState>().ReactorMaxHealth)
            {
                other.gameObject.transform.parent.gameObject.SetActive(false);
                SoundFiles.StopAllAudio();
                SoundFiles.PlayExsplosion2();
                StartCoroutine(DieAndResetLevel());
            }
            StartCoroutine(WaitForReactorToBeAbleToHitAgain());
        }
	}

    IEnumerator WaitForReactorToBeAbleToHitAgain()
    {
        yield return new WaitForSeconds(1);
        yield return null;
    }

    IEnumerator DieAndResetLevel()
    {
        DeathAnimation.SetBool("Death", true);
        Application.LoadLevel(Application.loadedLevel);
        yield return null;
    }
}
