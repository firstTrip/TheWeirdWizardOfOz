using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveToXBlock : MonoBehaviour
{

    [SerializeField] float EndValue = 3;
    [SerializeField] float Duration = 3;
    [SerializeField] float ShakeDuration = 1;

    [Space]
    [Header("���� ���� ����")]
    [Tooltip("Y ������ �̵��ϴ°�")] public bool isStart;
    [Tooltip("���� �ϴ°�")] public bool isVibration;
    [Space]
    [Header("���� Ÿ��")]
    [Tooltip("�̵� ���")] public Ease ease;
    [Space]

    [Header("�ݺ� ����")]
    [Tooltip("üũ�� ���")] public bool isLoop;
    [Space]
    [Header("���� Ÿ��")]
    [Tooltip("���� Ÿ�� reStart �ϰ�� ó������ ���� , yoyo �ϰ�� ���ƿ� ���� �ݺ�, increment �ϰ�� ������ ����")] public LoopType loopType;

    private int loopNum;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLoop)
        {
            loopNum = 0;
        }
        else
        {
            loopNum = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isStart)
        {
            if (isVibration)
            {
                transform.DOShakePosition(ShakeDuration);
                isVibration = false;
            }
            transform.DOMoveX(this.transform.position.x + EndValue, Duration).SetEase(ease).SetLoops(loopNum, loopType);
            isStart = false;
        }

    }

    public void PauseBlock()
    {
        DOTween.PauseAll();
    }

}

