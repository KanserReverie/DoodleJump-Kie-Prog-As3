using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doodleJump
{
    public class Player : MonoBehaviour
    {
        public float movementSpeed = 8f;
        public Animator myAnimator;
        private float movement = 0f;
        private Rigidbody2D myrb;
        public GameObject GameOver;
        public GameObject WinMenu;
        // Start is called before the first frame update
        void Start()
        {
            myAnimator = GetComponent<Animator>();
            myrb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            movement = Input.GetAxis("Horizontal") * movementSpeed;

        }
        void FixedUpdate()
        {
            Vector2 velocity = myrb.velocity;
            velocity.x = movement;
            myrb.velocity = velocity;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            print("collision");
            if (collision.gameObject.tag == "Lose")
            {
                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else if (collision.gameObject.tag == "Finish")
            {
                Time.timeScale = 0;
                WinMenu.gameObject.SetActive(true);
            }
        }

    }
}