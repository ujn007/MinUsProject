using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeleionSkill : PieceSkill
{
    public override void Skill()
    {
        _mybody.selectPieces.LockPiece(_mybody.gameObject);
        _mybody.MovePointONOFF();

    }
}
