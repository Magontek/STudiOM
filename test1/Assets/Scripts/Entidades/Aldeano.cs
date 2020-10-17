using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Aldeano : MonoBehaviour
{
	//public event Action<int> OnGatheredChanged;

	private StateMachine _stateMachine;
	public Detector detector;

	public GameObject Floating_TextPrefab;

	public Vector2 Objetivo;
    public float speed;

	private void Awake()
    {	
    	detector = gameObject.AddComponent<Detector>();
    	var rigidbody = GetComponent<Rigidbody2D>();
    	var animator = GetComponent<Animator>();
    	_stateMachine = new StateMachine();
		
    	var wait = new Wait(this, animator);
    	var roam_random = new Roam_random(this,rigidbody);
    	var walk_to = new Walk_to(this, animator,rigidbody);
    	var get_out = new Get_out(this,rigidbody,detector.ThingDirection);
    	//Estas son las condiciones para cambiar de estado
    	At(roam_random, wait, HasTarget());
    	At(get_out, wait, HasTarget());
        At(walk_to, roam_random, OnPosition());
        At(walk_to, get_out, Stuck());
        At(wait, walk_to, Wait_end());
        //Lo que hace por primera vez al ejecutar el script
        Objetivo = rigidbody.position;
        _stateMachine.SetState(wait);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> HasTarget() => () => Vector2.Distance(Objetivo,rigidbody.position) > 0.01f && Objetivo != Vector2.zero;
        Func<bool> OnPosition() => () => Vector2.Distance(Objetivo,rigidbody.position) <= 0.1f;
        Func<bool> Wait_end() => () => wait.TimePassed > 2f;
        Func<bool> Stuck() => () => detector.WallInRange || detector.PlayerInRange;
    }

    public void ShowFloatingText(string texto)//Funcion de crear el texto de un PREFAB
    {
    	if(Floating_TextPrefab)//PRIMERO COMPRUEBA Q EXISTA (asi decia la instruccion)
		{
			var go = Instantiate(Floating_TextPrefab, transform.position, Quaternion.identity, transform);
    		go.GetComponent<TextMesh>().text = texto;//ACA se decide q dice el texto, puede ser de una variable
		}
		else{
			Debug.Log("no hay TextPrefav pero deberia decir " + texto);
		}
    }

    private void Update(){
		if(!Floating_TextPrefab){
			Debug.Log("no hay TextPrefav al incio");
		}
		_stateMachine.Tick();
    }

}