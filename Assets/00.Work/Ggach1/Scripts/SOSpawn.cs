using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOSpawn : MonoBehaviour
{
    [SerializeField] private TestSO testSO;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = testSO.color;
    }
}
