using UnityEngine;
using System.Collections;

public class hurtSystem : MonoBehaviour {
	public string tagDamage = "Default";
	public int damage = 5;
	public float force = 0;
	public bool destroyOnCollision = false;
	
	private DamageSystem ds;
	
	void OnCollisionStay2D(Collision2D target){
		
		if (target.transform.tag == tagDamage) {
			Debug.Log (target.transform.tag);
			ds = target.transform.GetComponent<DamageSystem>();
			if(ds){
				Debug.Log(tagDamage + ":"+damage);
				ds.hurt(damage);
				if(force > 0){
					var direction = target.transform.position - transform.position  ;
					ds.rigidbody2D.AddForce(direction.normalized * force/10,ForceMode2D.Impulse);
				}
			}
			
		}
		
		if (destroyOnCollision) {
			Destroy(gameObject);
		}
	}
}