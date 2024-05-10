using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class TitleMess : MonoBehaviour
{
    [SerializeField] Transform pos;
    [SerializeField] TextMeshProUGUI sr;

    [SerializeField] bool canTrigger = false;
    [SerializeField] ButtonMangaer startBt;
    [SerializeField] ButtonMangaer optionBt;
    [SerializeField] ButtonMangaer dicBt;

    [SerializeField] AutoColorChange aCC;
    [SerializeField] Light2D _light;
    [SerializeField] SpriteRenderer _lightRender;


    private void Start()
    {
        sr.color = new Color(0.1f, 0.27f, 0.27f);

        setTitled();
        _lightRender.color = new Color(1, 0.9f, 0.7f);
        _light.transform.localScale = new Vector3(0, 0f, 1);
    }

    public void setTitle()
    {
        if (canTrigger == true)
        {
            canTrigger = false;
            transform.DOScale(new Vector3(0.85f, 0.85f), 1.1f).OnComplete(()=> 
            {
                //aCC.AutoColor();
                LightSett();
            });
            transform.DOMove(pos.position, 1);
            sr.DOColor(new Color(0.7f, 0.85f, 0.85f), 1);
            
            startBt.Appear();
            //optionBt.Appear();
            dicBt.Appear();
        }   
    }

    private void Update()
    {
        _light.color = _lightRender.color;
        _light.intensity = _light.transform.localScale.y;
        _light.pointLightOuterRadius = _light.transform.localScale.x;
        
    }


    #region ²¨Á®
    void AutoIntensitySmall()
    {
        _light.transform.DOScaleY(Random.Range(0.4f, 0.66f), Random.Range(0.1f, 3)).SetEase(Ease.OutCubic)
            .OnComplete(() => AutoIntensityBig());
    }
    void AutoIntensityBig()
    {
        _light.transform.DOScaleY(Random.Range(0.8f, 1.3f), Random.Range(0.1f, 3)).SetEase(Ease.OutCubic)
            .OnComplete(() => AutoIntensitySmall());
    }

    void AutoOuterRadiusBig()
    {
        _light.transform.DOScaleX(Random.Range(7, 10f), Random.Range(1f, 5)).SetEase(Ease.OutCubic)
            .OnComplete(() => AutoOuterRadiusSmall());
    }

    void AutoOuterRadiusSmall()
    {
        _light.transform.DOScaleX(Random.Range(3, 6f), Random.Range(1f, 5)).SetEase(Ease.OutCubic)
            .OnComplete(() => AutoOuterRadiusBig());
    }
    #endregion
    void AutoLight()
    {
        AutoOuterRadiusBig();
        AutoIntensityBig();
    }

    void LightSett()
    {
        _light.gameObject.SetActive(true);
        _light.transform.DOScale(new Vector3(5, 0.5f, 1), 1f).OnComplete(() => AutoLight());
        _lightRender.DOColor(new Color(1, 0.7f, 0.7f), 5f).SetEase(Ease.InOutBounce).SetLoops(-1, LoopType.Yoyo);
    }

    void setTitled()
    {
        transform.DOMoveX(pos.position.x, 0.8f).SetEase(Ease.InQuart).OnComplete(() => canTrigger = true);
    }
}
