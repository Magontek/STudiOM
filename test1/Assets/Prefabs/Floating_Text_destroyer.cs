using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*El prefab y este script dependen de una entidad teniendo un trigger en su script
que activa el texto... ver "Assets/Scripts/TEST_textonplayer" para saber mas*/
public class Floating_Text_destroyer : MonoBehaviour
{

    public float DestroyTime = 3f;

    void Start()//DESTRUYE EL TEXTo despues de DestroyTime
    {
        Destroy(gameObject, DestroyTime);
    }

}
