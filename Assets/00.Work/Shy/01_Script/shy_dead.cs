using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class shy_dead : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private GameObject skel;
    [SerializeField] private GameObject human;
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject bt;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = skel.GetComponent<SpriteRenderer>();
    }

    void Start()
    {   
        tmp.transform.DOScale(new Vector2(1, 1), 2.5f).SetEase(Ease.OutElastic, 1);
        tmp.transform.DOLocalMoveY(300, 1.3f).OnComplete(() => SurAnime());
    }

    void SurAnime()
    {
        skel.transform.DOLocalMoveY(-1, 0.4f).SetLoops(2, LoopType.Yoyo).OnComplete(()=> skel.transform.DOLocalMove(skel.transform.position, 0.5f).OnComplete(() => RunAnime()));
    }

    void RunAnime()
    {
        sr.flipX = true;
        skel.transform.DOLocalMoveX(-11, 3f).OnStart(()=>EnemyMoveAnime());
    }

    private void EnemyMoveAnime()
    {
        transform.DOMove(transform.position, 0.3f).OnComplete(()=> human.transform.DOMoveX(transform.position.x - 0.6f, 2.8f).
        OnComplete(()=>human.transform.DOLocalMoveY(-1, 0.3f).SetLoops(4, LoopType.Yoyo).OnComplete(()=>UIAnimation()))).
            OnStart(()=>human.transform.DORotate(new Vector3(0,0,-5f), 0.3f).SetLoops(10, LoopType.Yoyo).
            OnComplete(()=>human.transform.DORotate(Vector3.zero, 0.3f)));
    }

    private void UIAnimation()
    {
        score.transform.DOScale(new Vector3(1, 1, 1), 0.7f).OnComplete(()=>bt.transform.DOScale(new Vector3(1,1,1), 0.7f));
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
