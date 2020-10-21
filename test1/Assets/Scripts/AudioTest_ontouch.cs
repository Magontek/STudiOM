using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest_ontouch : MonoBehaviour
{
	private AudioSource audio;

	private void Awake() => audio = GetComponent<AudioSource>();

	private void OnEnable() => Puzzle_test.Touch += PlayLoseAudio;

	private void OnDisable() => Puzzle_test.Touch -= PlayLoseAudio;

	private void PlayLoseAudio() => audio.Play();
}
