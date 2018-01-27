using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public float marcia = 0.1f;
	public float mod = 1;
	public Rigidbody2D rb;
	public SpriteRenderer render;
	public bool doubleJump = true;
	public bool IsGrounded;
	public float t = 0f;
	public LayerMask mask_ground;
	public LayerMask mask_secondo;
	float decelerazione = 0f;
	Animator anim;
	float movimento = 0.12f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();			//rigidBody initialization
		render = GetComponent<SpriteRenderer> ();
		anim= GetComponent<Animator>();
		bool doubleJump = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		marcia-=decelerazione;
		if(marcia>0)
			transform.Translate(marcia, 0, 0);
		/*else{
			SceneManager.LoadScene("Scenes/Scena1", LoadSceneMode.Single);
		}*/

		
		RaycastHit2D hitc = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, mask_secondo);
       
        
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


		if(Input.GetButtonDown("Fire1") && (IsGrounded || doubleJump)){
			anim.SetBool("jump", true);
			if(!IsGrounded){
				Debug.Log("Doppio salto");
				doubleJump = false;
				Physics2D.IgnoreLayerCollision(8, 11, false);
			}
			IsGrounded = false;
			rb.velocity = new Vector2(rb.velocity.x, 0);
			rb.AddForce(new Vector2(0, 200 * mod));
		}
		if(IsGrounded){
			anim.SetBool("jump", false);
		}

		if(t>0){
			t-=Time.deltaTime;
		}
		if (t < 0) {
			//anim.SetBool("inciamp", false);
			Physics2D.IgnoreLayerCollision (8, 10, false);
			marcia *= 2;
			t = 0;
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {				//upon touching ground reset vars
		if (coll.gameObject.layer == 9) {
			IsGrounded = true;						
			doubleJump = true;
			
			Physics2D.IgnoreLayerCollision(8, 11, true);
		}
		if (coll.gameObject.layer == 10) {
			Debug.Log ("Ouch");
			//anim.SetBool("inciamp", true);
			Physics2D.IgnoreLayerCollision (8, 10, true);
			marcia /= 2;
			t = 1.5f;
		}
		if (coll.gameObject.layer == 11) {
			anim.SetBool("jump", false);
			Debug.Log("roba");
			decelerazione = 0.01f;
		}
		if (coll.gameObject.layer == 12) {
			Debug.Log("roba");
			decelerazione = 0.01f;
		}

	}

	void OnCollisionStay2D (Collision2D coll) {
		if (coll.gameObject.layer == 11) {
			rb.gravityScale = 0.0f;
		} 
	}

	void OnCollisionExit2D (Collision2D coll) {
		rb.gravityScale = 1.0f;
	}

	public void example(){
		Debug.Log ("Esperimento riuscito");
	}
}
