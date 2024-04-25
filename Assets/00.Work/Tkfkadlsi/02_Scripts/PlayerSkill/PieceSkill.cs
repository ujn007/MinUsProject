using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceSkill : MonoBehaviour
{
    private bool isSkillOn = false;

    public bool GetIsSkillOn()
    {
        return isSkillOn;
    }

    public abstract void Skill();


}
