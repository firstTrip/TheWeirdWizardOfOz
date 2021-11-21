using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBoss : ActionObj
{

    private GameObject Player;

    private Rigidbody2D rb;
    private Transform TargetPoint;

    private Animator anim;


    private bool isJump =true;
    private float axcelSpeed = 1f;
    private float tracingTime = 0f;
    [Header("최대가속 시간")] public float AxcelMaxTime = 2.0f;

    [SerializeField] private float Values = 3.0f;

    private bool isArrive;

    public AudioSource audioSource;
    public AudioClip Run;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if(Player ==null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }

        isActive = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;

        trackingPlayer();

        CheckObstacle();
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
            isArrive = false;
            Hunt();
            IsJump();
        }
        else
        {

        }
    }

    [Header("목적지 보정")] public float ArrivalCheckValue = 0.03f;
    [Header("교착시간 한계")] public float StayLimit = 20f;
    private float stayTime = 0f;

    private void Hunt()
    {
        if (!isArrive)
        {
            // 이동을 하게 되면 일단 stay는 아닌거임

            // 1. TargetPoint 도달 체크
            float distance = Vector2.Distance(transform.position, TargetPoint.position);

            axcelSpeed = distance / Values;
                
            if (distance <= ArrivalCheckValue)
            {
                isArrive = true;
                Player.GetComponent<Player>().GetDamage();
            }
            // 2. 목적지 도달하지 못했을 시
            else
            {
                tracingTime += Time.deltaTime;

                // 가속체크
                float axcel = Mathf.Lerp(0, axcelSpeed, tracingTime / AxcelMaxTime);

                // 이동
                Vector2 diretion = ((Vector2)TargetPoint.position - (Vector2)transform.position).normalized;
                transform.Translate(diretion * axcel * Time.deltaTime);
            }
        }
        else
        {
            // 대기중
            stayTime += Time.deltaTime;
            // 교착상태 한계시간 종료, 강제탐색.
            if (stayTime >= StayLimit)
            {
                TargetPoint = Player.transform;
            }
        }

    }

    private void CheckObstacle()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position , Vector2.right, 2f ,LayerMask.GetMask("Ground"));
        RaycastHit2D hit2 = Physics2D.Raycast(this.transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position , Vector2.right * 1.5f, Color.blue);


        if (hit.collider !=null)
        {

            if(hit2.collider != null)
            {
                Debug.Log(hit.collider.name);
                rb.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);
            }
           

        }
    }

    private void IsJump()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + new Vector2(1,0), Vector2.down, 2f, LayerMask.GetMask("Ground"));
        Debug.DrawRay((Vector2)transform.position + new Vector2(0.5f, 0), Vector2.down * 2f, Color.blue);


        Debug.Log(isJump);
        Debug.Log(hit);

        if (!hit && isJump)
        {
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            Debug.Log("is empty");
            StartCoroutine(isJumpReset());
        }
    }

    IEnumerator isJumpReset()
    {
        isJump = false;
        yield return new WaitForSeconds(1f);
        isJump = true;
    }

    public override void Action()
    {
        base.Action();

        anim.SetBool("Start", true);
        PlaySound();
    }

    public void PlaySound()
    {
        audioSource.clip = Run;
        audioSource.Play();

        audioSource.volume = 1;
        audioSource.loop = true;



    }
}
