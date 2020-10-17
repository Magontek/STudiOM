using UnityEngine;
using UnityEngine.Localization;

internal class Walk_to : IState
{
	private readonly Aldeano _aldeano;
	private readonly Animator _animator;
	private readonly Rigidbody2D _rigidbody;

    public LocalizedString stringRef = new LocalizedString() { TableReference = "NPC_Garbage", TableEntryReference = "WALK" };

	public Walk_to(Aldeano aldeano, Animator animator,Rigidbody2D rigidbody){
        _animator=animator;
        _aldeano=aldeano;
        _rigidbody=rigidbody;
    }
	public void Tick()
    {
        // Calculo el vector direccion como la resta del objetivo menos la posicion
        // multiplico por la velocidad de tile/fps. Como esto se actualiza todos los frames tiene sentido
        // sumo el resultado a la posicion actual
        _rigidbody.MovePosition(_rigidbody.position + ((_aldeano.Objetivo-_rigidbody.position).normalized * _aldeano.speed));
    }
    public void OnEnter() {
		_animator.SetBool("Walk", true);
        // Float text de caminando
        var stringOperation = stringRef.GetLocalizedString();
        if (stringOperation.IsDone)
            _aldeano.ShowFloatingText(stringOperation.Result);
    }
    public void OnExit() {
    	_animator.SetBool("Walk", false);
    }
}