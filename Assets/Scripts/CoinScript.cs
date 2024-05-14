using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float rotateSpeed;
    void Start()
    {

    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
