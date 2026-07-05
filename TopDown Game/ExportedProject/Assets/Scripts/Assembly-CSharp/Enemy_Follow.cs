using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
	public float speed;

	private Transform playerPos;

	private void Awake()
	{
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void Update()
	{
		if (Vector2.Distance(base.transform.position, playerPos.position) > 0.25f)
		{
			base.transform.position = Vector2.MoveTowards(base.transform.position, playerPos.position, speed * Time.deltaTime);
		}
	}
}
