using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class EnemyGroup : MonoBehaviour
{
    [SerializeField] private GameObject enemyPath;

    protected EnemyManager enemMng => EnemyManager.Instance;

    public void Initialize()
    {
        enemMng.playerPieces = FindObjectsOfType<PlayerPieces>().ToList();
        enemMng.enemyList = FindObjectsOfType<Enemy>().ToList();

    }

    public bool SetMinEenemy(Enemy enemyBase)
    {
        if (enemyBase.GetInstanceID() == CheckMinEnemy().GetInstanceID())
            return true;
        else
            return false;
    }

    public Enemy CheckMinEnemy()
    {

        float mindis = float.MaxValue;
        int minHP = int.MaxValue;
        Enemy enemy = null;

        for (int i = 0; i < enemMng.playerPieces.Count; i++)
        {
            for (int j = 0; j < enemMng.enemyList.Count; j++)
            {
                float dis = Vector2.Distance(enemMng.playerPieces[i].transform.position, enemMng.enemyList[j].transform.position);
                if (dis <= mindis)
                {
                    if (dis == mindis)
                    {
                        if (minHP > enemMng.playerPieces[i].GetHP())
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

    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector2.Distance(mousePos, transform.position);
            if (distance < 0.5f * TMananger.instance.tileScale)
            {
                enemyPath.SetActive(true);
            }
        }
        else if (Input.GetMouseButtonUp(1))
        {
            enemyPath.SetActive(false);
        }
    }
}
