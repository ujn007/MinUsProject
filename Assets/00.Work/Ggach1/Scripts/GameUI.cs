using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl; //텍스트 건드림

public class GameUI : MonoBehaviour
{
    TextMeshProUGUI _wave;
    TextMeshProUGUI _leadershipText;
    int _leadership = 0;

    TextMeshProUGUI _leftWaveText;
    int _leftWave = 0;

    TextMeshProUGUI _PCLevelText;
    int _P1Level = 0;
    int _P2Level = 0;
    int _P3Level = 0;


    public void Resetleadership(int _leadership)
    {
        _leadershipText.text = _leadership.ToString();
    }

    public void NextWave(int wave)
    {
        _wave.text = wave.ToString() + " Wave";
    }

    public void SubtractLeadership(int leadership)
    {
        _leadership -= leadership;
        _leadershipText.text = leadership.ToString();
    }

    public void LeftWave(int _leftwave)
    {
        _leftWave -= _leftwave;
        _leftWaveText.text = _leftwave.ToString();
    }

    public void P1Level(int _pcLevel)
    {
        _pcLevel += _P1Level;
        _PCLevelText.text = _pcLevel.ToString() + " / 7";
    }

    public void P2Level(int _PCLevel)
    {
        _PCLevel += _P2Level;
        _PCLevelText.text = _PCLevel.ToString() + " / 7";
    }

    public void P3Level(int Pclevel)
    {
        Pclevel += _P3Level;
        _PCLevelText.text = Pclevel.ToString() + " / 7";
    }
}
