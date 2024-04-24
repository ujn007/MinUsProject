using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject OnThisTileObject;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(TMananger.instance.CurrnetState == GameState.Set)
        {
            OnThisTileObject = TMananger.instance.StartPieces[0];
            OnThisTileObject.transform.position = transform.position;
            OnThisTileObject.SetActive(true);
            TMananger.instance.StartPieces.Remove(OnThisTileObject);

            //김현준이 추가한 코드야  ㅎㅎ
            EnemySpawnManager.Instance.TileList.Remove(transform);
        }
    }
}
