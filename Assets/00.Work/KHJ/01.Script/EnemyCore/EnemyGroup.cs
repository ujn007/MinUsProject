using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyGroup : MonoBehaviour
{
    [HideInInspector] public List<PlayerPieces> playerPieces = new List<PlayerPieces>();

    protected EnemyManager enemMng => EnemyManager.Instance;

    public void Initialize()
    {
        playerPieces = FindObjectsOfType<PlayerPieces>().ToList();
        enemMng.enemyList = FindObjectsOfType<Enemy>().ToList();    
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
            for (int j = 0; j < enemMng.enemyList.Count; j++)
            {
                float dis = Vector2.Distance(playerPieces[i].transform.position, enemMng.enemyList[j].transform.position);
                if (dis <= mindis)
                {
                    if (dis == mindis)
                    {
                        if (minHP > playerPieces[i].GetHP())
                        {
                            enemy = enemMng.enemyList[j];
                            continue;
                        }
                    }
                    mindis = dis;
                    enemy = enemMng.enemyList[j];
                }
            }
        }

        return enemy;
    }
}
