using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 기본 이동 + 점프
    // 상호 작용 ->  object.cs 를 만들어서 거기서 특정 함수 호출해서 쓰기 
    // 피격시 죽음 -> 데미지를 주는 tag 만들어서 거기서 데미지 받으면 죽음
    // 세이브 로드는 죽을시 마지막으로 풀었던 퀴즈로 부활
    // 


    #region 변수

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float dashSpeed;

    [SerializeField] private float fallMultiplierFloat;
    [SerializeField] private float lowJumpMultiplierFloat;

    private float horizontal;


    private Vector2 srSize;

    #endregion

    #region 컴포넌트

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    #endregion

    #region PlayerEnum
    private enum PlayerState
    { 
        Death,
        Alive
    
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
        

        Dash();
       
        Jump();
        BetterJump();

        StopSpeed();

    }

    private void FixedUpdate()
    {
        Move();
    }


    #region private 함수
    private void Initailize()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        srSize = sr.transform.localScale;

        playerState = PlayerState.Alive;
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal ==1)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed,rb.velocity.y);

            // 오른쪽 방향 보기
            transform.localScale = new Vector3(srSize.x, srSize.y, 0);
        }
        else if(horizontal == -1)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

            //왼쪽 방향 보기
            transform.localScale = new Vector3(srSize.x * (-1), srSize.y, 0);
        }
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
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3;
            Debug.Log("keyUp dash" + moveSpeed);

        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("is jump");
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

        }
    }

    private void Interation()
    {

    }



    #endregion

    #region public 함수


    public void GetDamage()
    {
        playerState = PlayerState.Death;

        Debug.Log("PlayerState : " + playerState);
    }

    #endregion
}
