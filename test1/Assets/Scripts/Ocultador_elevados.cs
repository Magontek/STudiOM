     using System.Collections;
     using System.Collections.Generic;
     using UnityEngine;
     using UnityEngine.Tilemaps;

public class Ocultador_elevados : MonoBehaviour
{
	Tilemap m_Renderer;
	TilemapCollider2D col;
        
    // Start is called before the first frame update
    void Start()
    {	
        m_Renderer = this.GetComponentInParent<Tilemap>();
        col = m_Renderer.GetComponentInParent<TilemapCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other){
    	if (other.gameObject.name == "Player")
        {
             m_Renderer.color = new Color(1f, 1f, 1f, 0.4f);
        }
        Ray ray = Camera.main.ScreenPointToRay(other.gameObject.transform.position);
        Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3Int position = m_Renderer.WorldToCell(worldPoint);

        TileBase tile = m_Renderer.GetTile(position);
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
