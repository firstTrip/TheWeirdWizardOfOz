using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeObj : MonoBehaviour
{

    private SpriteRenderer sr;

    public float fadeInTime =0.5f;
    public float fadeA = 0.95f;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();


        StartCoroutine(fadeIn(fadeInTime));
    }

    IEnumerator fadeIn(float fadeInTime)
    {
        Color tempColor = sr.color;

        while(true)
        {
            while (tempColor.a < fadeA)
            {
                tempColor.a += Time.deltaTime / (fadeInTime /2);

                sr.color = tempColor;

                if (tempColor.a >= fadeA)
                    tempColor.a = fadeA;

                yield return null;
            }

            sr.color = tempColor;


            yield return new WaitForSeconds(2f);

            while (tempColor.a > 0f)
            {
                tempColor.a -= Time.deltaTime / fadeInTime;

                sr.color = tempColor;

                if (tempColor.a <= 0f)
                    tempColor.a = 0f;

                yield return null;
            }

            sr.color = tempColor;

        }
    }
        


}
