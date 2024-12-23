using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	[SerializeField] InputAction thrust;
	[SerializeField] InputAction rotation;
	[SerializeField] float thrustStrength = 1000f;
	[SerializeField] float rotationStrength = 100f;
  
	new Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void OnEnable()
	{
		thrust.Enable();
		rotation.Enable();
	}

	void FixedUpdate()
	{
		ProcessThrust();
		ProcessRotation();
	}

	private void ProcessThrust()
	{
		if (thrust.IsPressed())
		{
			rigidbody.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
		}
	}

	void ProcessRotation()
	{
		float rotationInput = rotation.ReadValue<float>();

		if(rotationInput < 0)
		{
			ApplyRotation(Vector3.forward);
		}
		else if(rotationInput > 0)
    {
      ApplyRotation(Vector3.back);
    }
  }

  private void ApplyRotation(Vector3 direction)
  {
    transform.Rotate(direction * rotationStrength * Time.fixedDeltaTime);
  }
}
