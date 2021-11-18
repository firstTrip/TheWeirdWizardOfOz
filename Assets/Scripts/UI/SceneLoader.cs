using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private CanvasGroup fadeCg;

    [Range(0.5f, 2.0f)]
    public float fadeDuration = 1.0f;

    // ȣ���� ���� ���ε� ����� ���� �� ��ųʸ� 

    public Dictionary<string, LoadSceneMode> loadScenes = new Dictionary<string, LoadSceneMode>();

    void InitSrcneInfo()
    {
        loadScenes.Add("Main", LoadSceneMode.Additive);
        loadScenes.Add("Test_WJ", LoadSceneMode.Additive);

    }


    // Start is called before the first frame update
    IEnumerator Start()
    {
        InitSrcneInfo();

        fadeCg.alpha = 1.0f; //black

        foreach(var _loadScene in loadScenes)
        {
            yield return StartCoroutine(LoadScene(_loadScene.Key,_loadScene.Value));
        }

         StartCoroutine(Fade(0.0f));

    }

    IEnumerator LoadScene(string sceneName ,LoadSceneMode mode)
    {
        // ���� �ε��ϰ� �ε尡 �Ϸጯ������ ��� 
        yield return SceneManager.LoadSceneAsync(sceneName,mode);

        // ȣ�� �� �� Ȱ��ȭ
        Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(loadedScene);


    }

    //���̵� �� ���̵� �ƿ�
    IEnumerator Fade(float finalAlpha)
    {


        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Main"));
        fadeCg.blocksRaycasts = true;
        SceneManager.UnloadSceneAsync("Main");


        yield return new WaitForSeconds(1f);


        float fadeSpeed = Mathf.Abs(fadeCg.alpha - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(fadeCg.alpha,finalAlpha))
        {
            fadeCg.alpha = Mathf.MoveTowards(fadeCg.alpha, finalAlpha,fadeSpeed * Time.deltaTime);
            yield return null;

        }

        fadeCg.blocksRaycasts = false;

        SceneManager.UnloadSceneAsync("SceneLoader");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
