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
            // stage_0 ���� ����

            case 5000:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "�ȳ�?? \n �� �� ���� �������� ������ â���ֶ���.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5001:
                textName.text = name;
                talk.text = "�ʰ� �� ���� ħ���� �Ͽ�\n �� ������ ���ฦ �׿��ܴ�.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5002:
                textName.text = name;
                talk.text = "�ȴٰ�??  \n ���� �Ѱ��� ��ȸ�� �ָ� ������ ���� ���� �ʰ� �ؾ��� ���� ���ϰž�.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5003:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;

            // �������� 1 ����
            case 5100:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "������ ���� �Ǵ°ɱ�?? \n �� ���ô� �ʹ� ���� ���̴´�....";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5101:
                textName.text = name;
                talk.text = "���� ����ʹ�.. ����;�... \n ����..";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5102:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;

            // �������� 2 ����
            case 5200:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "������ ���� ���ؼ� ������ ���ư��߸��� \n �� �� �� �־� �� ���� ����� ���ž�";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5201:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;


            // �������� 3 ����
            case 5300:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "�پ�!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5301:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;



            // �������� 4 ����
            case 5400:
                nowId = id;
                nowtextName = name;
                textName.text = name;
                talk.text = "�ٶ��� ������?? \n �� �̿��ϸ� �� �������� �ö� �� ������ ����";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 5401:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;




            // �Խ���
            case 100:
                nowId = id;
                nowtextName = name;

                textName.text = name;
                talk.text = "�� �� ���� ���� ������ �Ѵ�.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 101:

                textName.text = name;
                talk.text = "���� �˸� �����ְ� ������״� �ʴ� ������ ���� \n �� , �� , �� , �� , ������ ã�� ���� ������ �� �� �ִ�.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 102:

                textName.text = name;
                talk.text = "�� ���� ���� ���� �˸� ��ܺ���.";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 103:
                UiManager.Instance.TextUI.SetActive(false);
                idx = 0;
                nowId = 0;
                break;


            // ��
            case 200:
                nowId = id;
                nowtextName = name;

                textName.text = name;
                talk.text = "������ �´� �ܾ ������ ������  �Կ��ְŶ�";
                TMProUGUIDoText.DoText(talk, 1f);
                break;

            case 201:

                textName.text = name;
                talk.text = "�׷��� �ʴ� ���踦  �ٰ��̴�.";
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
