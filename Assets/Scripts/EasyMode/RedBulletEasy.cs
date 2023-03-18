using UnityEngine;
using System.Collections;

public class RedBulletEasy : MonoBehaviour {


    public float speed;

    private Rigidbody2D _myBody;

	// Use this for initialization
	void Awake () {
		_myBody = GetComponent<Rigidbody2D> ();
	}


	// Update is called once per frame 
	void FixedUpdate () {
		
		_myBody.velocity = new Vector2 (_myBody.velocity.x, -speed );
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bounds") {
			Destroy (gameObject);
		}
	}
}
