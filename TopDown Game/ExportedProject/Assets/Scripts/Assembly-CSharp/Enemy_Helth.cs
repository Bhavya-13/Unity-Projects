using UnityEngine;

public class Enemy_Helth : MonoBehaviour
{
	public int maxHealth = 100;

	public int currentHealth;

	public GameObject hitEffect;

	private void Start()
	{
		currentHealth = maxHealth;
	}

	private void Update()
	{
		if (currentHealth <= 0)
		{
			Object.Destroy(base.gameObject);
			Score.scoreValue += 10;
			Object.Destroy(Object.Instantiate(hitEffect, base.transform.position, Quaternion.identity), 0.3f);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "bullet")
		{
			TakeDamage(20);
		}
	}

	private void TakeDamage(int damage)
	{
		currentHealth -= damage;
	}
}
