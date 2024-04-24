using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : PlayerPieces
{
    private void Awake()
    {
        InitPiece();
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

    protected override void InitPiece()
    {
        SubEnergy = 2;
        pieceLevel = 0;
        pieceEXP = 0;
        pieceIndex = 2;
    }
}
