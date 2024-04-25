using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Setting values")]
    public float checkMoveDir = 1.3f;
    public float checkDistance;
    public float checkRadius;

    [Header("LayerMask")]
    public LayerMask whatIsPlayer;

    public List<Transform> targets = new List<Transform>();
    [HideInInspector] public List<PlayerPieces> playerPieces = new List<PlayerPieces>();

    private float min = Mathf.Infinity;

    public virtual void Awake()
    {
        playerPieces = FindObjectsOfType<PlayerPieces>().ToList();
    }

    public void CheckRoad(ref Transform trm, ref GameObject obj)
    {
        Vector2[] dirs = {Vector2.up, Vector2.down,
                         Vector2.right, Vector2.left};

        Transform closestRoad = null;
        Collider2D roadCol = null;

        Transform minPlayer = MinPlayerDis();
        float minDistance = float.MaxValue;

        foreach (Vector2 dir in dirs)
        {
            roadCol = Physics2D.OverlapCircle(transform.position + (Vector3)dir * checkMoveDir, checkRadius);

            if (roadCol == null) continue;

            float distance = Vector3.Distance(roadCol.transform.position, minPlayer.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestRoad = roadCol.transform;
            }
        }

        trm = closestRoad;
        obj = closestRoad.gameObject;
    }

    private Transform MinPlayerDis()
    {
        Transform closestPlayer = null;
        float minDistance = float.MaxValue; // 최소 거리를 최대값으로 초기화

        foreach (PlayerPieces player in playerPieces)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestPlayer = player.transform;
            }
        }

        return closestPlayer;
    }

    public Tween MoveTween(Vector3 movePos, float time, Ease ease = Ease.Linear)
    {
        return transform.DOMove(movePos, time).SetEase(ease);
    }
}
