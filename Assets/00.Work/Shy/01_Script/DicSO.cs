using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/DicSO")]
public class DicSO : ScriptableObject
{
    public string name;
    public int life;
    public int useValue;
    public string develop;
    public List<string> expain;
    public Sprite visual;
    public Sprite moveWay;
}
