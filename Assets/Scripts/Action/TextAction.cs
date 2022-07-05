using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAction : MonoBehaviour
{
    public int id;
    public string name;

    public void Action()
    {
        if (UiManager.Instance.TextUI.gameObject.activeSelf)
            return;

        UiManager.Instance.TextUI.SetActive(true);
        TextManager.Instance.DoTalk(id, name);
    }
}
