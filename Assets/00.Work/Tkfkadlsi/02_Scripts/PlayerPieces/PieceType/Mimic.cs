using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mimic : PlayerPieces
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
            //�� ��� ����
            pieceManager.PCLevel(1, this);
            Destroy(collision.gameObject);
        }
    }

    protected override void Init()
    {
        base.Init();
        pieceIndex = 1;
    }
}
