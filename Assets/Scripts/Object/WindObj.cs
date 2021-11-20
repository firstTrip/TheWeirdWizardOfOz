using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindObj : ActionObj
{
    private Rigidbody2D rb;

    [SerializeField] private float WindPower;
    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;

    }

    public override void Action()
    {
        base.Action();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.rb = collision.GetComponent<Player>().rb;
            rb.velocity = new Vector2(rb.velocity.x,  WindPower);
        }
    }
}
