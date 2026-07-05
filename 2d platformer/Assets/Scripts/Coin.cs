using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        CoinCounter.Instance.AddMoney(1, transform.position);
        Destroy(gameObject);
    }
}
