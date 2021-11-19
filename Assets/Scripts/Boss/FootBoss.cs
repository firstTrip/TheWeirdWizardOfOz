using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBoss : ActionObj
{

    private GameObject Player;

    private Rigidbody2D rb;
    private Transform TargetPoint;

    private float axcelSpeed = 1f;
    private float tracingTime = 0f;
    [Header("�ִ밡�� �ð�")] public float AxcelMaxTime = 2.0f;

    [SerializeField] private float Values = 3.0f;

    private bool isArrive;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if(Player ==null)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

        }

        isActive = true;
        rb = GetComponent<Rigidbody2D>();
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
        }
        else
        {

        }
    }

    [Header("������ ����")] public float ArrivalCheckValue = 0.03f;
    [Header("�����ð� �Ѱ�")] public float StayLimit = 20f;
    private float stayTime = 0f;

    private void Hunt()
    {
        if (!isArrive)
        {
            // �̵��� �ϰ� �Ǹ� �ϴ� stay�� �ƴѰ���

            // 1. TargetPoint ���� üũ
            float distance = Vector2.Distance(transform.position, TargetPoint.position);

            axcelSpeed = distance / Values;
                
            if (distance <= ArrivalCheckValue)
            {
                isArrive = true;
                Player.GetComponent<Player>().GetDamage();
            }
            // 2. ������ �������� ������ ��
            else
            {
                tracingTime += Time.deltaTime;

                // ����üũ
                float axcel = Mathf.Lerp(0, axcelSpeed, tracingTime / AxcelMaxTime);

                // �̵�
                Vector2 diretion = ((Vector2)TargetPoint.position - (Vector2)transform.position).normalized;
                transform.Translate(diretion * axcel * Time.deltaTime);
            }
        }
        else
        {
            // �����
            stayTime += Time.deltaTime;
            // �������� �Ѱ�ð� ����, ����Ž��.
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

    public override void ObjStart()
    {
        base.ObjStart();
    }
}