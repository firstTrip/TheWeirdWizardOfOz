using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbAction : MonoBehaviour
{
    
    // kinetic to dynamic or dynamic to kinetic


    [SerializeField] private GameObject obj;


    private Rigidbody2D rb;


    private bool isActive = false; // ����� �Ǿ��� ? ����� �ȵǾ��������(false)�� ���� 
    private void Action()
    {
        if (obj.GetComponent<Rigidbody2D>() && !isActive)
        {

            rb = obj.GetComponent<Rigidbody2D>();

            if (rb.bodyType == RigidbodyType2D.Kinematic)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;

            }
            else if (rb.bodyType == RigidbodyType2D.Dynamic)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;

            }


            isActive = true;

        }
    }

}
