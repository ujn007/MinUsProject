using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct EnemySpawnCount
{
    public int CrossAndXEnemy;
    public int CrossEnemy;
    public int HorseEnemy;
    public int CrossAndXEnemyPlus;
    public int CrossEnemyPlus;
    public int HorseEnemyPlus;
}

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [Header("Tile")]
    public TMananger TManager;
    [SerializeField] private Transform _tileParent;

    [Header("EnemySetting")]
    [SerializeField] private List<Transform> _enemyPF;
    public int whenWavePlusCount;
    public EnemySpawnCount _enemySpawnCount;

    private List<Transform> _tileList;
    public List<Transform> TileList => _tileList;

    [SerializeField] public List<Enemy> enemyList = new List<Enemy>();
    [HideInInspector] public List<PlayerPieces> playerPieces = new List<PlayerPieces>();

    private void Start()
    {
        _tileList = _tileParent.GetComponentsInChildren<Transform>().ToList();
    }

    private void Update()
    {
        if (enemyList.Count <= 0 && GameUI.Instance.waveCount >= 1)
        {
            GameUI.Instance.NextWave(true);
        }
    }

    public void SpawnEenemy(bool s = false)
    {
        TMananger.instance.StartPlayerTurn();

        if (GameUI.Instance.waveCount > 1)
            _tileList = _tileParent.GetComponentsInChildren<Transform>().ToList();

        if (s)
        {
            _enemySpawnCount.HorseEnemy += _enemySpawnCount.HorseEnemyPlus;
            _enemySpawnCount.CrossEnemy += _enemySpawnCount.CrossEnemyPlus;
            _enemySpawnCount.CrossAndXEnemy += _enemySpawnCount.CrossAndXEnemyPlus;
        }

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
        if (GameUI.Instance.waveCount > 1)
        {
            foreach (PlayerPieces player in playerPieces)
            {
                Collider[] colliders = Physics.OverlapSphere(player.transform.position, 0.5f);
                foreach (Collider collider in colliders)
                {
                    Debug.Log(collider.gameObject.layer);
                    if (collider.gameObject.layer == 6)
                    {
                        _tileList.Remove(collider.transform);
                    }
                }
            }
        }

        int randTrm = Random.Range(0, _tileList.Count);
        Transform enemy = Instantiate(_enemyPF[j], Vector3.zero, Quaternion.identity);
        enemy.position = _tileList[randTrm].transform.position + Vector3.forward;

        _tileList.RemoveAt(randTrm);
    }
}
