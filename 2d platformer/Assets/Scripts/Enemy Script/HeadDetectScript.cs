using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectScript : MonoBehaviour
{
    GameObject Enemy;
    public GameObject Coin;

    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Enemy.GetComponent<SpriteRenderer>().flipY = true;
        Enemy.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Enemy.GetComponent<Patrol>().enabled = false;
        Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        Enemy.transform.position += movement * Time.deltaTime;
        //groundDetector.SetActive(false);

        int random = Random.Range(0, 4); 
         for (int i = 0; i < random; i++){
             GameObject prefab = Instantiate(Coin, transform.position, Quaternion.identity);
         }
    }
}
