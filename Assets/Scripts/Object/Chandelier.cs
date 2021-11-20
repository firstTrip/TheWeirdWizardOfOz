using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour
{

    private bool isActive;

    [SerializeField] private GameObject Icon;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        CheckAnswer();
        ShowIcon(isActive);

    }

    private void CheckAnswer()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(-5, -3f, 0), Vector2.right, 10f, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position + new Vector3(-5, -3f, 0), Vector2.right * 10f, Color.blue);

        if (ray)
        {
            isActive = true;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.bodyType = RigidbodyType2D.Dynamic;

            }


        }
        else
        {
            isActive = false;

        }


    }

    private void ShowIcon(bool isActive)
    {
        Icon.SetActive(isActive);
    }
}
