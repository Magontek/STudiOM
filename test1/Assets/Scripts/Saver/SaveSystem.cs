using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void SaveData (SaveManager savedata, string pathtop)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/" + pathtop + ".stom";
		Debug.Log("Save Dir:" + path);
		FileStream stream = new FileStream(path, FileMode.Create);

		PlayerData data = new PlayerData(savedata);

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static PlayerData LoadData (string pathtop)
	{
		string path = Application.persistentDataPath + "/" + pathtop + ".stom";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerData data = formatter.Deserialize(stream) as PlayerData;
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError("Save File not found in "+ path);
			return null;
		}
	}
}
