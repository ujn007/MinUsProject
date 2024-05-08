using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shytest : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float power;
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(x, 0) * Time.deltaTime * 3;
    }
}
