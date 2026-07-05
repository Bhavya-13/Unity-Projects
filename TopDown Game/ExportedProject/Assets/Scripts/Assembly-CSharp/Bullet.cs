using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Object.Destroy(Object.Instantiate(hitEffect, base.transform.position, Quaternion.identity), 0.3f);
		Object.Destroy(base.gameObject);
	}
}
