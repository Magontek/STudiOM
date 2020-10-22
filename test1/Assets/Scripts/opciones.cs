using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class opciones : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider slider;
	public float vol;

	public void Awake ()
	{
		audioMixer.GetFloat("Volume_Master", out vol);
		slider.value = vol;
	}

	public void SetVolume (float volume)
	{
		audioMixer.SetFloat("Volume_Master", volume);
	}
}
