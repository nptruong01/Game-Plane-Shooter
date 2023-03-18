using UnityEngine;
using System.Collections;

public class SpanwerEnemy : MonoBehaviour {

	[SerializeField]private GameObject[] _enemies;

    [SerializeField] private GameObject _boss1;
    private bool canBoss = true;

    private BoxCollider2D _box;

	// Use this for initialization
	void Awake () {
		_box = GetComponent<BoxCollider2D> ();
	}

	void Start(){
		StartCoroutine (Spanwer ());
        
        //StartCoroutine (Spanwer2 ());
        //StartCoroutine (Spanwer3 ());
        //StartCoroutine (Spanwer4 ());
        //StartCoroutine (Spanwer5 ());
        //StartCoroutine (Spanwer6 ());
        //StartCoroutine (Spanwer7 ());



    }
    void Update()
    {
        if (GamePlayController.instance.playerScore > 10)
        {
            if (canBoss)
            {
                StartCoroutine(Boss());
            }

        }
    }

    IEnumerator Boss()
    {
        canBoss = false;
        yield return new WaitForSeconds(20);

        Vector3 temp = transform.position;
        temp.y += 0.5f;
        Instantiate(_boss1, temp, Quaternion.identity);

        //AudioSource.PlayClipAtPoint(_weaponClip, temp);

        //StartCoroutine (Shoot ());
        canBoss = true;

    }

    IEnumerator Spanwer(){

		if (GamePlayController.instance.playerScore <= 10) {
			yield return new WaitForSeconds (Random.Range (1, 3));
		}

		if ( 10 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 30) {
			yield return new WaitForSeconds (Random.Range (0.5f, 2));
		}

        if (GamePlayController.instance.playerScore > 30)
        {
            yield return new WaitForSeconds(Random.Range(0.35f, 1));
        }

  //      if ( 20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 40) {
		//	yield return new WaitForSeconds (Random.Range (0.4f, 3));
		//}

		//if ( 40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
		//	yield return new WaitForSeconds (Random.Range (0.3f, 2));
		//}

		//if ( 60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 100) {
		//	yield return new WaitForSeconds (Random.Range (0.2f, 1));
		//}

		
		float minX = -_box.bounds.size.x/2;
		float maxX = _box.bounds.size.x/2;

		Vector3 temp = transform.position;

		temp.x = Random.Range (minX, maxX);

		int enemiesRandomIndex = Random.Range (0, _enemies.Length);


		Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        

        StartCoroutine (Spanwer ());

	}




        //IEnumerator Spanwer1(){

        //	if (GamePlayController.instance.playerScore <= 15) {
        //		yield return new WaitForSeconds (Random.Range (1, 5));
        //	}

        //	if ( 15 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 35) {
        //		yield return new WaitForSeconds (Random.Range (1, 4));
        //	}

        //	if ( 35 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 55) {
        //		yield return new WaitForSeconds (Random.Range (1, 3));
        //	}

        //	if ( 55 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 75) {
        //		yield return new WaitForSeconds (Random.Range (0.8f, 2));
        //	}

        //	if ( 75 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 95) {
        //		yield return new WaitForSeconds (Random.Range (0.6f, 1.5f));
        //	}

        //	if (GamePlayController.instance.playerScore > 95) {
        //		yield return new WaitForSeconds (Random.Range (0.4f, 1));
        //	}
        //	float minX = -_box.bounds.size.x/2;
        //	float maxX = _box.bounds.size.x/2;

        //	Vector3 temp = transform.position;

        //	temp.x = Random.Range (minX, maxX);

        //	int enemiesRandomIndex = Random.Range (0, _enemies.Length);


        //	Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        //	StartCoroutine (Spanwer1 ());

        //}

        //IEnumerator Spanwer2(){
        //	if (GamePlayController.instance.playerScore <= 10) {
        //		yield return new WaitForSeconds (Random.Range (1.5f, 5));
        //	}

        //	if ( 10 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 20) {
        //		yield return new WaitForSeconds (Random.Range (1.2f, 4));
        //	}

        //	if ( 20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 40) {
        //		yield return new WaitForSeconds (Random.Range (1.0f, 3));
        //	}

        //	if ( 40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
        //		yield return new WaitForSeconds (Random.Range (0.8f, 2));
        //	}

        //	if ( 60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 80) {
        //		yield return new WaitForSeconds (Random.Range (0.6f, 1));
        //	}

        //	if ( GamePlayController.instance.playerScore > 80) {
        //		yield return new WaitForSeconds (Random.Range (0.4f, 0.8f));
        //	}



        //	float minX = -_box.bounds.size.x/2;
        //	float maxX = _box.bounds.size.x/2;

        //	Vector3 temp = transform.position;

        //	temp.x = Random.Range (minX, maxX);

        //	int enemiesRandomIndex = Random.Range (0, _enemies.Length);


        //	Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        //	StartCoroutine (Spanwer2 ());

        //}

        //IEnumerator Spanwer3(){
        //	if ( GamePlayController.instance.playerScore <= 15) {
        //		yield return new WaitForSeconds (Random.Range (2, 5));
        //	}

        //	if ( 15 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 35) {
        //		yield return new WaitForSeconds (Random.Range (1.5f, 4));
        //	}

        //	if ( 35 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 55) {
        //		yield return new WaitForSeconds (Random.Range (1, 3));
        //	}

        //	if ( 55 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 75) {
        //		yield return new WaitForSeconds (Random.Range (0.8f, 2));
        //	}

        //	if ( 75 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 95) {
        //		yield return new WaitForSeconds (Random.Range (0.6f, 1));
        //	}

