using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShyTest : MonoBehaviour
{
    [SerializeField]GameObject tester;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            tester.transform.position = Vector3.Lerp(tester.transform.position, transform.position, 0.05f);
        }
    }
}
