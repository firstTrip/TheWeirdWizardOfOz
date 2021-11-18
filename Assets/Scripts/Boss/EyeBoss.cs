using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBoss : ActionObj
{

    private GameObject Player;

    private Rigidbody2D rb;
    private Transform TargetPoint;


    public SpriteRenderer sr;


    public bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }

        isActive = true;

       // sr = GetComponentInChildren<SpriteRenderer>();

        isOpen = true;
        TargetPoint =null;
        StartCoroutine(fadeIn(0.5f));
    }

    IEnumerator fadeIn(float fadeInTime)
    {
        Color tempColor = sr.color;

        while (true)
        {
            while (tempColor.a < 0.9f)
            {
                tempColor.a += Time.deltaTime / (fadeInTime / 2);

                sr.color = tempColor;

                if (tempColor.a >= 0.9f)
                    tempColor.a = 0.9f;

                yield return new WaitForSeconds(0.05f);
            }
            isOpen = false;
            sr.color = tempColor;

            yield return new WaitForSeconds(2f);

            while (tempColor.a > 0f)
            {

                tempColor.a -= Time.deltaTime / fadeInTime;

                sr.color = tempColor;

                if (tempColor.a <= 0f)
                    tempColor.a = 0f;


                yield return new WaitForSeconds(0.05f);


            }

            sr.color = tempColor;
            isOpen = true;
            yield return new WaitForSeconds(3f);

        }
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

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;

        if (!isOpen)
            trackingPlayer();

        DontMove(isOpen);
    }

    void DontMove(bool isOpen)
    {
        if (isOpen)
            if (TargetPoint.position == Player.transform.position)
                Player.GetComponent<Player>().GetDamage();
            
    }

    public override void ObjStart()
    {
        base.ObjStart();
    }

}
