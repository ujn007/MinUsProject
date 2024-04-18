using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PlayerPieces : MonoBehaviour, IPointerClickHandler
{
    public SelectPieces selectPieces;
    public PlayerEnergy playerEnergy;
    public PieceTechLineSO techLineSO;
    protected MovePoint[] movePoints;
    protected GameObject movePointTrm = new GameObject();
    protected GameUI pieceManager;

    public int SubEnergy { get; protected set; }
    public int pieceIndex;
    protected int pieceLevel = 0;
    
    private void Start()
    {
        selectPieces = FindObjectOfType<SelectPieces>();
        playerEnergy = FindObjectOfType<PlayerEnergy>();
        pieceManager = FindObjectOfType<GameUI>();
        SetMovePoint(pieceLevel);
    }

    private void SetMovePoint(int level)
    {
        Destroy(movePointTrm);
        GameObject newMovepoints = Instantiate(techLineSO.movePoints[level], transform.position, Quaternion.identity);
        newMovepoints.SetActive(false);
        movePointTrm = newMovepoints;
        movePoints = newMovepoints.GetComponentsInChildren<MovePoint>();
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

    public void Evolution()
    {
        pieceLevel++;
        SetMovePoint(pieceLevel);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            //적 잡기 구현
            switch(pieceIndex)
            {
                case 1:
                    pieceManager.P1Level(1, this);
                    break;
                case 2:
                    pieceManager.P2Level(1, this);
                    break;
                case 3:
                    pieceManager.P3Level(1, this);
                    break;
            }
            
        }
    }
}