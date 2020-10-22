using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.Localization;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Aldeano : MonoBehaviour
{
	//public event Action<int> OnGatheredChanged;

	private StateMachine _stateMachine;
	public Detector detector;

	public GameObject Floating_TextPrefab;

	public Vector2 Objetivo;
    public float speed;

    public GameObject Floating_NamePrefab;//Variables para el nombre
    public LocalizedString nameRef;

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
        StartCoroutine(GiveMeAName());
        _stateMachine.SetState(wait);

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);

        Func<bool> HasTarget() => () => Vector2.Distance(Objetivo,rigidbody.position) > 0.01f && Objetivo != Vector2.zero;
        Func<bool> OnPosition() => () => Vector2.Distance(Objetivo,rigidbody.position) <= 0.1f;
        Func<bool> Wait_end() => () => wait.TimePassed > 2f;
        Func<bool> Stuck() => () => detector.WallInRange || detector.PlayerInRange;


    }

    private IEnumerator GiveMeAName()
    {
        //CREADOR DE NOMBRE aleatorio
        int KEY = UnityEngine.Random.Range(0, 4);
        if(Floating_NamePrefab)
        {
            var name = Instantiate(Floating_NamePrefab, transform.position, Quaternion.identity, transform);
            nameRef = new LocalizedString() { TableReference = "Names", TableEntryReference = KEY.ToString() };//No importa si se le hace un request, falla
            var strOP = nameRef.GetLocalizedString();

            name.GetComponent<TextMesh>().text = strOP.Result;//Recibe NULL por q es taradito

        	yield return new WaitUntil(() => strOP.IsDone && strOP.Status == AsyncOperationStatus.Succeeded);//Esto espera a recibir el string de la tabla y da el ok pero nunca sucede
            name.GetComponent<TextMesh>().text = strOP.Result;
        }
        else
        {
           Debug.Log("no hay NamePrefab"); 
        }
    }

    public void ShowFloatingText(string texto)//Funcion de crear el texto de un PREFAB
    {
    	if(Floating_TextPrefab)//PRIMERO COMPRUEBA Q EXISTA (asi decia la instruccion)
		{
			var go = Instantiate(Floating_TextPrefab, transform.position, Quaternion.identity, transform);
    		go.GetComponent<TextMesh>().text = texto;//ACA se decide q dice el texto, puede ser de una variable
		}
		else{
			Debug.Log("no hay TextPrefab pero deberia decir " + texto);
		}
    }

    private void Update(){
		_stateMachine.Tick();
    }

    public IState GetState(){
    	return _stateMachine.GetState();
    }
}