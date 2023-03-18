using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public float speed = 2;

    private Rigidbody2D _myBody;



  

    [SerializeField] private AudioClip _explosionEnemyClip, _explosionRockClip, _explosionBulletClip;
    // Use this for initialization
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    public Vector2 velocity;

    //public bool isEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bounds")
        {
            Destroy(gameObject);
        }

        if (target.tag == "RedBullet")
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
            //_explosionBullet = (GameObject)Instantiate(_explosionBullet, target.transform.position, Quaternion.identity);
            //Destroy(_explosionBullet, 1);
            //AudioSource.PlayClipAtPoint(_explosionBulletClip, target.transform.position);

        }

        if (target.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
            //_explosionEnemy = (GameObject)Instantiate(_explosionEnemy, target.transform.position, Quaternion.identity);
            //Destroy(_explosionEnemy, 1);
            GamePlayController.instance.playerScore += 3;
            //AudioSource.PlayClipAtPoint(_explosionEnemyClip, target.transform.position);
        }

        if (target.tag == "Rock")
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
            //_explosionRock = (GameObject)Instantiate(_explosionRock, target.transform.position, Quaternion.identity);
            //Destroy(_explosionRock, 1);
            GamePlayController.instance.playerScore++;
            //AudioSource.PlayClipAtPoint(_explosionRockClip, target.transform.position);

        }
    }
}
