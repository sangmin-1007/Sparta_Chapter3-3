using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MovingTitle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private RectTransform titleRectTransform;
    [SerializeField] private TextMeshProUGUI anyKeyText;

    private float time = 0f;
    private bool isOnText = false;
    void Start()
    {
        titleRectTransform.DOAnchorPosY(0,7).SetDelay(1.5f).SetEase(Ease.OutBounce);
        anyKeyText.DOFade(1.0f,2).SetDelay(8f).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time > 9f)
        {
            if(Input.anyKeyDown)
            {
                Debug.Log("씬 전환 시작");
            }
        }
    }


}
