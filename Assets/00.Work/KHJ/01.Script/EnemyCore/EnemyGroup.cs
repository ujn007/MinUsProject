using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyGroup : MonoBehaviour
{
    [HideInInspector] public List<PlayerPieces> playerPieces = new List<PlayerPieces>();
    [HideInInspector] public List<Enemy> enemyList = new List<Enemy>();
    Enemy enemyBase;

    public void Initialize()
    {
        playerPieces = FindObjectsOfType<PlayerPieces>().ToList();
        enemyList = FindObjectsOfType<Enemy>().ToList();    
    }

    public bool SetMinEenemy(Enemy enemyBase)
    {
        if (enemyBase.name == CheckMinEnemy().name)
            return true;
        else
            return false;
    }

    public Enemy CheckMinEnemy()
    {
        float mindis = float.MaxValue;
        int minHP = int.MaxValue;
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
                        if (minHP > playerPieces[i].GetHP())
                        {
                            enemy = enemyList[j];
                            continue;
                        }
                    }
                    mindis = dis;
                    enemy = enemyList[j];
                }
            }
        }

        return enemy;
    }
}
