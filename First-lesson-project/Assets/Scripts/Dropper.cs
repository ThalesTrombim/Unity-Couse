using UnityEngine;

public class Dropper : MonoBehaviour
{
	[SerializeField]float timeToWait = 2f;
	MeshRenderer myMeshRenderer;
	Rigidbody rigidbody;

	void Start()
	{
		myMeshRenderer = GetComponent<MeshRenderer>();
		rigidbody = GetComponent<Rigidbody>();

		myMeshRenderer.enabled = false;
		rigidbody.useGravity = false;
	}

	void Update()
	{
		if(Time.time > timeToWait)
		{
			myMeshRenderer.enabled = true;
			rigidbody.useGravity = true;
		}
	}
}
