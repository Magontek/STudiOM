using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*El prefab y este script dependen de una entidad teniendo un trigger en su script
que activa el texto... ver "Assets/Scripts/TEST_textonplayer" para saber mas*/
public class Floating_Text_destroyer : MonoBehaviour
{

    public float DestroyTime = 2f;
    public Vector3 Offset = new Vector3(0, -1, 5);

    void Start()//DESTRUYE EL TEXTo despues de DestroyTime
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
    }

}
