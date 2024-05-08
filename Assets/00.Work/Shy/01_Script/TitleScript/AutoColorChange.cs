using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AutoColorChange : MonoBehaviour
{
    Image _color;
    private void Awake()
    {
        _color = GetComponent<Image>();
    }

    public void AutoColor()
    {
        _color.color = new Color(0.75f, 0.75f, 0.8f);
        _color.DOColor(new Color(0.9f, 0.9f, 0.9f), 5).SetLoops(-1,LoopType.Yoyo);
    }
}
