using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle_test : MonoBehaviour
{

	public GameObject pauseMenuUIP;
	
    void OnTriggerEnter2D(Collider2D other)
    {
    	if (other.name == "Aldeano") 
    	{
            Pause_p();
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
		SceneManager.LoadScene(2);
		Time.timeScale = 1f;
		Pausa.onEvent  = false;
	}
}
