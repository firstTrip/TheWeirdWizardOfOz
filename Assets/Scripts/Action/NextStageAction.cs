using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStageAction : MonoBehaviour
{

    public string stageName;
    private void Action()
    {
        UiManager.Instance.CallFadeOut();

        Invoke("NextStage", 1f);
    }

    private void NextStage()
    {
        StageManager.Instance.LoadScene(stageName);
    }
}
