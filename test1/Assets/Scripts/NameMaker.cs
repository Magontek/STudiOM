using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameMaker : MonoBehaviour
{

	public GameObject NPCPrefab;

    void Start()
    {
        Name();
    }
 

 	void Name ()
 	{
 		Instantiate(NPCPrefab, transform.position, Quaternion.identity, transform);
 		int KEY = Random.Range(0, 4);
 	}

}
