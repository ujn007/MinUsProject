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
    int _P1EXP = 0;
    int _P2EXP = 0;
    int _P3EXP = 0;

    int _nowPc1Level = 1;
    int _nowPc2Level = 1;
    int _nowPc3Level = 1;

    int[] _pc1Levelif = { 7, 9, 11 };
    int[] _pc2Levelif = { 7, 9, 11 };
    int[] _pc3Levelif = { 7, 9, 11 };

    

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

    public void P1Level(int _PCCatchE, PlayerPieces _Piece)
    {
        _P1EXP += _PCCatchE;
        _PCLevelText.text = _PCCatchE.ToString() + $" / {_pc1Levelif[_nowPc1Level - 1]}";
        if (_PCCatchE >= _pc1Levelif[_nowPc1Level - 1])
        {
            _P1EXP -= _pc1Levelif[_nowPc1Level - 1];
            _nowPc1Level++;
        }
    }

    public void P2Level(int _PCCatchE, PlayerPieces _Piece)
    {
        _P2EXP += _PCCatchE;
        _PCLevelText.text = _PCCatchE.ToString() + $" / {_pc2Levelif[_nowPc2Level - 1]}";
        if (_PCCatchE >= _pc2Levelif[_nowPc2Level - 1])
        {
            _P2EXP -= _pc2Levelif[_nowPc2Level - 1];
            _nowPc2Level++;
        }
    }

    public void P3Level(int _PCCatchE, PlayerPieces _Piece)
    {
        _P3EXP += _PCCatchE;
        _PCLevelText.text = _PCCatchE.ToString() + $" / {_pc3Levelif[_nowPc3Level - 1]}";
        if (_PCCatchE >= _pc3Levelif[_nowPc3Level - 1])
        {
            _P2EXP -= _pc3Levelif[_nowPc3Level - 1];
            _nowPc3Level++;

        }
    }
}
