using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Shy_Story : MonoBehaviour
{
    string[] texts =
    {
        "���� ����",
        "���̷����� ��踦 �Ǵ� ����",
        "...",
        "��! ���� ���̷����� �� ��������.",
        "�ƹ�ư",
        "�� ���� ���� �������� �𿩻�� ������ �ϳ� �־���ϴ�.",
        "������ �ֹε��� �����ӿ����� ������ ��������.",
        "�׷��� ��� ��",
        "������ ó������ ������ ���Խ��ϴ�.",
        "�ٷ� �ΰ��Դϴ�!",
        "������ ���ེ���Ե� �ΰ��鿡�� �־\n���� �ֹε��� �ݰ��� ���� ���翴�� ���ϴ�.",
        "�׵��� �� ���� �ΰ����� ������\n���� �ֹε��� ���Ƴ��� ������ �����Ϸ� �߽��ϴ�.",
        "�׷� �ΰ����� ���� ���� ��� \n���� �ֹε��� ���� ������� �߽��ϴ�.",
        "�׷��ϱ�...",
        "�ϵ� ������� ������ ���� �����!! �ΰ�����!!!"
    };

    public float[] cool;

    [SerializeField] TextMeshProUGUI textPos;
    [SerializeField] GameObject mobs;
    [SerializeField] GameObject people;
    [SerializeField] GameObject messageBox;

    private void Awake()
    {
        mobs.transform.localScale = Vector3.zero;
        people.transform.localScale = Vector3.zero;

        mobs.SetActive(false);
        people.SetActive(false);
    }

    [SerializeField] int StartNum = 0;
    private void Start()
    {
        StartCoroutine(ShowMes(StartNum));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Skip();
    }

    void Skip()
    {
        SceneManager.LoadScene("");
    }

    bool canNext = true;
    void AppearCharacter(GameObject obj, int _x)
    {
        canNext = false;
        obj.SetActive(true);
        obj.transform.DOScale(new Vector3(_x, 1), 1).OnComplete(() => canNext = true);
    }

    void Attack(GameObject obj, int _x)
    {
        canNext = false;
        obj.transform.DOLocalMoveX(_x, 1).OnComplete(() => obj.transform.DOLocalMoveY(100, 0.25f).SetLoops(4, LoopType.Yoyo).OnComplete(()=>canNext = true));
    }

    void Back()
    {
        Attack(mobs, 400);
        people.transform.DOLocalMove(new Vector3(800, 0), 1.15f);
    }


    IEnumerator ShowMes(int num)
    {
        textPos.text = "";
        if (num == 13)
            messageBox.transform.DOScale(new Vector2(1, 1), 0.5f).SetEase(Ease.Flash);

        int cnt = 0;
        while (cnt != texts[num].Length)
        {
            textPos.text += texts[num][cnt++].ToString();
            yield return new WaitForSeconds(0.075f);
        }

        if (num == 6) AppearCharacter(mobs, 1);
        if (num == 9) AppearCharacter(people, -1);
        if (num == 11) Attack(people, -400);
        if (num == 12) Back();
        

        yield return new WaitForSeconds(cool[num]);

        while (!canNext)
        {
            yield return new WaitForSeconds(0.001f);
        }

        if (++num < texts.Length) StartCoroutine(ShowMes(num));
        else Skip();
    }
}
