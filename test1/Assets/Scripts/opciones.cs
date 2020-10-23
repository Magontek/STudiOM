using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class opciones : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider slider;
	public string Language;

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

	public void Start ()
	{
		var localizationSettings = LocalizationSettings.GetInstanceDontCreateDefault();
		if (PlayerPrefs.HasKey("Language"))
		{
			Language = PlayerPrefs.GetString("Language");
			localizationSettings = ScriptableObject.CreateInstance<LocalizationSettings>();
			LocalizationSettings.Instance = localizationSettings;
		}
		else
		{
			PlayerPrefs.SetString("Language", "English");

		}
	}

	public void SetVolume (float slider_value)
	{
		PlayerPrefs.SetFloat("Volume", slider_value);
		audioMixer.SetFloat("Volume_Master", slider_value);
	}

	public void SetLanguage (string language)
	{ /*
		var localizationSettings = LocalizationSettings.GetInstanceDontCreateDefault(); // NO SE Q ESTOY HACIENDO
		localizationSettings = ScriptableObject.CreateInstance<LocalizationSettings>();
		//LocalizationSettings.Instance = localizationSettings;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[3];       */
	}
}
