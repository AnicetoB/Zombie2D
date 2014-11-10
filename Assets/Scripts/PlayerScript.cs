using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject proyectil;
	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(2,3);
	public bool mirarderecha = true;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var forceX = 0f;
		var forceY = 0f;

		if (Input.GetKey ("right")) {
			mirarderecha = true;
			if (absVelX < maxVelocity.x)
				forceX = speed;
			this.transform.localScale = new Vector3 (1, 1, 1);
			anim.SetBool("andar",true); 

		}else if (Input.GetKey ("left")) {
			mirarderecha = false;
			if (absVelX < maxVelocity.x)
				forceX = -speed;
			this.transform.localScale = new Vector3 (-1, 1, 1);
			anim.SetBool("andar",true); 

		}else if (Input.GetKeyUp ("left") || Input.GetKeyUp ("right")){
			anim.SetBool("andar",false); 
		}
		rigidbody2D.AddForce(new Vector2 (forceX, forceY));

		if (Input.GetKeyDown ("space") || Input.GetKeyDown ("c")) {
			anim.SetBool ("disparar", true); 
		} else { 
			anim.SetBool ("disparar", false);
		}
	}
}