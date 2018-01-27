using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2 : MonoBehaviour {
	Rigidbody2D rb;
	bool doubleJump = true;
	public LayerMask mask;
	public LayerMask mask2;
	Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim= GetComponent<Animator>();
	}

	
	// Update is called once per frame
	void Update () {
	bool IsGrounded = false;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, mask);
		RaycastHit2D hitc = Physics2D.Raycast(transform.position, -Vector2.up, 0.8f, mask2);
        if (hit.collider != null) {
        	IsGrounded = true;
        	doubleJump = true;
        }
        	if (hitc.collider == null) {
					Physics2D.IgnoreLayerCollision(8, 11, true);
	        }
	        if (!IsGrounded && hitc.collider != null) {

			Debug.Log("Doppio parry");
					Physics2D.IgnoreLayerCollision(8, 11, false);
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
