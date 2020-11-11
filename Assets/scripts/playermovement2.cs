using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement2 : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Animator animator;

    public int stuntime;
    public bool stunned2;
    public bool stunned1;
    public Transform stun1;
    public bool isJumping2;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        stunned2 = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stunned2 = Physics2D.OverlapCircle(stun1.position, 0.1f);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && !stunned1)
        {
            transform.position += -transform.right * speed;
            Vector3 scaler = transform.localScale;
            scaler.x = -0.6f;
            transform.localScale = scaler;
            animator.SetFloat("speed", 1);
        }
        else
        {
            animator.SetFloat("speed", 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !stunned1)
        {
            transform.position += transform.right * speed;
            Vector3 scaler = transform.localScale;
            scaler.x = 0.6f;
            transform.localScale = scaler;
            animator.SetFloat("speed", 1);
        }
        Jump();
    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isJumping2 && !stunned1)
        {
            isJumping2 = true;

            rb.AddForce((transform.up * jumpForce));

            animator.SetFloat("inair", 1);

        }
    }
    IEnumerator stun()
    {
        stunned1 = true;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(stuntime);
        GetComponent<SpriteRenderer>().color = Color.white;
        stunned1 = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("planet"))
        {
            isJumping2 = false;
            animator.SetFloat("inair", 0);

            rb.velocity = Vector2.zero;
        }
        if (other.gameObject.CompareTag("player1") && stunned2 == true)
        {
            StartCoroutine(stun());
            Debug.Log("player 2 stunned");
        }
    }
}