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
    protected PieceSkill mySkill;

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
        mySkill = GetComponent<PieceSkill>();
        SetMovePoint(pieceLevel);
    }

    protected abstract void InitPiece();

    private void SetMovePoint(int level)
    {
        Destroy(movePointTrm);
        GameObject newMovepoints = Instantiate(techLineSO.movePoints[level], transform);
        movePointTrm = newMovepoints;
        movePointTrm.SetActive(false);
        movePoints = newMovepoints.GetComponentsInChildren<MovePoint>();
    }

    private void SetVisual(int level)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (techLineSO.visual[level] != null)
            spriteRenderer.sprite = techLineSO.visual[level];
    }

    private void SetSubEnergy(int level)
    {
        SubEnergy = techLineSO.ConsumptionValue[level];
    }

    public void MovePointONOFF(bool compulsionOff = false)
    {
        if(selectPieces.isLockSelectPiece)
        {
            movePointTrm.SetActive(true);
            foreach (MovePoint movePoint in movePoints)
            {
                movePoint.SelectedParentPiece();
            }
            return;
        }

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
        if (selectPieces.isLockSelectPiece)
        {
            selectPieces.UnLockPiece();
            return;
        }
        playerEnergy.MinusEnergy(SubEnergy);
    }

    public void HitPiece(int damage)
    {
        pieceHP -= damage;
        pieceManager.PChpchange(this);
    }

    public void HealPiece(int healValue)
    {
        pieceHP += healValue;
        pieceManager.PChpchange(this);
    }

    public void LevelUp()
    {
        pieceLevel++;
        SetMovePoint(pieceLevel);
        SetVisual(pieceLevel);
        SetSubEnergy(pieceLevel);
    }

    public abstract void OnTriggerEnter2D(Collider2D collision);
}