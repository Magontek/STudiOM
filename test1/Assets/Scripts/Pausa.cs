using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{

	public static bool Stopped = false;
	public GameObject pauseMenuUI;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Stopped)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Pause ()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		Stopped = true;
	}

	public void Resume ()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		Stopped = false;
	}

	public void GoMenu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
		Stopped = false;
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}

}
