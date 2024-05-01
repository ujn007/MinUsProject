using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyGroup : MonoBehaviour
{
    [HideInInspector] public List<PlayerPieces> playerPieces = new List<PlayerPieces>();
    [HideInInspector] public List<Enemy> enemyList = new List<Enemy>();

    public virtual void Start()
    {
        playerPieces = FindObjectsOfType<PlayerPieces>().ToList();
        enemyList = FindObjectsOfType<Enemy>().ToList();
    }

    public string CheckMinEnemy()
    {
        float mindis = float.MaxValue;
        Enemy enemy = null;

        for (int i = 0; i < playerPieces.Count; i++)
        {
            for (int j = 0; j < enemyList.Count; j++)
            {
                float dis = Vector2.Distance(playerPieces[i].transform.position, enemyList[j].transform.position);

                if (dis <= mindis)
                {
                    if (dis == mindis)
                    {
                        
                    }
                    mindis = dis;
                    enemy = enemyList[j];
                }
            }
        }

        return enemy.name;
    }

    private void CheckLowHealth()
    {

    }
}
