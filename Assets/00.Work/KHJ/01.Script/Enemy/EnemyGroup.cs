using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyGroup : MonoBehaviour
{
    public List<Transform> hitColList = new();

    [SerializeField] private LayerMask tileMask;
    [SerializeField] private float distance;
    [SerializeField] private float radius;

    public Rigidbody2D RigidbodyCompo { get; protected set; }
    public Collider2D ColliderCompo { get; protected set; } 

    protected virtual void Awake()
    {
        RigidbodyCompo = GetComponent<Rigidbody2D>();
        ColliderCompo = GetComponent<Collider2D>(); 
    }

    protected abstract void SetAttack();    

    protected virtual List<Transform> CheckRoad(Vector2 ownerPos)
    {
        Vector2[] dirs = { Vector2.up, Vector2.down,
                          Vector2.right, Vector2.left};

        foreach (var dir in dirs)
        {
            Collider2D col = Physics2D.OverlapCircle(ownerPos + dir * distance, radius, tileMask);

            if (col == null) continue;

            hitColList.Add(col.transform);
        }

        return hitColList;
    }
}
