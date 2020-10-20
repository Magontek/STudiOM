using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameMaker : MonoBehaviour
{

	public GameObject NPCPrefab;


    void Start()
    {
    	int i;
    	int max = Random.Range(100,1000);
    	for(i=0;i<max;i++)
    	{
        	Name();
        }
    }
 

 	void Name ()
 	{
 		int x = Random.Range(-5, 10);
 		int y = Random.Range(-10, 0);
 		var random_post = new Vector3(x,y,0);
 		Instantiate(NPCPrefab, random_post, Quaternion.identity, transform);
 		
 	}

}
