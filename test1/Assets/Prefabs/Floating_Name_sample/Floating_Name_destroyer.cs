using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*El prefab y este script dependen de una entidad teniendo un trigger en su script
que activa el texto... ver "Assets/Scripts/TEST_textonplayer" para saber mas*/
public class Floating_Name_destroyer : MonoBehaviour
{

    public float DestroyTime = 2f;
    private Vector3 Offset = new Vector3(0, -1, 0);

    void Start()//DESTRUYE EL TEXTo despues de DestroyTime
    {
    	//float rnd = Random.Range(-4f,4f); Esto era para que tenga salidas aleatorias pero no funciona
    	//Offset = new Vector3(rnd, 5f, 0);
    	transform.localPosition += Offset;
        Destroy(gameObject, DestroyTime);
    }

}
