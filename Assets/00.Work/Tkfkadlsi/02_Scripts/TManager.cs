using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public enum GameState
{
    Start,
    Set,
    PlayerTurn,
    EnemyTurn,
}

public class TMananger : MonoBehaviour
{
    [Header("Public")]
    public List<GameObject> StartPieces = new List<GameObject>();
    public Dictionary<Vector2, TileScript> Pos2Tile = new Dictionary<Vector2, TileScript>();
    public Dictionary<GameObject, TileScript> Obj2Tile = new Dictionary<GameObject, TileScript>();
    public GameState CurrnetState;
    public float tileScale = 1.4f;
    public Vector2 minPos;
    public Vector2 maxPos;

    [Header("SerializeField")]
    [SerializeField] private int tileSize;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform tilesParent;
    [SerializeField] private Color tileColor1;
    [SerializeField] private Color tileColor2;
    [SerializeField] private List<GameObject> pieces = new List<GameObject>();

    public static TMananger instance;

    public GameObject GetPiece(int id)
    {
        GameObject newPiece = Instantiate(pieces[id]);
        newPiece.SetActive(false);
        return newPiece;
    }

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
        CurrnetState = GameState.Start;

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
        minPos = new Vector2(x, y);
        maxPos = -minPos;
        for (int i = 1; i <= tileSize; i++)
        {
            for (int j = 1; j <= tileSize; j++)
            {
                newTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                newTile.transform.parent = tilesParent;
                Pos2Tile.Add(new Vector2(ix, iy), newTile.GetComponent<TileScript>());
                Obj2Tile.Add(newTile, newTile.GetComponent<TileScript>());
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

        StartPieces.Add(GetPiece(0));
        StartPieces.Add(GetPiece(1));
        StartPieces.Add(GetPiece(2));

        tilesParent.localScale = new Vector3(tileScale, tileScale);
        minPos *= tileScale;
        maxPos *= tileScale;
        CurrnetState = GameState.Set;
        StartCoroutine(SettingPieces());
    }

    private IEnumerator SettingPieces()
    {
        while(StartPieces.Count > 0)
        {
            yield return new WaitUntil(()=>Input.GetMouseButtonDown(0));
        }

        EnemyManager.Instance.SpawnEenemy();
        CurrnetState = GameState.PlayerTurn;
    }
}