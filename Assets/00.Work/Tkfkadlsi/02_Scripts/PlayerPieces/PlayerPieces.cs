using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PlayerPieces : MonoBehaviour, IPointerClickHandler
{
    public SelectPieces selectPieces;
    public PlayerEnergy playerEnergy;
    public PieceSO techLineSO;
    protected MovePoint[] movePoints;
    protected GameObject movePointTrm;
    protected GameUI pieceManager;

    public int SubEnergy { get; protected set; }
    public int pieceLevel { get; protected set; }
    public int pieceHP { get; protected set; }
    public int pieceIndex { get; set; }
    public int pieceEXP { get; set; }

    private void Start()
    {
        selectPieces = FindObjectOfType<SelectPieces>();
        playerEnergy = FindObjectOfType<PlayerEnergy>();
        pieceManager = FindObjectOfType<GameUI>();
        SetMovePoint(pieceLevel);
    }

    protected abstract void InitPiece();

    private void SetMovePoint(int level)
    {
        Destroy(movePointTrm);
        GameObject newMovepoints = Instantiate(techLineSO.movePoints[level], transform.position, Quaternion.identity);
        movePointTrm = newMovepoints;
        movePointTrm.SetActive(false);
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

    public void HitPiece(int damage)
    {
        pieceHP -= damage;
        
    }

    public void LevelUp()
    {
        pieceLevel++;
        SetMovePoint(pieceLevel);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //적 잡기 구현
            pieceManager.PCLevel(1, this);
        }
    }
}