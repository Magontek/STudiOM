using UnityEngine;
using UnityEngine.Localization;

internal class Roam_random : IState
{
	private float escala;
	private readonly Aldeano _aldeano;

    public LocalizedString stringRef = new LocalizedString() { TableReference = "NPC_Garbage", TableEntryReference = "WALK" };
    
    

	public Roam_random(Aldeano aldeano){
        _aldeano=aldeano;
        escala=0.2f;
    }
	public void Tick()
    {
    	Vector2 randomVector = new Vector2(Random.value-0.5f, Random.value-0.5f);
    	randomVector.Normalize();
        _aldeano.Objetivo = randomVector*escala;
        _aldeano.speed=0.05f;
        //Debug.Log("random");
    }
    public void OnEnter() {
        var stringOperation = stringRef.GetLocalizedString();
    	_aldeano.ShowFloatingText(stringOperation.Result);
    }
    public void OnExit() { }
}