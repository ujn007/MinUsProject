using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    Dictionary<int, string> dictionary = new Dictionary<int, string>();
    private object ASDF;

    private void Awake()
    {
        ASDF = TMananger.instance;
        dictionary.Add(1, "����� 4��");
        dictionary.Add(2, "ö�� ������ �� ��ȣ��");
    }

    private void Start()
    {
        Debug.Log(dictionary[2]);
    }

}
