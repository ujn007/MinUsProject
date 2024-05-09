using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneManagers : MonoBehaviour
{
    public void GameStart()
    {
        if(!ShyDic.isDic)
        SceneManager.LoadScene("Story");
    }
    [SerializeField] GameObject dic;
    public void Dic()
    {
        if (!ShyDic.isDic)
            dic.transform.DOScale(new Vector3(1,1), 0.7f).SetEase(Ease.InCirc).OnStart(() => dic.SetActive(true));

    }

    public void Option()
    {
        if (!ShyDic.isDic)
            Debug.Log("°³Â¼´Â ¼³Á¤");
    }

    public void offDic()
    {
        ShyDic.isDic = false;
        dic.transform.DOScale(Vector2.zero, 1).SetEase(Ease.InBounce).OnComplete(() => dic.SetActive(false));
    }
}
