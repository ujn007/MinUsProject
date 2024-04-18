using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PieceTechLine")]
public class PieceTechLineSO : ScriptableObject
{
    public GameObject[] movePoints;
    public int[] LevelUpCondition;
    public Sprite[] visual;
    public Animator level3_animator;
}
