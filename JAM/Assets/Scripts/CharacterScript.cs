using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour {
	public LayerMask mask_ostacoli;
	public LayerMask mask_ground;
	public LayerMask mask_secondo;
	public LayerMask mask_fine;
	public LayerMask mask_discesa;

	Animator anim;
	
	float movimento = 0.12f;

	//velocità a cui si muove il personaggio
	float marcia = 0.12f;
	float decelerazione = 0f;

	//timer da attivare in caso di collisione con ostacoli
	float t = 0f;




	Rigidbody2D rb;
	bool doubleJump = true;
	bool pressed = false;
	bool IsGrounded = false;
	float tempoPressione = 0f;
	//public LayerMask mask;
	//Animator anim;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	
	}
	
	void Update () {
		if(marcia>0)
			transform.Translate(marcia, 0, 0);
		else{
			SceneManager.LoadScene("Scenes/Scena1", LoadSceneMode.Single);
		}
		marcia-=decelerazione;
		RaycastHit2D hituff = Physics2D.Raycast(transform.position-new Vector3(0, 0.1f, 0), Vector2.right, 0.5f, mask_ostacoli);
        if (hituff.collider != null) {
        	Debug.Log("Contatto");
        	anim.SetBool("inciamp", true);
			Physics2D.IgnoreLayerCollision(8, 10, true);
			marcia = movimento/2;
			t = 1.5f;
        }
        if(t>0){
        	t-=Time.deltaTime;
        }
        if(t<0){
        	anim.SetBool("inciamp", false);

			if(decelerazione==0)
        		marcia = movimento;
        	else
				marcia-=decelerazione;
        	t=0;
			Physics2D.IgnoreLayerCollision(8, 10, false);
        }


		RaycastHit2D hitfine = Physics2D.Raycast(transform.position, Vector2.right, 0.4f, mask_fine);
		if(hitfine.collider!=null){
			decelerazione = 0.01f;
		}
		//pressione di un tasto negli assi
		/*if(Input.GetButton("Fire1")){
			Physics2D.IgnoreLayerCollision(8, 9, true);
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
		}*/

			
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, mask_ground);
		RaycastHit2D hitc = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, mask_secondo);
        if (hit.collider != null) {
        	IsGrounded = true;
        	doubleJump = true;
        } else
         IsGrounded = false;
        	if (hitc.collider == null) {
					Physics2D.IgnoreLayerCollision(8, 11, true);
					/*if(decelerazione==0)
						marcia = movimento;*/
	        }
	        if (!IsGrounded && hitc.collider != null) {

			Debug.Log("Doppio parry");
					Physics2D.IgnoreLayerCollision(8, 11, false);
					marcia = 2 * movimento;
	        }



		if(IsGrounded){
			anim.SetBool("jump", false);
		}


		if(Input.GetButtonDown("Fire2"))
			pressed = true;
		if(pressed)
			tempoPressione += Time.deltaTime;
		if(tempoPressione>0.3){
			saltoLungo();
			pressed = false;
			tempoPressione = 0f;
		}
		if(Input.GetButtonUp("Fire2")){
			saltoNormale();
			pressed = false;
			tempoPressione = 0f;
		}




	}

	void saltoNormale(){
		if(IsGrounded || doubleJump){
			anim.SetBool("jump", true);
			float mod = 1;
			if(!IsGrounded){
				doubleJump = false;
				mod = 1.4f;
			}

       		rb.velocity = new Vector2(rb.velocity.x, 0);
        	//Debug.Log(doubleJump);
			rb.AddForce(new Vector2(0, 300 * mod));
		}
	}
	void saltoLungo(){
			rb.AddForce(new Vector2(600, 300));

	}
}

			/*
			parte per far partire un file audio in maniera programmatica
			*/
			/*AudioSource audio = GetComponent<AudioSource>();
			audio.Play();*/