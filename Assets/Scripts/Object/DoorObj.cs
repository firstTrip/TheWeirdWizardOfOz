using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObj : MonoBehaviour
{

    public string objName =null;

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
