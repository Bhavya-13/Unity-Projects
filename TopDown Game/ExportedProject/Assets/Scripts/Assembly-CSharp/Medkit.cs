using UnityEngine;

public class Medkit : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Object.Destroy(base.gameObject);
		}
	}
}
