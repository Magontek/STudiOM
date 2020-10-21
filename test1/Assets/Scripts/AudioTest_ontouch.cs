using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest_ontouch : MonoBehaviour
{
	private AudioSource audioO;

	private void Awake() => audioO = GetComponent<AudioSource>();

	private void OnEnable() => Puzzle_test.Touch += PlayAudio;

	private void OnDisable() => Puzzle_test.Touch -= PlayAudio;

	private void PlayAudio() => audioO.Play();
}
