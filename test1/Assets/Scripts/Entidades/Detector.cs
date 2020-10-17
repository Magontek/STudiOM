using System.Collections;
using UnityEngine;

public class Detector : MonoBehaviour // NOTE : Does not handle multiple beast entering/exiting
{
    public bool PlayerInRange;

    public Vector2 ThingDirection;

    public bool WallInRange;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Colision");
        if (other.collider.name=="Player")
        {
            PlayerInRange = true;
        }
        else{
            WallInRange = true;
        }
        ThingDirection = other.relativeVelocity.normalized;
        Debug.Log("Velocidad de deteccion = " + ThingDirection);
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Descolision");    
        if (other.collider.name=="Player")
        {
            PlayerInRange = false; 
        }
        else{
            WallInRange = false;
        }
        ThingDirection = Vector2.zero;
    }
}