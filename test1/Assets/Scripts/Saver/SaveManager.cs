using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour

{
	public GameObject TextCounter;
	public GameObject player;
	public int counter;
	public Vector3 position;

	//Guardar Personaje
	public void SavePlayer ()
	{
		counter = player.GetComponent<TEST_textonplayer>().counter;
		transform.position = player.transform.position;
		SaveSystem.SaveData(this, "player");
	}

	public void LoadPlayer ()
	{
		PlayerData data = SaveSystem.LoadData("player");

		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		player.transform.position = position;
		player.GetComponent<TEST_textonplayer>().counter = data.counter;
		
		TextCounter.GetComponent<TMPro.TextMeshProUGUI>().text = data.counter.ToString();//actualiza el numero en pantalla
	}

	//Guardar Configuracion
	public void SaveConfig ()
	{
		
		//SaveSystem.SaveData(this, "config", class ConfigData);
	}

	public void LoadConfig ()
	{

	}
}
