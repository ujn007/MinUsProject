using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedReward : MonoBehaviour, IPointerClickHandler
{
    private PanelOnOff _panelOnOff;

    private void Awake()
    {
        _panelOnOff = FindObjectOfType<PanelOnOff>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _panelOnOff.PanelOff();
    }
}
