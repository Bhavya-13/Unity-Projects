using UnityEngine;

public class Shooting : MonoBehaviour
{
	public Transform firepoint;

	public GameObject bulletPrefab;

	public float bulletForce = 20f;

	private void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	private void Shoot()
	{
		Object.Instantiate(bulletPrefab, firepoint.position, firepoint.rotation).GetComponent<Rigidbody2D>().AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
	}
}
