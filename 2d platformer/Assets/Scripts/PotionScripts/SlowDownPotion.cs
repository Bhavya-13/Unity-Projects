using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPotion : MonoBehaviour
{
    [SerializeField] private GameObject speedDownfloatingText;

    void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player")
        {
		  PlayerMovement.runSpeed -= 5;
		  Destroy(gameObject);
          GameObject prefab = Instantiate(speedDownfloatingText, transform.position, Quaternion.identity);
          prefab.GetComponentInChildren<TextMesh>().text = "speed -5";          
        }
    }
}
