using UnityEngine;

internal class Wait : IState
{
	private float escala;
	private readonly Animator _animator;
    private readonly Aldeano _aldeano;

    public float TimePassed;

    public Wait(Aldeano aldeano, Animator animator){
        _animator=animator;
        _aldeano=aldeano;
    }
	public void Tick()
    {
        TimePassed+=Time.deltaTime;
        Debug.Log("TimePassed " + TimePassed);
    }
    public void OnEnter() {
        TimePassed=0;
    }
    public void OnExit() { }
}