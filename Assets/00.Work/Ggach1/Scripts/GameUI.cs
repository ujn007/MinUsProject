using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl; //텍스트 건드림

public enum HPColor
{
    Red = 0,
    Green = 1,
    Purple = 2
}

public class GameUI : MonoBehaviour
{
    [SerializeField] private List<Color> hpColor = new List<Color>();
    public Dictionary<HPColor, Color> HPColorDic = new Dictionary<HPColor, Color>();

    private void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            HPColorDic.Add((HPColor)i, hpColor[i]); 
        }
    }

    TextMeshProUGUI _wave;
    TextMeshProUGUI _leadershipText;
    int _leadership = 0;

    TextMeshProUGUI _leftWaveText;
    int _leftWave = 0;

    TextMeshProUGUI _PC1LevelText;
    TextMeshProUGUI _PC2LevelText;
    TextMeshProUGUI _PC3LevelText;

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
        PCTextUpdate(_Piece);
        if (_PCCatchE >= _Piece.techLineSO.LevelUpCondition[_Piece.pieceLevel])
        {
            _Piece.pieceEXP -= _Piece.techLineSO.LevelUpCondition[_Piece.pieceLevel];
            _Piece.Evolution();
        }
    }

    private void PCTextUpdate(PlayerPieces _Piece)
    {
        switch (_Piece.pieceIndex)
        {
            case 1:
                _PC1LevelText.text = $"{_Piece.pieceEXP} / {_Piece.techLineSO.LevelUpCondition[_Piece.pieceLevel]}";
                break;
            case 2:
                _PC2LevelText.text = $"{_Piece.pieceEXP} / {_Piece.techLineSO.LevelUpCondition[_Piece.pieceLevel]}";
                break;
            case 3:
                _PC3LevelText.text = $"{_Piece.pieceEXP} / {_Piece.techLineSO.LevelUpCondition[_Piece.pieceLevel]}";
                break;
        }
    }

    private void PChpchange(PlayerPieces _Piece)
    {

    }
}
