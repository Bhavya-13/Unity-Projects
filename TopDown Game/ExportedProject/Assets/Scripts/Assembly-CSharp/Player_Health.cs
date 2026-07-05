using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
	public int maxHealth = 100;

	public int currentHealth;

	public HealthBar healthBar;

	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	private void Update()
	{
		if (currentHealth <= 0)
		{
			Object.Destroy(base.gameObject);
			SceneManager.LoadScene("GameOver");
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "enemy")
		{
			TakeDamage(20);
		}
		if (collision.gameObject.tag == "Medkit")
		{
			TakeHealth(200);
		}
	}

	private void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}

	private void TakeHealth(int boost)
	{
		currentHealth = maxHealth;
		healthBar.SetHealth(currentHealth);
	}
}
