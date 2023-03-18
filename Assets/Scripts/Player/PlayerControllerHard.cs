using UnityEngine;
using System.Collections;
using CnControls;


public class PlayerControllerHard : MonoBehaviour
{
    Gun[] guns;
    bool shoot;

    public float speed;

    private Rigidbody2D _myBody;

    [SerializeField] private GameObject _bullet,bullet2tia,bullet3tia;

    [SerializeField] private AudioClip _weaponClip;

    [SerializeField] private GameObject _explosionPlayer;

    [SerializeField] private AudioClip _explosionPlayerClip;
    private bool canShoot = true;

    // Start is called before the first frame update
    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = CnInputManager.GetAxis("Horizontal") * speed;
        float v = CnInputManager.GetAxis("Vertical") * speed;
        _myBody.velocity = new Vector2(h, v);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
                if (GamePlayController.instance.playerScore > 20)
                {
                    foreach (Gun gun in guns)
                    {
                        if (gun.gameObject.activeSelf)
                        {
                            gun.Shoot();
                        }
                    }
                }
            }

        }

        //shoot = Input.GetKeyDown(KeyCode.LeftControl);
        //if (shoot)
        //{
        //    shoot = false;
        //    foreach(Gun gun in guns)
        //    {
        //        if (gun.gameObject.activeSelf)
        //        {
        //            gun.Shoot();
        //        }
        //    }
        //}

    }

    IEnumerator Shoot()
    {
        if (GamePlayController.instance.playerScore <= 10)
        {
            canShoot = false;
            yield return new WaitForSeconds(0.3f);

            Vector3 temp = transform.position;
            temp.y += 0.5f;
            Instantiate(_bullet, temp, Quaternion.identity);

            AudioSource.PlayClipAtPoint(_weaponClip, temp);

            //StartCoroutine (Shoot ());
            canShoot = true;
        };

        if (10 <= GamePlayController.instance.playerScore && GamePlayController.instance.playerScore <= 20)
        {
            canShoot = false;
            yield return new WaitForSeconds(0.3f);

            Vector3 temp = transform.position;
            temp.y += 0.5f;
            Instantiate(bullet2tia, temp, Quaternion.identity);

            AudioSource.PlayClipAtPoint(_weaponClip, temp);

            //StartCoroutine (Shoot ());
            canShoot = true;
        };

        if (GamePlayController.instance.playerScore > 20)
        {
            canShoot = false;
            yield return new WaitForSeconds(0.3f);

            Vector3 temp = transform.position;
            temp.y += 0.5f;
            Instantiate(bullet3tia, temp, Quaternion.identity);

            AudioSource.PlayClipAtPoint(_weaponClip, temp);

            //StartCoroutine (Shoot ());
            canShoot = true;
        };
        //canShoot = false;
        //yield return new WaitForSeconds(0.3f);

        //Vector3 temp = transform.position;
        //temp.y += 0.5f;
        //Instantiate(_bullet, temp, Quaternion.identity);

        //AudioSource.PlayClipAtPoint(_weaponClip, temp);

        ////StartCoroutine (Shoot ());
        //canShoot = true;

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy" || target.tag == "Rock" || target.tag == "RedBullet")
        {
            Destroy(gameObject);
            Destroy(target.gameObject);
            _explosionPlayer = (GameObject)Instantiate(_explosionPlayer, target.transform.position, Quaternion.identity);
            Destroy(_explosionPlayer, 1);

            if (GamePlayController.instance != null)
            {
                GamePlayController.instance._PlayerDied();
            }

            AudioSource.PlayClipAtPoint(_explosionPlayerClip, transform.position);
        }
    }
}
