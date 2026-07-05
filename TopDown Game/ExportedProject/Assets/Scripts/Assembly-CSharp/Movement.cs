using UnityEngine;

public class Movement : MonoBehaviour
{
	public Camera sceneCamera;

	public float moveSpeed;

	public Rigidbody2D rb;

	private Vector2 moveDirection;

	private Vector2 mousePosition;

	private void Update()
	{
		ProcessInputs();
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void ProcessInputs()
	{
		float axisRaw = Input.GetAxisRaw("Horizontal");
		float axisRaw2 = Input.GetAxisRaw("Vertical");
		moveDirection = new Vector2(axisRaw, axisRaw2).normalized;
		mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
	}

	private void Move()
	{
		rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
		Vector2 vector = mousePosition - rb.position;
		float rotation = Mathf.Atan2(vector.y, vector.x) * 57.29578f - 90f;
		rb.rotation = rotation;
	}
}
