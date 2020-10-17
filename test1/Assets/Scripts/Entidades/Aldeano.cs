using System;
using UnityEngine;
using UnityEngine.AI;

public class Aldeano : MonoBehaviour
{
	public event Action<int> OnGatheredChanged;

	private StateMachine _stateMachine;

	public GameObject Floating_TextPrefab;

	public Vector2 Objetivo;
    public float speed;

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

	private void Awake()
    {
    	var rigidbody = GetComponent<Rigidbody2D>();
    	var animator = GetComponent<Animator>();
    	_stateMachine = new StateMachine();
		
    	var wait = new Wait(this, animator);
    	var roam_random = new Roam_random(this);
    	var walk_to = new Walk_to(this, animator,rigidbody);

    	At(roam_random, walk_to, HasTarget());
        At(walk_to, wait, OnPosition());
        At(walk_to, roam_random, Stuck());
        At(wait, roam_random, Wait_end());

        _stateMachine.SetState(roam_random);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> HasTarget() => () => Vector2.Distance(Objetivo,rigidbody.position) >= 0.1f;
        Func<bool> OnPosition() => () => Vector2.Distance(Objetivo,rigidbody.position) <= 0.1f;
        Func<bool> Stuck() => () => walk_to.TimeStuck > 1f;
        Func<bool> Wait_end() => () => wait.TimePassed > 1000;
    }

    

    private void Update() => _stateMachine.Tick();
}