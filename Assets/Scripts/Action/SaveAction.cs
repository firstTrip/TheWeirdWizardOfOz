using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAction : MonoBehaviour
{


   public void Action()
    {
        Debug.Log("into save");
        DataManager.Instance.Save();
    }
}
