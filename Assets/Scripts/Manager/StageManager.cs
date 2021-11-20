using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    #region SingleTon
    /* SingleTon */
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(StageManager)) as StageManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "StageManager";
                    instance = container.AddComponent(typeof(StageManager)) as StageManager;
                }
            }

            return instance;
        }
    }
    #endregion

    private static int StageNum;

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
        StageNum = 0;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(string stageName)
    {
        StageNum++;
        Debug.Log("Stage_" + StageNum);

        SceneManager.LoadScene(stageName);
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name + "으로 변경되었습니다.");

        UiManager.Instance.CallFadeIn();
    }

}
