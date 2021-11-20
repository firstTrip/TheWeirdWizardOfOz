using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    #region SingleTon
    /* SingleTon */
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(GameManager)) as GameManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "GameManager";
                    instance = container.AddComponent(typeof(GameManager)) as GameManager;
                }
            }

            return instance;
        }
    }
    #endregion

    public GameObject Player;

    public enum GameState
    {
        Pause,
        Process
    }

    public GameState gameState;


    private bool Flag =false;
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

        Player = GameObject.FindGameObjectWithTag("Player");


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            DataManager.Instance.Load();
            //UiManager.Instance.CallFadeIn();
        }

        GamePause();
        GameCondition();
        ReStart();
    }

    public void GamePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Flag = !Flag;
            UiManager.Instance.CallPause();
            Debug.Log("Game Pause ");
        }
    }

    public void GameGo()
    {
        Flag = !Flag;
        UiManager.Instance.CallPause();
        Debug.Log("Game Pause ");
    }

    public void ReStart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StageManager.Instance.ReLoad();
            Debug.Log("Reload");
        }
    }

    public void InitPlayer()
    {
        Player.GetComponent<Player>().ResetPlayer();
    }
    void GameCondition()
    {
        if (Flag)
            Time.timeScale = 0;
        else if(!Flag)
            Time.timeScale = 1;
    }
}
