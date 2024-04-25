using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPieces : MonoBehaviour
{
    private GameObject selectedPiece;
    public bool isLockSelectPiece { get; private set; } = false;

    public void SelectNewPiece(GameObject piece)
    {
        if (isLockSelectPiece) return;

        if(selectedPiece != null)
        {
            if(selectedPiece != piece)
            {
                PlayerPieces pieceScript = selectedPiece.GetComponent<PlayerPieces>();
                pieceScript.MovePointONOFF(true);
            }
        }
        
        selectedPiece = piece;
    }

    public void LockPiece(GameObject piece)
    {
        isLockSelectPiece = true;
        selectedPiece = piece;
    }

    public void UnLockPiece()
    {
        isLockSelectPiece = false;
    }

    public void MoveSelectPiece()
    {
        PlayerPieces pieces = selectedPiece.GetComponent<PlayerPieces>();
        pieces.MovePointONOFF(true);
    }

    public GameObject GetSelectPiece()
    {
        return selectedPiece;
    }
}
