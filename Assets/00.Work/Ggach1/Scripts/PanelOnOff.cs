using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOnOff : MonoBehaviour
{
    SelectedReward[] selectedRewards;

    private void Awake()
    {
        selectedRewards = FindObjectsOfType<SelectedReward>();
    }

    public void PanelOn()
    {
        foreach (SelectedReward reward in selectedRewards)
        {
            reward.gameObject.SetActive(true);
        }
    }

    public void PanelOff()
    {
        foreach (SelectedReward reward in selectedRewards)
        {
            reward.gameObject.SetActive(false);
        }
    }
}
