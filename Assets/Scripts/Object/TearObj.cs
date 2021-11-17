using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TearObj : MonoBehaviour
{

    [SerializeField] private GameObject tear =null;
    [SerializeField] float ShakeDuration = 1;

    [SerializeField] private float coolTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TearDrop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TearDrop()
    {

        while(true)
        {
            GameObject go = Instantiate(tear, transform.position, Quaternion.identity);

            go.transform.DOShakePosition(1f);
            yield return new WaitForSeconds(coolTime);

            go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            Destroy(go, 3f);

            yield return new WaitForSeconds(coolTime*2);
        }
        
    }
}
