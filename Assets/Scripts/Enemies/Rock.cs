using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	private float _speed;

	private Rigidbody2D _myBody;

	// Use this for initialization
	void Awake () {
		_myBody = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		if ( GamePlayController.instance.playerScore <= 10) {
			_speed = Random.Range (-2.5f, -5);
		};
		if ( 10 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 20) {
			_speed = Random.Range (-3.5f, -6);
		};

		if ( 20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 30) {
			_speed = Random.Range (-5, -7);
		};

		if ( 30 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 40) {
			_speed = Random.Range (-6, -8);
		};

		if ( 40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 50) {
			_speed = Random.Range (-7, -9);
		};

		if ( 50 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
			_speed = Random.Range (-8, -10);
		};

		if ( 60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 70) {
			_speed = Random.Range (-9, -11);
		};

		if ( 70 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 80) {
			_speed = Random.Range (-8, -13);
		};

		if ( 80 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 90) {
			_speed = Random.Range (-12, -15);
		};

		if ( 90 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 100) {
			_speed = Random.Range (-14, -17);
		};

        if (100 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 110)
        {
            _speed = Random.Range(-15, -18);
        };

        if ( GamePlayController.instance.playerScore > 110) {
			_speed = Random.Range (-17, -20);
		};

		_myBody.angularVelocity = Random.Range (0, 400);
	}

	// Update is called once per frame
	void FixedUpdate () {
		_myBody.velocity = new Vector2 (_myBody.velocity.x, _speed);
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bounds") {
			Destroy (gameObject);
		}
	}
}
