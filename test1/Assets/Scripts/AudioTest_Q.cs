using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest_Q : MonoBehaviour
{
	private AudioSource audio;

	private void Awake() => audio = GetComponent<AudioSource>();

	private void OnEnable() => TEST_textonplayer.SoundPlay += PlayAudio;

	private void OnDisable() => TEST_textonplayer.SoundPlay -= PlayAudio;

	private void PlayAudio() => audio.Play();
}
