using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PlayerPieces : MonoBehaviour, IPointerClickHandler
{
    protected MovePoint[] movePoints;
    protected SelectPieces selectPieces;
    protected GameObject movePointTrm;
    public int SubEnergy { get; protected set; }
    public bool IsMove { protected get; set; }
    
    private void Start()
    {
        selectPieces = FindObjectOfType<SelectPieces>();
        movePoints = GetComponentsInChildren<MovePoint>();
        Debug.Log(movePoints.Length);
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
}
