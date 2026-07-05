using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	private float spawnRadius = 7f;

	[SerializeField]
	private float time = 1.5f;

	public GameObject[] enemies;

	private void Start()
	{
		StartCoroutine(SpawnAnEnemy());
	}

	private IEnumerator SpawnAnEnemy()
	{
		Vector2 vector = GameObject.Find("Player").transform.position;
		vector += Random.insideUnitCircle.normalized * spawnRadius;
		Object.Instantiate(enemies[Random.Range(0, enemies.Length)], vector, Quaternion.identity);
		yield return new WaitForSeconds(time);
		StartCoroutine(SpawnAnEnemy());
	}
}
