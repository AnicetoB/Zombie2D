using UnityEngine;
using System.Collections;

public class disparo : MonoBehaviour {

	public GameObject bala;
	public Transform puntoDisparo;
	

	public void Disparo(){
		if (bala != null) {
			var clone = Instantiate(bala, puntoDisparo.position,
		                        Quaternion.identity) as GameObject;
			clone.transform.localScale = transform.localScale;
		}
	}
}
