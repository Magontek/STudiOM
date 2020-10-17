using UnityEngine;

internal class Walk_to : IState
{
	private readonly Aldeano _aldeano;
	private readonly Animator _animator;
	private readonly Rigidbody2D _rigidbody;

	public float TimeStuck;

	private Vector2 _last_position;

    public bool Stuck;

	public Walk_to(Aldeano aldeano, Animator animator,Rigidbody2D rigidbody){
        _animator=animator;
        _aldeano=aldeano;
        _rigidbody=rigidbody;
    }
	public void Tick()
    {
    	//Si la distancia recorrida desde la ultima vez es menor a la esperada entonces suma tiempo de atasco

        // Se mueve en la direccion que dice a la velocidad que dice
     	_rigidbody.MovePosition(_rigidbody.position + ((_rigidbody.position-_aldeano.Objetivo).normalized * _aldeano.speed));

    }
    public void OnEnter() {
        Stuck=false;
    	_last_position=_rigidbody.position;
		TimeStuck = 0f;
		_animator.SetBool("Walk", true);
        _aldeano.ShowFloatingText("Caminando");
		//Debug.Log("Walk");
    }
    public void OnExit() {
    	_animator.SetBool("Walk", false);
    }
}