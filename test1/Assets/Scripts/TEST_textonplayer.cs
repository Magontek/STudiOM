using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_textonplayer : MonoBehaviour
{

	public GameObject Floating_TextPrefab;

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			if(Floating_TextPrefab)
			{
				ShowFloatingText();
			}
		}
	}

	void ShowFloatingText()
	{
		Instantiate(Floating_TextPrefab, transform.position, Quaternion.identity, transform);
	}
}
