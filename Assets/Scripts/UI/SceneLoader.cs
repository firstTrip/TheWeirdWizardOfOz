using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private CanvasGroup fadeCg;

    [Range(0.5f, 2.0f)]
    public float fadeDuration = 1.0f;

    // 호출할 씬과 씬로드 방식을 저장 할 딕셔너리 

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
        // 씬을 로드하고 로드가 완료뙬때까지 대기 
        yield return SceneManager.LoadSceneAsync(sceneName,mode);

        // 호출 된 씬 활성화
        Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(loadedScene);


    }

    //페이드 인 페이드 아웃
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
