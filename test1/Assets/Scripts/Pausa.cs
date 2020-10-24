using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{

	public static bool MenuPause = false;
	public GameObject pauseMenuUI;
	public static  bool onEvent = false;
	Canvas canvas;

    void Start()
    {	
        canvas = this.GetComponentInParent<Canvas>();
    }

	void Update ()
	{
		print(gameObject.name);
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (MenuPause)
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
		canvas.sortingOrder = 10;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		MenuPause = true;
	}

	public void Resume ()
	{
		canvas.sortingOrder = 0;
		pauseMenuUI.SetActive(false);
		MenuPause = false;
		if (!onEvent)
		{
			Time.timeScale = 1f;
		}

	}

	public void GoMenu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
		MenuPause = false;
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}

}
