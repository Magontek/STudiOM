using System;
using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle_test : MonoBehaviour
{
	public GameObject pauseMenuUIP;
	
	public static event Action Touch;

    void OnCollisionEnter2D(Collision2D other)
    {
    	if (other.collider.GetComponent<Aldeano>() != null) 
    	{
            Pause_p();
            Touch?.Invoke();
        }
    }

	public void Pause_p ()
	{
		pauseMenuUIP.SetActive(true);
		Time.timeScale = 0f;
		Pausa.onEvent = true;
	}

	public void Resume_r ()
	{
		pauseMenuUIP.SetActive(false);
		Time.timeScale = 1f;
		Pausa.onEvent  = false;
	}

	public void Lose()
	{
		Time.timeScale = 1f;
		Pausa.onEvent  = false;
		SceneManager.LoadScene(2);
	}

}
