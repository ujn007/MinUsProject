using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMananger : MonoBehaviour
{
    [Header("Public")]
    public Dictionary<Vector2, GameObject> TileDic = new Dictionary<Vector2, GameObject>();

    [Header("SerializeField")]
    [SerializeField] private int tileSize;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform tilesParent;
    [SerializeField] private Color tileColor1;
    [SerializeField] private Color tileColor2;

    public static TMananger instance;

    private void Awake()
    {
        instance = this;
        Init();
    }

    private void Init()
    {
        GameObject newTile;
        SpriteRenderer spriteRenderer;
        Color tileColor = tileColor1;

        float x = 1, y = 1;
        float ix = 1, iy = 1;

        if (tileSize % 2 == 0)
        {
            x = tileSize / -2 + 0.5f;
            y = tileSize / -2 + 0.5f;
        }
        else
        {
            x = tileSize / -2;
            y = tileSize / -2;
        }

        for (int i = 1; i <= tileSize; i++)
        {
            for (int j = 1; j <= tileSize; j++)
            {
                newTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                newTile.transform.parent = tilesParent;
                TileDic.Add(new Vector2(ix, iy), newTile);
                spriteRenderer = newTile.GetComponent<SpriteRenderer>();
                if(tileColor == tileColor1)
                {
                    spriteRenderer.color = tileColor;
                    tileColor = tileColor2;
                }
                else
                {
                    spriteRenderer.color = tileColor;
                    tileColor = tileColor1;
                }
                iy++;
                y++;
            }
            ix++;
            x++;
            iy -= tileSize;
            y -= tileSize;
        }

        tilesParent.localScale = new Vector3(1.5f, 1.5f);
    }
}
