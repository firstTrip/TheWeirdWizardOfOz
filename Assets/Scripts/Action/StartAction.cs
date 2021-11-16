using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAction : MonoBehaviour
{
    [SerializeField] private GameObject[] obj;

    private void Action()
    {

        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].GetComponent<ActionObj>().ObjStart();
        }
    }
}
