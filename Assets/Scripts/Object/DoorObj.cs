using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObj : MonoBehaviour
{

    public string objName =null;
    private bool isActive;

    [SerializeField] private GameObject Icon;

    void Update()
    {
        ShowIcon(isActive);
        CheckPlayer();

    }

    private void CheckPlayer()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(-3, -0.5f, 0), Vector2.right, 6f, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position + new Vector3(-3, -0.5f, 0), Vector2.right * 6f, Color.blue);

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<Player>().holdObj !=null)
            {
                if(objName.Equals(collision.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name))
                {
                    collision.gameObject.GetComponent<Player>().isUse();
                    Debug.Log("is open");
                }
            }    
        }
    }
}
