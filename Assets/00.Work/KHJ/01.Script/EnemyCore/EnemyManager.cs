using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct EnemySpawnCount
{
    public int CrossAndXEnemy;
    public int CrossEnemy;
    public int HorseEnemy;
}

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [Header("Tile")]
    public TMananger TManager;
    [SerializeField] private Transform _tileParent;

    [Header("EnemySetting")]
    [SerializeField] private List<Transform> _enemyPF;
    public EnemySpawnCount _enemySpawnCount;

    private List<Transform> _tileList;
    public List<Transform> TileList => _tileList;

    [HideInInspector] public List<Enemy> enemyList = new List<Enemy>();

    private void Start()
    {
        _tileList = _tileParent.GetComponentsInChildren<Transform>().ToList();
    }

    private void Update()
    {
        if (enemyList.Count <= 0 && GameUI.Instance.waveCount > 1)
        {
            GameUI.Instance.NextWave(true);
        }
    }

    public void SpawnEenemy()
    {
        for (int j = 0; j < _enemySpawnCount.CrossAndXEnemy; j++)
        {
            SpawnEnem(0);
        }

        for (int j = 0; j < _enemySpawnCount.CrossEnemy; j++)
        {
            SpawnEnem(1);
        }

        for (int j = 0; j < _enemySpawnCount.HorseEnemy; j++)
        {
            SpawnEnem(2);
        }
    }

    private void SpawnEnem(int j)
    {
        int randTrm = Random.Range(0, _tileList.Count);
        Transform enemy = Instantiate(_enemyPF[j], Vector3.zero, Quaternion.identity);
        enemy.name = _enemyPF[j].name;
        enemy.position = _tileList[randTrm].transform.position + Vector3.forward;

        _tileList.RemoveAt(randTrm);
    }
}
