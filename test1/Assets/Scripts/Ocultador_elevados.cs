     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.Tilemaps;

public class Ocultador_elevados : MonoBehaviour
{
	Tilemap m_Renderer;
       
    // Start is called before the first frame update
    void Start()
    {	
        m_Renderer = this.GetComponentInParent<Tilemap>();
    }

    void OnTriggerEnter2D(Collider2D other){
    	if (other.gameObject.name == "Player")
        {
             m_Renderer.color = new Color(1f, 1f, 1f, 0.4f);
        }
    }

    void OnTriggerExit2D(Collider2D other){
    	if (other.gameObject.name == "Player")
         {
             m_Renderer.color = new Color(1f, 1f, 1f, 1f);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
