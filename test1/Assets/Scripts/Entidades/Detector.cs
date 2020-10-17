using System.Collections;
using UnityEngine;

public class Detector : MonoBehaviour // NOTE : Does not handle multiple beast entering/exiting
{
    public bool PlayerInRange;

    public Vector2 PlayerPosition;

    public bool WallInRange;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Player")
        {
            PlayerInRange = true;
            PlayerPosition = GetPlayerPosition(other.GetComponent<Rigidbody2D>());
        }
        else{
            WallInRange = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.name=="Player")
        {
            PlayerInRange = false;
            PlayerPosition = Vector2.zero;
        }
        else{
            WallInRange = false;
        }
    }

    public Vector3 GetPlayerPosition(Rigidbody2D _rigidbody)
    {
        return _rigidbody.position;
    }
}