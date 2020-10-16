using UnityEngine;

internal class Roam_random : IState
{
	private float escala;
	private readonly Aldeano _aldeano;
	public void Tick()
    {
    	Vector2 randomVector = new Vector2(Random.value, Random.value);
  
        _gatherer.Objetivo = randomVector.Normalize()*escala;
    }
    public void OnEnter() { }
    public void OnExit() { }
}