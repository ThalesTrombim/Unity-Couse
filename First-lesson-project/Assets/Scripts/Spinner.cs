using UnityEngine;

public class Spinner : MonoBehaviour
{
	[SerializeField] float xRotationValue = 0f;
	[SerializeField] float yRotationValue = 0f;
	[SerializeField] float zRotationValue = 0f;

	void Start()
	{

	}

	void Update()
	{
		transform.Rotate(xRotationValue, yRotationValue, zRotationValue);
	}
}
