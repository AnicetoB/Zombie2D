using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour {
	public GameObject sangre;
	public GameObject blood;
	public int live = 100;
	public RectTransform livebar;
	public Text liveText;
	public AudioClip sound;
	
	private float rectLive; 
	private int maxLive;
	// Use this for initialization
	void Start () {
		if(livebar!=null){
			rectLive = livebar.rect.width / live;
		}
		maxLive = live;
	}
	
	// Update is called once per frame
	void Update () {
		if(live <=0){
			muerte();
		}
		if (live > maxLive) {
			live = maxLive;		
		}
	}
	
	public void hurt(int damage){
		live = live - damage;
		var position = new Vector3 (transform.position.x, transform.position.y, -5);
		if(sangre != null){
			var clone = Instantiate(sangre,position,Quaternion.identity) as GameObject;
			clone.particleSystem.startColor =  Color.red;
			Destroy(clone,1);
		}
		
		if(blood != null){
			var clone2 =Instantiate(blood,transform.position,Random.rotation) as GameObject;
		}
		
		if(livebar!=null){
			livebar.sizeDelta = new Vector2( live*rectLive, livebar.rect.height);
		}
		
		if(sound!=null){
			audio.PlayOneShot(sound);
		}
		
		if (liveText != null) {
			liveText.text = live.ToString();
		}
		
	}
	
	public void health(int vida){
		live = live + vida;
		if (live > maxLive)
			live = maxLive;
		
		if(livebar!=null){
			livebar.sizeDelta = new Vector2( live*rectLive, livebar.rect.height);
		}
		
		if (liveText != null) {
			liveText.text = live.ToString();
		}
		
	}
	
	
	void muerte(){
		Destroy(gameObject);
	}
	

	/*
	void OnCollisionEnter2D(Collision2D target){
		
				if (target.transform.tag == tagDamage) {
					hurt(5);
				}
	}*/
	
	
}