using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    // Public attriutes
    public int damage;
    public float minSpeed;
    public float maxSpeed;

    // Private attributes
    private float speed;

    Player player;

    // Start is called before the first frame update
    void Start(){
        speed = Random.Range(minSpeed, maxSpeed);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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

        // Pass on the damage this enemy can do to the player.
        player.TakeDamage(damage);
	}

    // Destory when enemy is off-screen
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
