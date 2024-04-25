using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TestSO")]
public class TestSO : ScriptableObject
{
    public int Level = 0;
    public float exp = 0;
    //public string name = "±îÄ¡";
    public Sprite image;
    public Animator anim;
    public Color color;
}
