using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
	[SerializeField] GameObject[] projectiles;
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			foreach (GameObject projectile in projectiles)
			{
				projectile.SetActive(true);
				Destroy(gameObject);
			}

		}
	}
}
