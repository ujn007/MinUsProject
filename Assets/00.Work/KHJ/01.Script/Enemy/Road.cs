using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [field: SerializeField] public List<Road> connectRoad { get; private set; } = new();
    [SerializeField] private LayerMask roadMask;
    [SerializeField] private float radius;

    private void Awake()
    {
        Vector2[] dirs = { Vector2.up, Vector2.down,
                          Vector2.right, Vector2.left};

        //foreach (var dir in dirs)
        //{
        //    if (Physics2D.CircleCast(transform.position, radius,  dir, 1.4f, roadMask))
        //    {
        //        connectRoad.Add(info.transform.GetComponent<Road>());
        //    }
        //}
    }
}
