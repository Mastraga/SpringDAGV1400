using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShrinkOnCollision : MonoBehaviour
{

    public float shrinkFactor = 0.9f;

    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale *= shrinkFactor;
    }
}
