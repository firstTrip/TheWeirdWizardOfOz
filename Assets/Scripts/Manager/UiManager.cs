using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // 페이드 인 / 페이드 아웃
    // 퍼즈 화면 불러오기 보내기 
    // 버튼 클릭시 불러오기? 
    // 

    [SerializeField] private Image fadeImg;
    [SerializeField] private GameObject PauseImg;
    [SerializeField] private GameObject ReStartImg;
    #region SingleTon
    /* SingleTon */
    private static UiManager instance;

    
    public static UiManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(UiManager)) as UiManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "UiManager";
                    instance = container.AddComponent(typeof(UiManager)) as UiManager;
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
    }

    private bool isActive = false;
    private bool isReStart = false;
    // Start is called before the first frame update
    void Start()
    {
        PauseImg.SetActive(false);
        ReStartImg.SetActive(false);
    }

    public void Continue()
    {
        Debug.Log("is it");
        GameManager.Instance.GameGo();
    }

    public void CallPause()
    {
        isActive = !isActive;
        if(isActive)
            PauseImg.SetActive(true);
        else
            PauseImg.SetActive(false);


    }

    public void Main()
    {
        StageManager.Instance.LoadScene("Main");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ReStart()
    {
        isReStart = !isReStart;

        if (isReStart)
            ReStartImg.SetActive(true);
        else
            ReStartImg.SetActive(false);

    }

    public void CallFadeIn()
    {
        StartCoroutine(FadeIn(1f));

    }

    public void CallFadeOut()
    {
        StartCoroutine(FadeOut(1f));

    }
    IEnumerator FadeOut(float fadeInTime)
    {
        Color tempColor = fadeImg.color;


        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / (fadeInTime / 2);

            fadeImg.color = tempColor;

            if (tempColor.a >= 1f)
                tempColor.a = 1f;

            yield return new WaitForSeconds(0.01f);
        }

        fadeImg.color = tempColor;

        yield return new WaitForSeconds(2f);


    }

    IEnumerator FadeIn (float fadeInTime)
    {
        Color tempColor = fadeImg.color;

        yield return new WaitForSeconds(1f);

        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeInTime;

            fadeImg.color = tempColor;

            if (tempColor.a <= 0f)
                tempColor.a = 0f;

            yield return null;
        }

        fadeImg.color = tempColor;
    }
}
