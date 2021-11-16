using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �⺻ �̵� + ����
    // ��ȣ �ۿ� ->  object.cs �� ���� �ű⼭ Ư�� �Լ� ȣ���ؼ� ���� 
    // �ǰݽ� ���� -> �������� �ִ� tag ���� �ű⼭ ������ ������ ����
    // ���̺� �ε�� ������ ���������� Ǯ���� ����� ��Ȱ
    // 


    #region ����

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float dashSpeed;

    [SerializeField] private float fallMultiplierFloat;
    [SerializeField] private float lowJumpMultiplierFloat;

    private float horizontal;


    private Vector2 srSize;

    [SerializeField] private GameObject holdObj;
    [SerializeField] private Transform holdPos;

    #endregion

    #region ������Ʈ

    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    #endregion

    #region PlayerEnum
    private enum PlayerState
    { 
        Death,
        Alive,
        Jump,
        Walk,
        Idle
    
    }

    private PlayerState playerState;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Initailize();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == PlayerState.Death)
            return;

        Dash();
       
        Jump();
        BetterJump();

        Interation();

        StopSpeed();

    }

    private void FixedUpdate()
    {
        if (playerState == PlayerState.Death)
            return;

        Move();
    }


    #region private �Լ�
    private void Initailize()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        srSize = sr.transform.localScale;

        playerState = PlayerState.Alive;
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        anim.SetBool("Walk", true);

        if(horizontal ==1)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed,rb.velocity.y);

            // ������ ���� ����
            transform.localScale = new Vector3(srSize.x, srSize.y, 0);
        }
        else if(horizontal == -1)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

            //���� ���� ����
            transform.localScale = new Vector3(srSize.x * (-1), srSize.y, 0);
        }

        if(horizontal ==0)
            anim.SetBool("Walk", false);

    }


    private void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplierFloat - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplierFloat - 1) * Time.deltaTime;
        }
    }

    private void StopSpeed()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(rb.velocity.normalized.x * 0.5f, rb.velocity.y);

            rb.velocity = Vector2.zero;

           
        }

    }

    private void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5;
            Debug.Log("keyDown dash" +moveSpeed);
            anim.SetBool("Run", true);
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3;
            Debug.Log("keyUp dash" + moveSpeed);
            anim.SetBool("Run", false);


        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1f, LayerMask.GetMask("Ground"));

            if (hit.collider !=null)
            {
                anim.SetTrigger("Jump");
                Debug.Log(hit.collider.name);
                Debug.Log("is jump");
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            }
            

        }
    }

    private void Interation()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Pick", true);
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1f, LayerMask.GetMask("Item"));

            if (hit.collider != null)
            {
                anim.SetBool("Hold", true);

                Debug.Log("is it item");
                holdObj = hit.collider.gameObject;
                holdObj.transform.position = holdPos.position;
                holdObj.transform.parent = this.gameObject.transform;
            }
            else
                anim.SetBool("Pick", false);

            /*
            if (holdObj != null)
                anim.SetBool("Pick", false);
            else
                anim.SetBool("Hold", true);
            */

            

        }
    }



    #endregion

    #region public �Լ�


    public void GetDamage()
    {
        playerState = PlayerState.Death;

        anim.SetBool("GameOver", true);
        Debug.Log("PlayerState : " + playerState);
    }

    #endregion
}
