using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] private float sceondsToDestroy = 1f;

    void Start()
    {
        Destroy(gameObject, sceondsToDestroy);
    }

}
