using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Sprite deadSprite;
    public float jumpForce = 200f;
    public float doubleJumpInterval = 1f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Animator animator;
    private float lastJumpTime;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (!GameController.instance.gameOver)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * jumpForce);
                audioSource.Play();
            }
#if UNITY_ANDROID
            if(Input.touchCount > 0)
            {
                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    rb.velocity = Vector2.zero;
                    rb.AddForce(Vector2.up * jumpForce);
                    audioSource.Play();
                }
            }
#endif
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.instance.IncreaseScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameController.instance.gameOver = true;
        Die();
    }

    private void Die()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        animator.SetBool("dead", true);
    }

}
