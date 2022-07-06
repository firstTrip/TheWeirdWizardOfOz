using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class TextManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textName = null;
    [SerializeField] private TextMeshProUGUI talk = null;
    [SerializeField] private string nowtextName = null;


    [SerializeField] private int idx =0;
    [SerializeField] private int nowId = 0;



    private static TextManager instance;

    public static TextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(TextManager)) as TextManager;
                if (!instance)
                {
                    GameObject container = new GameObject();
                    container.name = "TextManager";
                    instance = container.AddComponent(typeof(TextManager)) as TextManager;
                }
            }

            return instance;
        }
    }
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (UiManager.Instance.TextUI.gameObject.activeSelf)
        {
            Debug.Log("into");

            if (Input.anyKeyDown)
            {
                idx++;
                DoTalk(nowId, nowtextName);
            }
        }
        
    }

    public void DoTalk(int id,string name)
    {
        switch (id+idx)
        {
            // stage_0 오즈 독백

            case 5000:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "안녕?? \n 난 이 땅의 주인이자 만물의 창조주란다.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5001:
                textName.text = name;
                talk.text = "너가 내 땅에 침범을 하여\n 내 수하인 마녀를 죽였단다.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5002:
                textName.text = name;
                talk.text = "싫다고??  \n 내가 한가지 기회를 주마 앞으로 가다 보면 너가 해야할 일이 보일거야.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5003:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;

            // 스테이지 1 독백
            case 5100:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "앞으로 가면 되는걸까?? \n 저 가시는 너무 아파 보이는대....";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5101:
                textName.text = name;
                talk.text = "집에 가고싶다.. 보고싶어... \n 엄마..";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5102:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;

            // 스테이지 2 독백
            case 5200:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "집으로 가기 위해선 앞으로 나아가야만해 \n 난 할 수 있어 꼭 집에 가고야 말거야";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5201:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;


            // 스테이지 3 독백
            case 5300:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "뛰어!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5301:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;



            // 스테이지 4 독백
            case 5400:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "바람이 나오네?? \n 잘 이용하면 저 높은곳을 올라갈 수 있을것 같아";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5401:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;




            // 게시판
            case 100:
                nowId = id;
                nowtextName = name;

                textName.text = name;
                talk.text = "난 이 땅의 주인 오즈라고 한다.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 101:

                textName.text = name;
                talk.text = "너의 죄를 사해주고 살려줄테니 너는 여행을 떠나 \n 발 , 손 , 입 , 눈 , 심장을 찾아 오면 집으로 갈 수 있다.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 102:

                textName.text = name;
                talk.text = "자 이제 부터 너의 죄를 즐겨보렴.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 103:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;


            // 입
            case 200:
                nowId = id;
                nowtextName = name;

                textName.text = name;
                talk.text = "나에게 맞는 단어를 가져와 나에게  먹여주거라";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 201:

                textName.text = name;
                talk.text = "그러면 너는 열쇠를  줄것이다.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 202:

                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;

               
        }

    }
}
