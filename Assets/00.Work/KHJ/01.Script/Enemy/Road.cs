using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Road : MonoBehaviour
{
    [field: SerializeField] public List<Road> connectRoad { get; private set; } = new();
    [SerializeField] private LayerMask tileMask;
    [SerializeField] private float distance;
    [SerializeField] private float radius;

    private void Start()
    {
        Vector2[] dirs = { Vector2.up, Vector2.down,
                          Vector2.right, Vector2.left};

        foreach (var dir in dirs)
        {
            Collider2D col = Physics2D.OverlapCircle(transform.localPosition * dir, radius, tileMask);
            print(col.transform.position);

            col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector2[] dirs = { Vector2.up, Vector2.down,
                          Vector2.right, Vector2.left};

        foreach (Vector2 dir in dirs)
            Gizmos.DrawWireSphere(transform.position + (Vector3)dir * distance, radius);
    }
#endif 
}
