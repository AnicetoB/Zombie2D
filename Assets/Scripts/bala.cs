using UnityEngine;
using System.Collections;

public class bala : MonoBehaviour {

	public Vector2 velocity = new Vector2 (5, 0);

	void Start () {
		rigidbody2D.velocity = velocity * transform.localScale.x;
	}
}
