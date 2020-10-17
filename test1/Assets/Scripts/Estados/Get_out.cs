using UnityEngine;
using UnityEngine.Localization;


internal class Get_out : IState
{
	private float escala;
	private readonly Rigidbody2D _rigidbody;
    private readonly Aldeano _aldeano;

    public Vector2 _thingdirection;

    public LocalizedString stringRef = new LocalizedString() { TableReference = "NPC_Garbage", TableEntryReference = "WALL_COLIDE" };

    public Get_out(Aldeano aldeano,Rigidbody2D rigidbody,Vector2 ThingDirection){
        _aldeano=aldeano;
        _rigidbody=rigidbody;
        _thingdirection=ThingDirection;
        escala=1f;
    }
	public void Tick()
    {
    	_thingdirection=_aldeano.detector.ThingDirection;
    	Vector2 randomVector;
    	Vector2 dir_salida;
    	if(_thingdirection != Vector2.zero){
    		randomVector = new Vector2(1, Random.value-0.5f);
    		randomVector.Normalize();
    		float angulo = Mathf.Atan2(_thingdirection.y, _thingdirection.x) * Mathf.Rad2Deg;
    		dir_salida = Quaternion.Euler(0, 0, angulo) * randomVector;
    		Debug.Log("Choque direccion = " + angulo + " saliendo para = " + dir_salida);
    		_aldeano.detector.WallInRange=false;
    	}
    	else{
    		randomVector = new Vector2(Random.value-0.5f, Random.value-0.5f);
    		randomVector.Normalize();
    		dir_salida=randomVector;
    	}

        _aldeano.Objetivo = _rigidbody.position+(dir_salida*escala);
        _aldeano.speed=0.01f;


        // Float text de caminando
        var stringOperation = stringRef.GetLocalizedString();
        _aldeano.ShowFloatingText(stringOperation.Result);
    }
    public void OnEnter() {
        //Debug.Log("Getting out");

    }
    public void OnExit() { }
}