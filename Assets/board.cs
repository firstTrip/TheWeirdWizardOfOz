using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{

    private bool isActive =false;

    [SerializeField] private GameObject Icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowIcon(isActive);
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(-3, -3f, 0), Vector2.right, 6f, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position + new Vector3(-3, -3f, 0), Vector2.right * 12f, Color.blue);

        if (ray)
        {
            isActive = true;
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
