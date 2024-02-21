using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MovingTitle : MonoBehaviour
{
    [SerializeField] private RectTransform titleRectTransform;
    [SerializeField] private TextMeshProUGUI anyKeyText;

    private float time = 0f;

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
                time = 0f;
                LoadingSceneController.LoadScene("GameScene");
            }
        }
    }


}
