using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;


public class TimeLineManager : MonoBehaviour
{

    public PlayableDirector pd;

    public GameObject player;

    #region SingleTon
    /* SingleTon */
    private static TimeLineManager instance;
    public static TimeLineManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(TimeLineManager)) as TimeLineManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "TimeLineManager";
                    instance = container.AddComponent(typeof(TimeLineManager)) as TimeLineManager;
                }
            }

            return instance;
        }
    }
    #endregion


    void Awake()
    {
        #region SingleTon
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        #endregion

        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void TimeLinePlay()
    {
        pd.gameObject.SetActive(true);
        pd.Play();
    }

    public void play()
    {
 
        Debug.Log("init");
        player.transform.DOMoveX(player.transform.position.x + 2,3f);

    }
}
