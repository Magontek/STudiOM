using UnityEngine;
using UnityEngine.Localization;

internal class Roam_random : IState
{
	private float escala;
	private readonly Aldeano _aldeano;
	private readonly Rigidbody2D _rigidbody;

    public LocalizedString stringRef = new LocalizedString() { TableReference = "NPC_Garbage", TableEntryReference = "WALK" };
    
	public Roam_random(Aldeano aldeano,Rigidbody2D rigidbody){
        _aldeano=aldeano;
        escala=1f;
        _rigidbody=rigidbody;
    }
	public void Tick()
    {
    	Vector2 randomVector = new Vector2(Random.value-0.5f, Random.value-0.5f);
    	randomVector.Normalize();
        _aldeano.Objetivo = _rigidbody.position+(randomVector*escala);
        _aldeano.speed=0.01f;
        Debug.Log("Va a ir a " + _aldeano.Objetivo);
    }
    public void OnEnter() {
        var stringOperation = stringRef.GetLocalizedString();
    	_aldeano.ShowFloatingText(stringOperation.Result);
    	Debug.Log("Randomizando");
    }
    public void OnExit() { }
}