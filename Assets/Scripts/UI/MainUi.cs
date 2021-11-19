using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{

    [SerializeField] private Image fadeImg;
    [SerializeField] private GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        //fadeImg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTest_WJ()
    {

        SceneManager.LoadScene("Stage_1");
        /*
        button.gameObject.SetActive(false);
        StartCoroutine(FadeIn());
        */
    }

    IEnumerator FadeIn()
    {
        float fadeCnt = 0f;

        while(fadeCnt<1.0f)
        {
            Debug.Log("into");
            fadeCnt += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeImg.color = new Color(0, 0, 0, fadeCnt);
        }

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("SceneLoader");

    }
}
