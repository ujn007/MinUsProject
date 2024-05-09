using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShyDic : MonoBehaviour
{
    [SerializeField] List<DicSO> pc;

    static int page;

    public static bool isDic = false;

    [SerializeField] Image visualPos;
    [SerializeField] Image moveWayPos;
    [SerializeField] TextMeshProUGUI namePos;
    [SerializeField] TextMeshProUGUI lifePos;
    [SerializeField] TextMeshProUGUI explainPos;
    [SerializeField] TextMeshProUGUI useValuePos;
    [SerializeField] TextMeshProUGUI developExplainPos;

    [SerializeField] GameObject plusBt;
    [SerializeField] GameObject minusBt;

    private void Start()
    {
        page = 0;
    }

    private void OnEnable()
    {
        ShowPage();
    }

    private void ShowPage()
    {
        isDic = true;
        namePos.text = pc[page].name;
        moveWayPos.sprite = pc[page].moveWay;
        visualPos.sprite = pc[page].visual;
        explainPos.text = "그 외 특징" + explainSet();
        developExplainPos.text = "진화 조건 : " + pc[page].develop;
        useValuePos.text = "행동력 " + pc[page].useValue;

        if (page == 0) minusBt.SetActive(false);
        else if (page == pc.Count - 1) plusBt.SetActive(false);
        else
        {
            plusBt.SetActive(true);
            minusBt.SetActive(true);
        }
    }

    public void movePage(int _value)
    {
        page += _value;
        Debug.Log("wa");
        ShowPage();
    }

    string explainSet()
    {
        string mes = "";

        for (int i = 0; i < pc[page].expain.Count; i++)
        {
            mes += "\n - " + pc[page].expain[i];
        }

        return mes;
    }
}
