using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region SingleTon
    /* SingleTon */
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(AudioManager)) as AudioManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "AudioManager";
                    instance = container.AddComponent(typeof(AudioManager)) as AudioManager;
                }
            }

            return instance;
        }
    }

    #endregion

    public AudioSource audioSource;

    public AudioClip MainBGM;

    public AudioClip GameBGM;


    public AudioClip Scream1;
    public AudioClip Scream2;

    private void Awake()
    {
        #region SingleTon
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        #endregion

        audioSource = GetComponent<AudioSource>();
    }


    public void PlayLoopSound(string loopSound)
    {
        if (!audioSource.isPlaying)
            audioSource.Stop();

        StartCoroutine(loopSound);
    }

    IEnumerator MainLoopSound()
    {
        audioSource.volume = 0.5f;
        audioSource.clip = MainBGM;
        audioSource.Play();

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!audioSource.isPlaying)
            {
                audioSource.clip = MainBGM;
                audioSource.Play();
                audioSource.loop = true;
            }
        }

    }

    IEnumerator StageLoopSound()
    {
        audioSource.volume = 0.3f;
        audioSource.clip = GameBGM;
        audioSource.Play();

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!audioSource.isPlaying)
            {
                audioSource.clip = GameBGM;
                audioSource.Play();
                audioSource.loop = true;
            }
        }

    }


    public void PlaySound(string soundName)
    {
        if (soundName == "Scream1")
        {

            audioSource.PlayOneShot(Scream1);

        }
        else if(soundName == "Scream2")
        {
            audioSource.PlayOneShot(Scream2);

        }
      


    }

}
