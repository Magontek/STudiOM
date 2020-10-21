using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest_Q : MonoBehaviour
{
	private AudioSource audioQ;

	private void Awake() => audioQ = GetComponent<AudioSource>();

	private void OnEnable() => TEST_textonplayer.SoundPlay += PlayAudio;

	private void OnDisable() => TEST_textonplayer.SoundPlay -= PlayAudio;

	private void PlayAudio() => audioQ.Play();
}
