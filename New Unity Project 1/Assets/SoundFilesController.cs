using UnityEngine;
using System.Collections;

public class SoundFilesController : MonoBehaviour {

    public AudioSource Exsplosion, Exsplosion2, Music_Layer, Music_MainFast, Music_MainFastLayer, Music_MainTheme, Magnet_Happy, Magnet_Angry, A_Talk_1, A_Talk_2, A_Talk_3, H_Talk_1, H_Talk_2, H_Talk_3;
    // Use this for initialization

    private AudioSource[] allAudioSources;
  
    void Awake()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();

        MuteMusic_Layer(true);
        MuteMusic_MainFast(true);
        MuteMusic_MainFastLayer(true);
        MuteMusic_MainTheme(false);
    }

    public void StopAllAudio()
    {
        foreach(AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
    /*
    BASIC FUNCTIONS
    
    BLUEPRINT
    
    public void PlayNAME()
    {
        NAME.Play();
	}

    public void StopNAME()
    {
        NAME.Stop();
    }
    */
    public void PlayA_Talk_1()
    {
        A_Talk_1.Play();
    }

    public void StopA_Talk_1()
    {
        A_Talk_1.Stop();
    }
    public void PlayA_Talk_2()
    {
        A_Talk_2.Play();
    }

    public void StopA_Talk_2()
    {
        A_Talk_2.Stop();
    }
    public void PlayA_Talk_3()
    {
        A_Talk_3.Play();
    }

    public void StopA_Talk_3()
    {
        A_Talk_3.Stop();
    }
    public void PlayH_Talk_1()
    {
        H_Talk_1.Play();
    }

    public void StopH_Talk_1()
    {
        H_Talk_1.Stop();
    }
    public void PlayH_Talk_2()
    {
        H_Talk_2.Play();
    }

    public void StopH_Talk_2()
    {
        H_Talk_2.Stop();
    }
    public void PlayH_Talk_3()
    {
        H_Talk_3.Play();
    }

    public void StopH_Talk_3()
    {
        H_Talk_3.Stop();
    }
    public void PlayMagnet_Angry()
    {
        Magnet_Angry.Play();
    }

    public void StopMagnet_Angry()
    {
        Magnet_Angry.Stop();
    }
    public void PlayMagnet_Happy()
    {
        Magnet_Happy.Play();
    }

    public void StopMagnet_Happy()
    {
        Magnet_Happy.Stop();
    }

    public void PlayExsplosion()
    {
        Exsplosion.Play();
	}

    public void StopExsplosion()
    {
        Exsplosion.Stop();
    }

    public void PlayExsplosion2()
    {
        Exsplosion2.Play();
    }

    public void StopExsplosion2()
    {
        Exsplosion2.Stop();
    }

    public void PlayMusic_Layer()
    {
        Music_Layer.Play();
    }

    public void MuteMusic_Layer(bool Mute)
    {
        Music_Layer.mute = Mute;
    }

    public void StopMusic_Layer()
    {
        Music_Layer.Stop();
    }

    public void PlayMusic_MainFast()
    {
        Music_MainFast.Play();
    }

    public void MuteMusic_MainFast(bool Mute)
    {
        Music_MainFast.mute = Mute;
    }

    public void StopMusic_MainFast()
    {
        Music_MainFast.Stop();
    }

    public void PlayMusic_MainFastLayer()
    {
        Music_MainFastLayer.Play();
    }

    public void MuteMusic_MainFastLayer(bool Mute)
    {
        Music_MainFastLayer.mute = Mute;
    }

    public void StopMusic_MainFastLayer()
    {
        Music_MainFastLayer.Stop();
    }

    public void PlayMusic_MainTheme()
    {
        Music_MainTheme.Play();
    }

    public void MuteMusic_MainTheme(bool Mute)
    {
        Music_MainTheme.mute = Mute;
    }

    public void StopMusic_MainTheme()
    {
        Music_MainTheme.Stop();
    }
}
