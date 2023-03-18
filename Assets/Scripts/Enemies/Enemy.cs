using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public static Enemy instance;
	private float _speed;

	private Rigidbody2D _myBody;

	[SerializeField]private GameObject _bullet;

	[SerializeField]private AudioClip _weaponEnemyClip;

	// Use this for initialization
	void Awake () {
		_myBody = GetComponent<Rigidbody2D> ();
	}

	void Start(){
		
		if ( GamePlayController.instance.playerScore < 10) {
			_speed = Random.Range (-1, -3);
		};

		if ( 10 <= GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 20) {
				_speed = Random.Range (-2, -4);
		};
        if (GamePlayController.instance.playerScore > 20)
        {
            _speed = Random.Range(-3, -5);
        };

        //if ( 20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <=30) {
        //	_speed = Random.Range (-4, -6);
        //};

        //if ( 30 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 40) {
        //	_speed = Random.Range (-5, -7);
        //};

        //if ( 40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 50) {
        //	_speed = Random.Range (-6, -8);
        //};

        //if ( 50 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
        //	_speed = Random.Range (-7, -9);
        //};

        //if ( 60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 70) {
        //	_speed = Random.Range (-8, -10);
        //};

        //if ( 70 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 80) {
        //	_speed = Random.Range (-9, -11);
        //};

        //if ( 80 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 90) {
        //	_speed = Random.Range (-10, -12);
        //};

        //if ( 90 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 100) {
        //	_speed = Random.Range (-11, -13);
        //};


        StartCoroutine (Shoot ());
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

	IEnumerator Shoot(){
		
		if ( GamePlayController.instance.playerScore <= 30) {
			yield return new WaitForSeconds (Random.Range (0.7f, 1f))  ;
		};

		if ( 30 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
			yield return new WaitForSeconds (Random.Range (0.4f, 0.7f))  ;
		};

		if (GamePlayController.instance.playerScore > 60) {
			yield return new WaitForSeconds (Random.Range (0.2f, 0.5f))  ;
		};

		Vector3 temp = transform.position;

		if (GamePlayController.instance.playerScore <= 20) {
			temp.y -= 0.4f;
		};

		if ( 20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 40) {
			temp.y -= 0.35f;
		};

		if ( 40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
			temp.y -= 0.3f;
		};

		if ( 60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 80) {
			temp.y -= 0.25f;
		};


		if (GamePlayController.instance.playerScore > 80) {
			temp.y -= 0.3f;
		};



		Instantiate (_bullet, temp, Quaternion.identity);

		AudioSource.PlayClipAtPoint (_weaponEnemyClip, temp);

		StartCoroutine (Shoot ());
	}
}
