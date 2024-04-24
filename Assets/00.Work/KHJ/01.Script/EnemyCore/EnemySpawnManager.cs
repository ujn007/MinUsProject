using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoSingleton<EnemySpawnManager>
{
    [Header("Tile")]
    public TMananger TManager;
    [SerializeField] private Transform _tileParent;

    [Header("EnemySetting")]
    [SerializeField] private Transform _enemyPF;
    [SerializeField] private int _enemySpawnCount;
    
    private List<Transform> _tileList;
    public List<Transform> TileList => _tileList;

    private void Start()
    {
        _tileList = _tileParent.GetComponentsInChildren<Transform>().ToList();
    }

    public void SpawnEenemy()
    {

        for (int i = 0; i < _enemySpawnCount; i++)
        {
            int randTrm = Random.Range(0, _tileList.Count);
            Transform enemy = Instantiate(_enemyPF, transform.position, Quaternion.identity);
            enemy.position = _tileList[randTrm].transform.position;

            _tileList.RemoveAt(randTrm);
        }
    }
}
