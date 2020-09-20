using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public float minSpeed;
    public float maxSpeed;

    private float speed;

    // Start is called before the first frame update
    void Start(){
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

	// 2D Collision detection
	void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Player")) {
            return;
		}
		print("WE HIT THE PLAYER!");
	}
}
