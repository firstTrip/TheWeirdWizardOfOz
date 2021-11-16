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

    [SerializeField] private GameObject holdObj;
    [SerializeField] private Transform holdPos;

    private bool isMove;

    #endregion

    #region 컴포넌트

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
        Idle,
        Wait
    
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
        if (playerState == PlayerState.Death || playerState == PlayerState.Wait)
            return;

        Dash();
       
        Jump();
        BetterJump();

        Interation();
        isUse();
        StopSpeed();

    }

    private void FixedUpdate()
    {
        if (playerState == PlayerState.Death || playerState == PlayerState.Wait)
            return;

        Move();
    }


    #region private 함수
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

            // 오른쪽 방향 보기
            transform.localScale = new Vector3(srSize.x, srSize.y, 0);
        }
        else if(horizontal == -1)
        {
            rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

            //왼쪽 방향 보기
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
                playerState = PlayerState.Wait;
                anim.SetBool("Hold", true);

                Debug.Log("is it item");
                StartCoroutine(AfterAnim(GetAnimDuration("Hold") + 0.3f, hit.collider.gameObject));
               
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

    private void isUse()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            if (holdObj != null)
            {
                holdObj.transform.position = transform.position;
                holdObj.transform.parent = null;
                holdObj = null;
            }
        }
    }

    private float GetAnimDuration(string animName)
    {
        //string name = string.Empty;

        float time = 0f;
        RuntimeAnimatorController ac = anim.runtimeAnimatorController;

        for(int i=0;i<ac.animationClips.Length;i++)
        {
            if(ac.animationClips[i].name == animName)
                time = ac.animationClips[i].length;
        }
        Debug.Log(time);

        return time;
    }

    private IEnumerator AfterAnim(float waitTime,GameObject obj)
    {
        yield return new WaitForSeconds(waitTime);
        holdObj = obj;
        holdObj.transform.position = holdPos.position;
        holdObj.transform.parent = this.gameObject.transform;

        playerState = PlayerState.Idle;

    }

    #endregion

    #region public 함수


    public void GetDamage()
    {
        playerState = PlayerState.Death;

        anim.SetBool("GameOver", true);
        Debug.Log("PlayerState : " + playerState);
    }

    #endregion
}
