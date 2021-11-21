using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBoss : MonoBehaviour
{
    public string collect;

    private SpriteRenderer sr;

    [SerializeField] private Sprite[] mouth;
    private bool isActive;

    [SerializeField] private GameObject Icon;

    [SerializeField] private GameObject coll;

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject next;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        coll.SetActive(false);
        door.SetActive(false);
        next.SetActive(false);


    }
    // Update is called once per frame
    void Update()
    {
        CheckAnswer();
        ShowIcon(isActive);

    }

    private void CheckAnswer()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + new Vector3(-3, -1f, 0), Vector2.right, 6f, LayerMask.GetMask("Player"));
        Debug.DrawRay(transform.position + new Vector3(-3, -1f, 0), Vector2.right * 6f, Color.blue);

        if (ray)
        {

            if (ray.collider.gameObject.GetComponent<Player>().holdObj != null)
            {
                isActive = true;

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    StartCoroutine(changeImg());

                    if (collect.Equals(ray.collider.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name))
                    {
                        ray.collider.gameObject.GetComponent<Player>().isUse();
                        Debug.Log("is open");
                        CreateWord(ray.collider.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name,30f);
                    }
                    else
                    {
                        ray.collider.gameObject.GetComponent<Player>().isUse();
                        Debug.Log("notthing");
                        CreateWord(ray.collider.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name,10f);
                        Invoke("DamageColl",2f);
                    }
                }
                
            }
            else
                Debug.Log("don't have Key");

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
    IEnumerator changeImg()
    {
        Debug.Log("dnwls");

        sr.sprite = mouth[0];
        yield return new WaitForSeconds(1f);
        sr.sprite = mouth[1];

    }
    private void CreateWord(string objName ,float time)
    {
        GameObject go = Resources.Load("Prefabs/Word/"+objName) as GameObject;

        GameObject go2 = Instantiate(go, transform.position + new Vector3(-5,1,0), Quaternion.identity);

        Destroy(go2, time);
    }


    private void DamageColl()
    {
        coll.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("DamageToBoss"))
        {
            Debug.Log("damage");
            sr.sprite = null;

            door.SetActive(true);
            next.SetActive(true);

        }
    }
}
