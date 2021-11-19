using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBoss : MonoBehaviour
{
    private GameObject Player;

    private Transform TargetPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }


    }

    // Update is called once per frame
    void Update()
    {
        trackingPlayer();

        if (Input.GetKeyDown(KeyCode.A))
            Attack();


    }

    private void trackingPlayer()
    {
        Vector2 direction = Player.transform.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position, direction, Color.red, 0.1f);

        Debug.Log(hit.collider.name);

        if (hit.collider != null)
        {
            Debug.Log("is tracing");
            TargetPoint = Player.transform;
        }
        else
        {

        }
    }

    private void Attack()
    {
        transform.Translate(Vector2.down * 10 * Time.deltaTime);
    }
}
