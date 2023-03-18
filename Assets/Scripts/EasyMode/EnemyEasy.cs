using UnityEngine;
using System.Collections;

public class EnemyEasy : MonoBehaviour {


	public static EnemyEasy instance;
	public float enemySpeed;

    private Rigidbody2D myBody;

    [SerializeField]private GameObject bullet;

	[SerializeField]private AudioClip _weaponEnemyClip;

	// Use this for initialization
	void Awake () {
        myBody = GetComponent<Rigidbody2D>();
    }

	void Start(){

        StartCoroutine(Shoot());
    }

	// Update is called once per frame
	void FixedUpdate () {
        myBody.velocity = new Vector2(0f, -enemySpeed);

    }

    void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Bounds") {
			Destroy (gameObject);
		}
	}

	IEnumerator Shoot(){

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        Vector3 temp = transform.position;
        temp.y -= 0.5f;
        Instantiate(bullet, temp, Quaternion.identity);

		AudioSource.PlayClipAtPoint (_weaponEnemyClip, temp);

		StartCoroutine (Shoot ());
	}
}
