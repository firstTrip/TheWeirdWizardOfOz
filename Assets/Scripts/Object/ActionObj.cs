using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionObj : MonoBehaviour
{
    protected bool isActive = false; // ������ �ȵǰ� ������� true �϶� ��밡��

    public enum ObjectType 
    {
        Grab,
        Obstacle,
        Boss
    }

    public ObjectType objectType;

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
