using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBoss : MonoBehaviour
{
    public string collect;


    // Update is called once per frame
    void Update()
    {
        CheckAnswer();
    }

    private void CheckAnswer()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(-3, -0.5f, 0), Vector2.right, 6f, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position + new Vector3(-3, -0.5f, 0), Vector2.right * 6f, Color.blue);

        if (ray)
        {

            if (ray.collider.gameObject.GetComponent<Player>().holdObj != null)
            {

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (collect.Equals(ray.collider.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name))
                    {
                        ray.collider.gameObject.GetComponent<Player>().isUse();
                        Debug.Log("is open");
                        CreateWord(ray.collider.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name);
                    }
                    else
                    {
                        ray.collider.gameObject.GetComponent<Player>().isUse();
                        Debug.Log("notthing");
                        CreateWord(ray.collider.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name);

                    }
                }
                
            }
            else
                Debug.Log("don't have Key");

        }
        else
        {

        }


    }

    private void CreateWord(string objName)
    {
        GameObject go = Resources.Load("Prefabs/Word/"+objName) as GameObject;

        GameObject go2 = Instantiate(go, transform.position, Quaternion.identity);

        Destroy(go2, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DamageToBoss"))
        {
            Destroy(gameObject);
        }
    }
}
