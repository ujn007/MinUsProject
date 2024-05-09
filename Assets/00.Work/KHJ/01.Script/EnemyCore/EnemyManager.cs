using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    [Header("Tile")]
    public TMananger TManager;
    [SerializeField] private Transform _tileParent;

    [Header("EnemySetting")]
    [SerializeField] private List<Transform> _enemyPF;
    [SerializeField] private int _enemySpawnCount;
    
    private List<Transform> _tileList;
    public List<Transform> TileList => _tileList;

    private void Start()
    {
        _tileList = _tileParent.GetComponentsInChildren<Transform>().ToList();
    }

    public void SpawnEenemy()
    {

        for (int i = 0; i < _enemyPF.Count; i++)
        {
            int randTrm = Random.Range(0, _tileList.Count);
            Transform enemy = Instantiate(_enemyPF[i], Vector3.zero, Quaternion.identity);
            enemy.name = _enemyPF[i].name;
            enemy.position = _tileList[randTrm].transform.position + Vector3.forward;

            _tileList.RemoveAt(randTrm);
        }
    }
}
