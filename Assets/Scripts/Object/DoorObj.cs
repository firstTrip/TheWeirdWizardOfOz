using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObj : MonoBehaviour
{

    public string objName =null;
    private bool isActive;

    public string StageString;

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

            if(ray.collider.gameObject.GetComponent<Player>().holdObj != null)
            {
                if (objName.Equals(ray.collider.gameObject.GetComponent<Player>().holdObj.GetComponent<ObjId>().name))
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        ray.collider.gameObject.GetComponent<Player>().isUse();
                        Debug.Log("is open");

                        UiManager.Instance.CallFadeOut();
                        StartCoroutine(OneSec());
                    }
                    
                }
                else
                    Debug.Log("notthin");
            }
            else
                Debug.Log("don't have Key");

        }
        else
        {
            isActive = false;

        }

        

    }
    IEnumerator OneSec()
    {

        yield return new WaitForSeconds(1f);
        StageManager.Instance.LoadScene(StageString);


    }
    private void ShowIcon(bool isActive)
    {
        Icon.SetActive(isActive);
    }

}
