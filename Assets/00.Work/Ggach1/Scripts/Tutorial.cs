using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] _explain; //����
    [SerializeField] private GameObject _Next; //����

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
        _explain[i].SetActive(false); //���� UI����
        i++;


        if (i >= _explain.Length) return;


        _explain[i].SetActive(true); //���� UIŰ��
    }
}
