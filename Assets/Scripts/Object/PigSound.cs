using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSound : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip Scream1;
    public AudioClip Scream2;
    // Start is called before the first frame update
    private void MakeSound()
    {
        audioSource.volume = 0.5f;

        int Scream = Random.Range(1, 3);
        Debug.Log("Scream" + Scream.ToString());
        PlaySound("Scream" + Scream.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            MakeSound();
    }

    public void PlaySound(string soundName)
    {
        if (soundName == "Scream1")
        {
            audioSource.PlayOneShot(Scream1);

        }
        else if (soundName == "Scream2")
        {
            audioSource.PlayOneShot(Scream2);

        }

    }
}
