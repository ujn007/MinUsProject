using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemyTpye")]
public class EnemyTpyeSO : ScriptableObject
{
    public Vector2[] moveDir;
    public Transform moveTrm;
    public bool isMe;
}
