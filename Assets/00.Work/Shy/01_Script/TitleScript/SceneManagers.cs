using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneManagers : MonoBehaviour
{
    public void GameStart()
    {
        Debug.Log("�� ��¼�� ����!");
        //SceneManager.LoadScene("InGame");
    }
    [SerializeField] GameObject dic;
    public void Dic()
    {
        dic.transform.DOScale(new Vector3(1,1), 1).SetEase(Ease.InBounce).OnStart(() => dic.SetActive(true));

    }

    public void Option()
    {
        Debug.Log("��¼�� ����");
    }

    public void offDic()
    {
        dic.transform.DOScale(Vector2.zero, 1).SetEase(Ease.InBounce).OnComplete(() => dic.SetActive(false));
    }
}
