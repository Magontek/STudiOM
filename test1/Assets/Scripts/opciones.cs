using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class opciones : MonoBehaviour
{
	public AudioMixer audioMixer;

	public void SetVolume (float volume)
	{
		audioMixer.SetFloat("Volume_Master", volume);
	}
}
