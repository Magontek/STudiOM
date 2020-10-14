using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating_Text_destroyer : MonoBehaviour
{

    public float DestroyTime = 3f;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

}
