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
        Debug.Log("와 개쩌는 게임!");
        //SceneManager.LoadScene("InGame");
    }
    [SerializeField] GameObject dic;
    public void Dic()
    {
        if (!ShyDic.isDic)
            dic.transform.DOScale(new Vector3(1,1), 1).SetEase(Ease.InBounce).OnStart(() => dic.SetActive(true));

    }

    public void Option()
    {
        if (!ShyDic.isDic)
            Debug.Log("개쩌는 설정");
    }

    public void offDic()
    {
        ShyDic.isDic = false;
        dic.transform.DOScale(Vector2.zero, 1).SetEase(Ease.InBounce).OnComplete(() => dic.SetActive(false));
    }
}
