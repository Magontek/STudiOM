using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle_test : MonoBehaviour
{

	public static bool StoppedP = false;
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
		StoppedP = true;
	}

	public void Resume_r ()
	{
		pauseMenuUIP.SetActive(false);
		Time.timeScale = 1f;
		StoppedP = false;
	}

	public void Lose()
	{
		SceneManager.LoadScene(2);
		Time.timeScale = 1f;
		StoppedP = false;
	}
}
