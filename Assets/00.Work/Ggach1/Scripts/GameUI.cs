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

    public void PCLevel(int _PCCatchE, PlayerPieces _Piece)
    {
        _Piece.pieceEXP += _PCCatchE;
        _PCLevelText.text = _PCCatchE.ToString() + $" / {_pc1Levelif[_Piece.pieceLevel]}";
        PCTextUpdate(_Piece.pieceIndex);
        if (_PCCatchE >= _pc1Levelif[_Piece.pieceLevel])
        {
            _Piece.pieceEXP -= _pc1Levelif[_Piece.pieceLevel];
            _Piece.Evolution();
        }
    }

    private void PCTextUpdate(int index)
    {
        switch(index)
        {
             
        }
    }
}
