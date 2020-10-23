using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    private Camera cam;
    private float targetZoom;

    void Start ()
    {
    	cam = Camera.main;
		targetZoom = cam.orthographicSize;
		ParticleSystem rain = GetComponent<ParticleSystem>();
    }


    void Update ()
	{

		float ScrollWheelChange;
		ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
		targetZoom -= ScrollWheelChange * 3f; // Cantidad de zoom por rueda
		targetZoom = Mathf.Clamp(targetZoom, 2f, 8f); // LIMITES DE LA CAMARA
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 10);
	}
}
