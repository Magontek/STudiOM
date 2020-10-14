using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script va en la entidad

public class TEST_textonplayer : MonoBehaviour
{

	public GameObject Floating_TextPrefab;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q))//ESTE ES EL TRIGGER puede ser lo q sea
		{
			if(Floating_TextPrefab)//PRIMERO COMPRUEBA Q EXISTA (asi decia la instruccion)
			{
				ShowFloatingText();//Invoca al texto
			}
		}
	}

	
	void ShowFloatingText()//Funcion de crear el texto de un PREFAB
	{
		var go = Instantiate(Floating_TextPrefab, transform.position, Quaternion.identity, transform);
		go.GetComponent<TextMesh>().text = "SOY TEXTO";//ACA se decide q dice el texto, puede ser de una variable
	}
}
