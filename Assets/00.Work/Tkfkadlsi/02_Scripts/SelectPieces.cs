using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPieces : MonoBehaviour
{
    private GameObject selectedPiece;

    public void SelectNewPiece(GameObject piece)
    {
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
}
