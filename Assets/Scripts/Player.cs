using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;

    private float input;

    Animator anime;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void Update(){
        bool flag = input != 0 ? true : false;
        int angleAxisY = input < 0 ? 180 : 0;

        anime.SetBool ("isRunning", flag);
        transform.eulerAngles = new Vector3 (0, angleAxisY, 0);
    }

    void FixedUpdate(){
        // Storing player's input 
        input = Input.GetAxisRaw("Horizontal");

        // Moving player
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            // Destroy player game object
            Destroy(gameObject);
		}
	}
}