using UnityEngine;

internal class Walk_to : IState
{
	private readonly Aldeano _aldeano;
	private readonly Animator _animator;
	private readonly Rigidbody2D _rigidbody;

	public Walk_to(Aldeano aldeano, Animator animator,Rigidbody2D rigidbody){
        _animator=animator;
        _aldeano=aldeano;
        _rigidbody=rigidbody;
    }
	public void Tick()
    {
        // Se mueve en la direccion que dice a la velocidad que dice
        _rigidbody.MovePosition(_rigidbody.position + ((_aldeano.Objetivo-_rigidbody.position).normalized * _aldeano.speed));
    }
    public void OnEnter() {
		_animator.SetBool("Walk", true);
        _aldeano.ShowFloatingText("Caminando");
		//Debug.Log("Walk");
    }
    public void OnExit() {
    	_animator.SetBool("Walk", false);
    }
}