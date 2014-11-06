using UnityEngine;
using System.Collections;

public class balaScript : MonoBehaviour {

	public int vhorizontal = -1;
	Vector3 movimiento;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update() {
			movimiento = new Vector3 (vhorizontal, 0, 0);
			transform.Translate (movimiento * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){
				Destroy (this, 0);
		}
}
