using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	[SerializeField] InputAction thrust;
	[SerializeField] InputAction rotation;
	[SerializeField] float thrustStrength = 1000f;
	[SerializeField] float rotationStrength = 100f;
	[SerializeField] AudioClip mainEngine;

  AudioSource audioSource;
	Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
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

      PlaySFX(mainEngine);
    } else
		{
			audioSource.Stop();
		}
  }

  public void PlaySFX(AudioClip audio)
  {
    if (!audioSource.isPlaying)
    {
      audioSource.PlayOneShot(audio);
    }
  }

  void ProcessRotation()
	{
		float rotationInput = rotation.ReadValue<float>();

		if(rotationInput < 0)
		{
			ApplyRotation(rotationStrength);
		}
		else if(rotationInput > 0)
    {
      ApplyRotation(-rotationStrength);
    }
  }

  private void ApplyRotation(float rotationThisFrame)
  {
		rigidbody.freezeRotation = true;
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
		rigidbody.freezeRotation = false;
  }
}
