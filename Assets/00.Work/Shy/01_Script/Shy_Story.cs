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
        "옛날 옛적",
        "스켈레톤이 담배를 피던 시절",
        "...",
        "아! 물론 스켈레톤은 폐가 없지만요.",
        "아무튼",
        "그 시절 여러 종족들이 모여살던 던전이 하나 있었답니다.",
        "던전의 주민들은 던전속에서만 조용히 지냈지요.",
        "그러던 어느 날",
        "던전에 처음보는 종족이 들어왔습니다.",
        "바로 인간입니다!",
        "하지만 불행스럽게도 인간들에게 있어서\n던전 주민들은 반갑지 않은 존재였나 봅니다.",
        "그들은 곧 여러 인간들을 보내서\n던전 주민들을 몰아내고 던전을 점거하려 했습니다.",
        "그런 인간들을 보고 원래 살던 \n던전 주민들은 힘을 모으기로 했습니다.",
        "그러니까...",
        "니들 마음대로 던전에 오지 말라고!! 인간놈들아!!!"
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
