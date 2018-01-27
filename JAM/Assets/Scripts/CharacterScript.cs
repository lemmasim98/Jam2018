using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {

	public LayerMask mask;
	public LayerMask mask1;
	Animator anim;
	public float marcia = 0.15f;
	float t = 0f;




	Rigidbody2D rb;
	bool doubleJump = true;
	//public LayerMask mask;
	public LayerMask mask2;
	//Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();



		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(marcia, 0, 0);
		RaycastHit2D hituff = Physics2D.Raycast(transform.position, Vector2.right, 0.4f, mask);
        if (hituff.collider != null) {
        	Debug.Log("Contatto");
        	anim.SetBool("inciamp", true);
			Physics2D.IgnoreLayerCollision(8, 10, true);
			marcia = 0.75f;
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

			bool IsGrounded = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, mask1);
		RaycastHit2D hitc = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, mask2);
        if (hit.collider != null) {
        	IsGrounded = true;
        	doubleJump = true;
        }
        	if (hitc.collider == null) {
					Physics2D.IgnoreLayerCollision(8, 11, true);
					marcia = 0.15f;
	        }
	        if (!IsGrounded && hitc.collider != null) {

			Debug.Log("Doppio parry");
					Physics2D.IgnoreLayerCollision(8, 11, false);
					marcia = 0.3f;
	        }


		if(Input.GetButton("Fire1") && (IsGrounded || doubleJump)){
			anim.SetBool("jump", true);
			float mod = 1;
			if(!IsGrounded){

			Debug.Log("Doppio salto");
				doubleJump = false;
				mod = 1.8f;
			}

       		rb.velocity = new Vector2(rb.velocity.x, 0);
        	//Debug.Log(doubleJump);
			rb.AddForce(new Vector2(0, 200 * mod));
		}
		if(IsGrounded){
			anim.SetBool("jump", false);
		}



	}
}

			/*
			parte per far partire un file audio in maniera programmatica
			*/
			/*AudioSource audio = GetComponent<AudioSource>();
			audio.Play();*/