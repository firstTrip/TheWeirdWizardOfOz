using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObj : MonoBehaviour
{
    protected bool isActive = false; // 시작이 안되게 만들어짐 true 일때 사용가능

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;


    }

    public virtual void ObjStart()
    {

        isActive = true;
        Debug.Log(gameObject.name + "is Start");
    }

}