        //	if (GamePlayController.instance.playerScore > 95) {
        //		yield return new WaitForSeconds (Random.Range (0.4f, 0.8f));
        //	}


        //	float minX = -_box.bounds.size.x/2;
        //	float maxX = _box.bounds.size.x/2;

        //	Vector3 temp = transform.position;

        //	temp.x = Random.Range (minX, maxX);

        //	int enemiesRandomIndex = Random.Range (0, _enemies.Length);


        //	Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        //	StartCoroutine (Spanwer3 ());

        //}

        //IEnumerator Spanwer4(){
        //	if ( GamePlayController.instance.playerScore <= 15) {
        //		yield return new WaitForSeconds (Random.Range (2, 5));
        //	}

        //	if ( 15 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 35) {
        //		yield return new WaitForSeconds (Random.Range (1.5f, 4));
        //	}

        //	if ( 35 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 55) {
        //		yield return new WaitForSeconds (Random.Range (1, 3));
        //	}

        //	if ( 55 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 75) {
        //		yield return new WaitForSeconds (Random.Range (0.8f, 2));
        //	}

        //	if ( 75 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 95) {
        //		yield return new WaitForSeconds (Random.Range (0.6f, 1));
        //	}

        //	if (GamePlayController.instance.playerScore > 95) {
        //		yield return new WaitForSeconds (Random.Range (0.4f, 0.8f));
        //	}


        //	float minX = -_box.bounds.size.x/2;
        //	float maxX = _box.bounds.size.x/2;

        //	Vector3 temp = transform.position;

        //	temp.x = Random.Range (minX, maxX);

        //	int enemiesRandomIndex = Random.Range (0, _enemies.Length);


        //	Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        //	StartCoroutine (Spanwer4 ());

        //}

        //IEnumerator Spanwer5(){
        //	if (GamePlayController.instance.playerScore <= 10) {
        //		yield return new WaitForSeconds (Random.Range (1.5f, 5));
        //	}

        //	if ( 10 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 20) {
        //		yield return new WaitForSeconds (Random.Range (1.2f, 4));
        //	}

        //	if ( 20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 40) {
        //		yield return new WaitForSeconds (Random.Range (1.0f, 3));
        //	}

        //	if ( 40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
        //		yield return new WaitForSeconds (Random.Range (0.8f, 2));
        //	}

        //	if ( 60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 80) {
        //		yield return new WaitForSeconds (Random.Range (0.6f, 1));
        //	}

        //	if ( GamePlayController.instance.playerScore > 80) {
        //		yield return new WaitForSeconds (Random.Range (0.4f, 0.8f));
        //	}



        //	float minX = -_box.bounds.size.x/2;
        //	float maxX = _box.bounds.size.x/2;

        //	Vector3 temp = transform.position;

        //	temp.x = Random.Range (minX, maxX);

        //	int enemiesRandomIndex = Random.Range (0, _enemies.Length);


        //	Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        //	StartCoroutine (Spanwer5 ());

        //}

        //IEnumerator Spanwer6(){

        //	if (GamePlayController.instance.playerScore <= 10) {
        //		yield return new WaitForSeconds (Random.Range (0.8f, 5));
        //	}

        //	if ( 10 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 20) {
        //		yield return new WaitForSeconds (Random.Range (0.6f, 4));
        //	}

        //	if ( 20 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 40) {
        //		yield return new WaitForSeconds (Random.Range (0.4f, 3));
        //	}

        //	if ( 40 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 60) {
        //		yield return new WaitForSeconds (Random.Range (0.3f, 2));
        //	}

        //	if ( 60 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 100) {
        //		yield return new WaitForSeconds (Random.Range (0.2f, 1));
        //	}

        //	if (GamePlayController.instance.playerScore > 100) {
        //		yield return new WaitForSeconds (Random.Range (0.1f, 0.8f));
        //	}
        //	float minX = -_box.bounds.size.x/2;
        //	float maxX = _box.bounds.size.x/2;

        //	Vector3 temp = transform.position;

        //	temp.x = Random.Range (minX, maxX);

        //	int enemiesRandomIndex = Random.Range (0, _enemies.Length);


        //	Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        //	StartCoroutine (Spanwer6 ());

        //}

        //IEnumerator Spanwer7(){

        //	if (GamePlayController.instance.playerScore <= 15) {
        //		yield return new WaitForSeconds (Random.Range (1, 5));
        //	}

        //	if ( 15 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 35) {
        //		yield return new WaitForSeconds (Random.Range (1, 4));
        //	}

        //	if ( 35 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 55) {
        //		yield return new WaitForSeconds (Random.Range (1, 3));
        //	}

        //	if ( 55 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 75) {
        //		yield return new WaitForSeconds (Random.Range (0.8f, 2));
        //	}

        //	if ( 75 < GamePlayController.instance.playerScore && GamePlayController.instance.playerScore  <= 95) {
        //		yield return new WaitForSeconds (Random.Range (0.6f, 1.5f));
        //	}

        //	if (GamePlayController.instance.playerScore > 95) {
        //		yield return new WaitForSeconds (Random.Range (0.4f, 1));
        //	}
        //	float minX = -_box.bounds.size.x/2;
        //	float maxX = _box.bounds.size.x/2;

        //	Vector3 temp = transform.position;

        //	temp.x = Random.Range (minX, maxX);

        //	int enemiesRandomIndex = Random.Range (0, _enemies.Length);


        //	Instantiate (_enemies[enemiesRandomIndex], temp, Quaternion.identity);

        //	StartCoroutine (Spanwer7 ());

        //}
    }
