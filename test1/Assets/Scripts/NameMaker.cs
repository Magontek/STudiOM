using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class NameMaker : MonoBehaviour
{

	public GameObject Floating_NamePrefab;
	public GameObject NPCPrefab;
   	private LocalizedString nameRef;

    void Start()
    {
        Name();
    }
 

 	void Name ()
 	{
 		Instantiate(NPCPrefab, transform.position, Quaternion.identity, transform);
 		int KEY = Random.Range(0, 4);
 		nameRef = new LocalizedString() { TableReference = "Names", TableEntryReference = KEY.ToString() };

 		var go = Instantiate(Floating_NamePrefab, transform.position, Quaternion.identity, transform);

 		go.GetComponent<TextMesh>().text = nameRef.GetLocalizedString().Result;
 	}

}
