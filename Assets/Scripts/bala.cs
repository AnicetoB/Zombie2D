using UnityEngine;
using System.Collections;

public class bala : MonoBehaviour {

	public Vector2 velocity = new Vector2 (5, 0);
	public GameObject particulas;

	void Start () {
		//rigidbody2D.velocity = velocity * transform.localScale.x;
		rigidbody2D.AddForce (velocity * transform.localScale.x, ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D(Collision2D target){
		Choquebala ();
	}

	void Choquebala(){
		var posicionZ = new Vector3 (transform.position.x, transform.position.y, particulas.transform.position.z);
		var clone = Instantiate (particulas, posicionZ, Quaternion.identity) as GameObject;
		Destroy (clone, 1);
		Destroy (gameObject);
	}
}
