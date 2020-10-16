using UnityEngine;

internal class Roam_random : IState
{
	private readonly Aldeano _aldeano;
	private readonly Animator _animator;
	private readonly Rigidbody2D _rigidbody;

	public float TimeStuck;

	private Vector2 _last_position

	public void Tick()
    {
    	//Si la distancia recorrida desde la ultima vez es menor a la esperada entonces suma tiempo de atasco
            TimeStuck += Time.deltaTime;
    	if (Vector2.Distance(_rigidbody.position, _last_position)>= speed*Time.deltaTime) 
        _last_position=_gatherer.position;

        // Se mueve en la direccion que dice a la velocidad que dice
     	_rigidbody.velocity(_aldeano.direccion * speed);

    }
    public void OnEnter() {
    	_last_position=_gatherer.position;
		TimeStuck = 0f;
    }
    public void OnExit() {

    }
}