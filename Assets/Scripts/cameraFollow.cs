using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	
	public Transform target; 						//esta variable sirve para adaptar el componente transform de la camara al del personaje, cogiendo sus tres ejes
	public float damping = 1; 						//esta variable sirve para amortiguar el seguimiento de la camara en el valor que se le asigne
	public float lookAheadFactor = 3; 				//
	public float lookAheadReturnSpeed = 0.5f; 		//esta variable servira para 
	public float lookAheadMoveThreshold = 0.1f; 	//
	public float yPosRestriction = -1; 				//restringe la posicion y de la camara
	
	float offsetZ;					//crea una variable para la compensacion del eje Z
	Vector3 lastTargetPosition;		//crea un vector de 3 ejes al que se le asignara la posicion primitiva del target
	Vector3 currentVelocity;		//crea un vector de 3 ejes al que se le asignara la velocidad actual de la camara
	Vector3 lookAheadPos;			//crea un vector de 3 ejes al que se le asignara la posicion de cuando el personaje va hacia delante

	void Start () {
		lastTargetPosition = target.position;		//esta linea le da a la variable utilizada la posicion actual del target
		offsetZ = (transform.position - target.position).z;		
		//se le da a la variable offsetZ un valor que cambia la posicion del eje z, de forma que la camara no este en el mismo plano que el escenario
		transform.parent = null;		//??
	}

	void Update () {
		
		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;		
		
		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;
		
		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);
		
		newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y,yPosRestriction,Mathf.Infinity), newPos.z);
		transform.position = newPos;
		
		lastTargetPosition = target.position;		
	}
}