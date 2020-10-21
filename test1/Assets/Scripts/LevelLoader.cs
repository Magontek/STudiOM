using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

	public GameObject loadingScreen;
	public Slider slider;
	public TMPro.TextMeshProUGUI progressText;

	public void LoadLevel (int scIndex)
	{
		StartCoroutine(LoadAsynchronously(scIndex));
	}

	IEnumerator LoadAsynchronously (int scIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(scIndex);

		loadingScreen.SetActive(true);

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			progressText.text = progress *100f + "%";
			yield return null;
		}
	}
}
