using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGfollower : MonoBehaviour
{
    [SerializeField] private Transform player;


    // Update is called once per frame
    void Update()
    {
        //transform.position = player.position;
       Vector3 position = player.position;
       position.y = transform.position.y;
       position.z = transform.position.z; 
       transform.position = position;

    }
}
