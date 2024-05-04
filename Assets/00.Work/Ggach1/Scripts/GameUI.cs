using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.UI;
using System; //텍스트 건드림

public enum HPColor
{
    Black = 0,
    Red = 1,
    Green = 2,
    Purple = 3,
}

public class GameUI : MonoBehaviour
{
    [SerializeField] private List<Color> hpColor = new List<Color>();
    [SerializeField] public Dictionary<HPColor, Color> HPColorDic = new Dictionary<HPColor, Color>();

    [SerializeField] public GameObject _HpPieces0;
    [SerializeField] public GameObject _HpPieces1;
    [SerializeField] public GameObject _HpPieces2;


    [SerializeField] TextMeshProUGUI _wave;
    [SerializeField] TextMeshProUGUI _leadershipText;
    int _leadership = 0;

    [SerializeField] TextMeshProUGUI _leftWaveText;
    int _leftWave = 0;

    [SerializeField] TextMeshProUGUI _PC1LevelText;
    [SerializeField] TextMeshProUGUI _PC2LevelText;
    [SerializeField] TextMeshProUGUI _PC3LevelText;

    [SerializeField] public Image _spriteImage1;
    [SerializeField] public Image _spriteImage2;
    [SerializeField] public Image _spriteImage3;

    private void Awake()
    {
        foreach(HPColor HPColor in Enum.GetValues(typeof(HPColor)))
        {
            HPColorDic.Add(HPColor, hpColor[(int)HPColor]);
        }
    }

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

        while(_Piece.pieceEXP >= _Piece.techLineSO.LevelUpCondition[_Piece.pieceLevel])
        {
            _Piece.pieceEXP -= _Piece.techLineSO.LevelUpCondition[_Piece.pieceLevel];
            _Piece.LevelUp();
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

    public void PChpchange(PlayerPieces _Piece)
    {
        GameObject currentHP = null;

        switch (_Piece.pieceIndex)
        {
            case 1:
                currentHP = _HpPieces0;
                break;
            case 2:
                currentHP = _HpPieces1;
                break;
            case 3:
                currentHP = _HpPieces2;
                break;
        }

        Image[] hpimages = currentHP.GetComponentsInChildren<Image>();

        int hp = _Piece.pieceHP;

        int index = hpimages.Length;

        //foreach 써서 전부다 black으로
        foreach (Image _image in hpimages)
        {
            _image.color = HPColorDic[HPColor.Black];
        }

        for (int i = 0; i < hp; i++)
        {
            Image hpimage = hpimages[i % 3];

            if(hpimage.color == HPColorDic[HPColor.Black])
            {
                hpimage.color = HPColorDic[HPColor.Red];
            }
            else if (hpimage.color == HPColorDic[HPColor.Red])
            {
                hpimage.color = HPColorDic[HPColor.Green];
            }
            else if (hpimage.color == HPColorDic[HPColor.Green])
            {
                hpimage.color = HPColorDic[HPColor.Purple];
            }
        }
    }

    public void Setsprite(Sprite _sprite, int index)
    {
        switch (index)
        {
            case 1:
                _spriteImage1.sprite = _sprite;
                break;
            case 2:
                _spriteImage2.sprite = _sprite;
                break;
            case 3:
                _spriteImage3.sprite = _sprite;
                break;
        }
    }

    public void Setleadership(int _leaderShip)
    {
        _leadershipText.text = _leaderShip.ToString();
    }
}
