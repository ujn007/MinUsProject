using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Skeleton : PlayerPieces
{
    private void Awake()
    {
        Init();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (TMananger.instance.CurrnetState != GameState.PlayerTurn) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = Vector2.Distance(mousePos, transform.position);
        if (distance < 0.5f * TMananger.instance.tileScale)
        {
            MovePointONOFF();
            selectPieces.SelectNewPiece(gameObject);
            return;
        }
    }

    public override void OnCollision2DEnter(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //적 잡기 구현
            pieceManager.PCLevel(1, this);
            Destroy(collision.gameObject);
            UseSkill();
        }
    }

    private void UseSkill()
    {
        if (!mySkill.GetIsSkillOn(pieceLevel)) return;
        mySkill.Skill();
    }

    protected override void Init()
    {
        base.Init();
        pieceIndex = 2;
    }
}
