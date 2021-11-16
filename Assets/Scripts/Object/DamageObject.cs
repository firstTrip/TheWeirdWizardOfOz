using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : ActionObj
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<Player>().GetDamage();
    }
}
