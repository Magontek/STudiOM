using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class opciones : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider slider;

	public void Awake ()
	{
		if (PlayerPrefs.HasKey("Volume"))
		{
			slider.value = PlayerPrefs.GetFloat("Volume");
		}
		else
		{
			slider.value = 0f;
		}
	}

	public void SetVolume (float slider_value)
	{
		PlayerPrefs.SetFloat("Volume", slider_value);
		audioMixer.SetFloat("Volume_Master", slider_value);
	}
}
