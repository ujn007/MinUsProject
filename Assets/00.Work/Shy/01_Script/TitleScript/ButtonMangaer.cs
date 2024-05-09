using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonMangaer : MonoBehaviour
{
    TextMeshProUGUI _text;

    [SerializeField] bool isText;

    private void Awake()
    {
        if (isText)
            _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Appear()
    {
        transform.DOScale(new Vector2(1,1), 1.2f).SetEase(Ease.InOutCirc);
        if (isText) _text.DOFade(1, 1).SetEase(Ease.OutSine);
    }

    private void OnMouseEnter()
    {
        if (isText && !ShyDic.isDic) _text.color = new Color(1, 1, 0.85f);
    }

    private void OnMouseExit()
    {
        if (isText && !ShyDic.isDic) _text.color = new Color(0.4f,0.4f,0.5f);
    }
}
