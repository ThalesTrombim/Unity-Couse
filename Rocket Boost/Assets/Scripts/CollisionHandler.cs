using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	[SerializeField] float delay = 2f;
	[SerializeField] AudioClip crashSFX;
	[SerializeField] AudioClip successSFX;
	[SerializeField] ParticleSystem crashParticles;
	[SerializeField] ParticleSystem successParticles;

	AudioSource audioSource;

	bool isControllable = true; 
	bool isCollidable = true;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		ResponToDebugKeys();
	}

	void OnCollisionEnter(Collision other)
	{
		if(!isControllable || !isCollidable) { return; }

		switch (other.gameObject.tag)
		{
			case "Friendly":
				break;
			case "Finish":
				StartSuccessSequence();
				break;
      default:
			  StartCrashSequence();
        break;
    }
  }

  private void StartSuccessSequence()
  {
		isControllable = false;
		audioSource.Stop();
		audioSource.PlayOneShot(successSFX);
		successParticles.Play();

		GetComponent<Movement>().enabled = false;
    Invoke("GoToNextLevel", delay);
  }

  private void StartCrashSequence()
  {
		isControllable = false;
		audioSource.Stop();
		audioSource.PlayOneShot(crashSFX);
		crashParticles.Play();

		GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", delay);
  }

  void ResponToDebugKeys()
  {
    if(Keyboard.current.lKey.wasPressedThisFrame)
		{
			GoToNextLevel();
		}
		else if (Keyboard.current.cKey.wasPressedThisFrame)
		{
			isCollidable = !isCollidable;
		}
  }

  void ReloadLevel()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;

		SceneManager.LoadScene(currentScene);
	}

	void GoToNextLevel()
	{
		int currentScene = SceneManager.GetActiveScene().buildIndex;
		int nextScene = currentScene + 1;

		if(nextScene == SceneManager.sceneCountInBuildSettings)
		{
			nextScene = 0;
		}

		SceneManager.LoadScene(nextScene);
	}
}
