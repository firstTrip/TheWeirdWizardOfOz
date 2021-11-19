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

    }


    public void PlayLoopSound(string loopSound)
    {
        if (!audioSource.isPlaying)
            audioSource.Stop();
        StartCoroutine(loopSound);
    }

    IEnumerator NomalLoopSound()
    {
        audioSource.volume = 1;
        //audioSource.clip = NomalBGM[0];
        audioSource.Play();

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!audioSource.isPlaying)
            {
                //audioSource.clip = NomalBGM[1];
                audioSource.Play();
                audioSource.loop = true;
            }
        }

    }

    IEnumerator BossLoopSound()
    {
        audioSource.volume = 1;
        //audioSource.clip = BossBgm[0];
        audioSource.Play();

        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (!audioSource.isPlaying)
            {
                //audioSource.clip = BossBgm[1];
                audioSource.Play();
                audioSource.loop = true;
            }
        }

    }


    public void PlaySound(string soundName)
    {
        if (soundName == "BGM")
        {
            //audioSource.PlayOneShot(BGM);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
