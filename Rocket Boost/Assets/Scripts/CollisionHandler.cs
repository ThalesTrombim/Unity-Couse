using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	// int currentScene = SceneManager.GetActiveScene().buildIndex;

	void OnCollisionEnter(Collision other)
	{
		switch (other.gameObject.tag)
		{
			case "Friendly":
				Debug.Log("This is a friendly object");
				break;
			case "Finish":
				GoToNextLevel();
				break;
      default:
			  StartCrashSequence();
				Invoke("ReloadLevel", 2f);
        break;
    }
  }

  private void StartCrashSequence()
  {
    throw new NotImplementedException();
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
