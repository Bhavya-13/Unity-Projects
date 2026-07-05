using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPotion : MonoBehaviour
{
    [SerializeField] private GameObject speedUpfloatingText;

    void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player")
        {
		  PlayerMovement.runSpeed += 5;
		  Destroy(gameObject);
          GameObject prefab = Instantiate(speedUpfloatingText, transform.position, Quaternion.identity);
          prefab.GetComponentInChildren<TextMesh>().text = "speed +5";
        }
    }
}
