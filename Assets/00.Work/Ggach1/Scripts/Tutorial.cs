using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] _explain; //설명
    [SerializeField] private GameObject _Next; //다음

    private void Awake()
    {

        for (int i = 0; i < _explain.Length; i++)
        {
            _explain[i].SetActive(false);
        }

    }

    private void Start()
    {
        _explain[0].SetActive(true);

    }

    int i = 0;

    public void PassBtn()
    {
        _explain[i].SetActive(false); //현재 UI끄고
        i++;


        if (i >= _explain.Length) return;


        _explain[i].SetActive(true); //다음 UI키기
    }
}
