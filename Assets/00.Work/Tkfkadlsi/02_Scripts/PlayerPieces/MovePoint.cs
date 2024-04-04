using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePoint : MonoBehaviour, IPointerClickHandler
{
    PlayerPieces rootPiece;

    private void Start()
    {
        rootPiece = transform.root.GetComponent<PlayerPieces>();
    }

    public void SelectedParentPiece()
    {
        bool isXout = false;
        bool isYout = false;

        isXout = Clamp(
            TMananger.instance.minPos.x,
            TMananger.instance.maxPos.x,
            transform.position.x);
        isYout = Clamp(
            TMananger.instance.minPos.y,
            TMananger.instance.maxPos.y,
            transform.position.y);

        if(isXout || isYout)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (TMananger.instance.CurrnetState != GameState.PlayerTurn) return;
        rootPiece.transform.position = transform.position;
        rootPiece.MovePiece();
        rootPiece.selectPieces.NonSelectPiece();
    }

    private bool Clamp(float min, float max, float value)
    {
        if(value < min || max < value)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
