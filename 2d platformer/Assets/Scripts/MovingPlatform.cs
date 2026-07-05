using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> wayPoints;
    public float moveSpeed;
    public int target;

    void Update()
    {
        //recieve data
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[target].position, moveSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //use data
        if(transform.position == wayPoints[target].position)
        {
            if(target == wayPoints.Count - 1){
                target = 0;
            }
            else{
                target += 1;
            }
        }
    }
}
