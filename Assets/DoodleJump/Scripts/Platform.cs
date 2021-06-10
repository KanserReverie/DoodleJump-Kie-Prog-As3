using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	public float jumpForce = 12f;

	void OnCollisionEnter2D(Collision2D _collision)
	{
		if (_collision.relativeVelocity.y <= 0f)
		{
			Rigidbody2D myrb = _collision.collider.GetComponent<Rigidbody2D>();
			Animator myAnimator = _collision.collider.GetComponent<Animator>();

			if (myrb != null && myAnimator!=null)
			{
				Vector2 velocity = myrb.velocity;
				velocity.y = jumpForce;
				myrb.velocity = velocity;
				myAnimator.SetTrigger("hitPlatform");
			}
		}
	}
}
