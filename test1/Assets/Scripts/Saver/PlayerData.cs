using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public float[] position;
	public int counter;

    public PlayerData (SaveManager save)
    {
        //Player XYZ && Counter
    	counter = save.counter;
    	position = new float[3];
        position[0] = save.transform.position.x;
        position[1] = save.transform.position.y;
        position[2] = save.transform.position.z;
    }
}
