using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

	public LayerMask mask;
	Animator anim;
	float marcia = 0.1f;
	float t = 0f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(marcia, 0, 0);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.4f, mask);
        if (hit.collider != null) {
        	Debug.Log("Contatto");
        	anim.SetBool("inciamp", true);
			Physics2D.IgnoreLayerCollision(8, 10, true);
			marcia = 0.05f;
			t = 1.5f;
        }
        if(t>0){
        	t-=Time.deltaTime;
        }
        if(t<0){
        	anim.SetBool("inciamp", false);
        	marcia = 0.1f;
        	t=0;
        }
		//pressione di un tasto negli assi
		/*if(Input.GetButton("Fire1")){
			Physics2D.IgnoreLayerCollision(8, 9, true);
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
		}*/
	}
}

			/*
			parte per far partire un file audio in maniera programmatica
			*/
			/*AudioSource audio = GetComponent<AudioSource>();
			audio.Play();*/