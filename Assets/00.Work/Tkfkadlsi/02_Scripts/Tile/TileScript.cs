using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject OnThisTileObject;
    private int index = 1;


    public void OnPointerClick(PointerEventData eventData)
    {
        if(TMananger.instance.CurrnetState == GameState.Set)
        {
            OnThisTileObject = TMananger.instance.StartPieces[0];
            OnThisTileObject.transform.position = transform.position;

            PlayerPieces piece = OnThisTileObject.GetComponent<PlayerPieces>();
            piece.pieceIndex = index;
            index++;
            OnThisTileObject.SetActive(true);
            TMananger.instance.StartPieces.Remove(OnThisTileObject);
        }
    }
}
