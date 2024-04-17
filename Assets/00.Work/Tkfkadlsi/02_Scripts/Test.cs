using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UGUI;
    [SerializeField] private TextMeshProUGUI _leadershipText;
    int leaderShip = 0;

    public void ResetLeadership(int leadership)
    {
        _leadershipText.text = leadership.ToString();
    }

    public void NextWave(int wave)
    {
        UGUI.text = wave.ToString() + " Wave";
    }

    public void SubtractLeadership(int minusLeadership)
    {
        leaderShip -= minusLeadership;
        _leadershipText.text = leaderShip.ToString();
    }
}
