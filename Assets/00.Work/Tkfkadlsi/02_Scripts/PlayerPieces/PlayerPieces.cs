using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PlayerPieces : MonoBehaviour, IPointerClickHandler
{
    public SelectPieces selectPieces;
    public PlayerEnergy playerEnergy;
    protected MovePoint[] movePoints;
    protected GameObject movePointTrm;
    protected GameUI pieceManager;

    public int SubEnergy { get; protected set; }
    public int pieceIndex;
    
    private void Start()
    {
        selectPieces = FindObjectOfType<SelectPieces>();
        playerEnergy = FindObjectOfType<PlayerEnergy>();
        pieceManager = FindObjectOfType<GameUI>();
        SetMovePoint(movePointTrm);
    }

    private void SetMovePoint(GameObject newMovepointTrm)
    {
        movePoints = newMovepointTrm.GetComponentsInChildren<MovePoint>();
    }

    public void MovePointONOFF(bool compulsionOff = false)
    {
        if (compulsionOff)
        {
            movePointTrm.SetActive(false);
            return;
        }
        else
        {
            movePointTrm.SetActive(!movePointTrm.activeSelf);
            foreach (MovePoint movePoint in movePoints)
            {
                movePoint.SelectedParentPiece();
            }
        }
    }

    public abstract void OnPointerClick(PointerEventData eventData);

    public void MovePiece()
    {
        playerEnergy.MinusEnergy(SubEnergy);
    }

    public void Evolution(GameObject newMovepointObject)
    {
        movePointTrm = newMovepointObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //적 잡기 구현
            switch(pieceIndex)
            {
                case 1:
                    pieceManager.P1Level(1);
                    break;
                case 2:
                    pieceManager.P2Level(1);
                    break;
                case 3:
                    pieceManager.P3Level(1);
                    break;
            }
            
        }
    }
}