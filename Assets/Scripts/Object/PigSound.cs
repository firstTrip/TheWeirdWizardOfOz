using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSound : MonoBehaviour
{
    // Start is called before the first frame update
    private void MakeSound()
    {
        int Scream = Random.Range(1, 3);
        Debug.Log("Scream" + Scream.ToString());
        AudioManager.Instance.PlaySound("Scream" + Scream.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            MakeSound();
    }
}
