using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject TCounter;
	public static int counter = 0;

	public void SavePlayer ()
	{
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer ()
	{
		PlayerData data = SaveSystem.LoadPlayer();
		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		transform.position = position;
		counter = data.counter;
		TCounter.GetComponent<TMPro.TextMeshProUGUI>().text = counter.ToString();//ESTO LE AHCE TIRAR ERROR NO SE X Q, PERO FUNCIONA IGUAL es para q se actualice el dato en pantalla cuando cargas nomas
	}
}
