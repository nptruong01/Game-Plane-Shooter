using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    //public HealthbarBoss healthbarBoss;
    //public float health = 20f;
    //float barFillAmount = 1f;
    //float damage = 0;

    //public HealthbarEnemy healthbarEnemy;
    //public float health = 10f;
    //float barSize = 1f;
    //float damage = 0;

    [SerializeField] private GameObject  _explosionBoss;

    [SerializeField] private AudioClip  _explosionBossClip;


    // Enemy Health
    //public Healthbar healthbar;
    //public float health = 3f;
    //float barFillAmount = 1f;
    //float damage = 0;

    public HealthbarBoss1 healthbarBoss1;
    public float health = 10f;
    float barSize = 1f;
    float damage = 0;


    [SerializeField] private GameObject projectileToSpawn; //Projectile to spawn
    [SerializeField] private float fireRate = 0.3f;
    [SerializeField] private Vector2 projectileSpawnOffset = new Vector2(0f, -1.3f);
    [SerializeField] private Vector2 projectileSpawnOffset1 = new Vector2(0.2f, -1.3f);
    [SerializeField] private Vector2 projectileSpawnOffset2 = new Vector2(-0.2f, -1.3f);
    [SerializeField] private Vector2 projectileSpawnOffset3 = new Vector2(1f, -1f);
    [SerializeField] private Vector2 projectileSpawnOffset4 = new Vector2(-1f, -1f);
    //[SerializeField] private int scoreToIncrease = 10; //Score to be increased when this enemy is killed!
    [SerializeField] private Vector2 projectileSpeed = new Vector2(0f, -1f);
    [SerializeField] private bool moveToFro = true;
    public bool isBoss = false;
    //[SerializeField] private GameObject healthBar;

    //public int ScoreToIncrease { get { return scoreToIncrease; } }
    public enum EnemyType
    {
        Individual, Wave
    }

    public EnemyType enemyType;

    private float minHeight = 0f, maxHeight = 0f, minWidth = 0f, maxWidth = 0f;
    private Vector2 vel1, vel2;
    [SerializeField][Range(1f, 10f)] private float smoothTime = 1f;
    private Vector2 minW, maxW;
    private float maxSpeed = 10f;

    private Rigidbody2D _myBody;

    void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
    }

    private void Fire()
    {
        Vector2 targetPos = new Vector2(transform.position.x + projectileSpawnOffset.x, transform.position.y + projectileSpawnOffset.y);
        Vector2 targetPos1 = new Vector2(transform.position.x + projectileSpawnOffset1.x, transform.position.y + projectileSpawnOffset1.y);
        Vector2 targetPos2 = new Vector2(transform.position.x + projectileSpawnOffset2.x, transform.position.y + projectileSpawnOffset2.y);
        Vector2 targetPos3 = new Vector2(transform.position.x + projectileSpawnOffset3.x, transform.position.y + projectileSpawnOffset3.y);
        Vector2 targetPos4 = new Vector2(transform.position.x + projectileSpawnOffset4.x, transform.position.y + projectileSpawnOffset4.y);
        GameObject proj = Instantiate(projectileToSpawn, targetPos, projectileToSpawn.transform.rotation) as GameObject;
        if (proj.GetComponent<Rigidbody2D>())
            proj.GetComponent<Rigidbody2D>().AddForce(projectileSpeed, ForceMode2D.Impulse);
        GameObject proj1 = Instantiate(projectileToSpawn, targetPos1, projectileToSpawn.transform.rotation) as GameObject;

        if (proj1.GetComponent<Rigidbody2D>())
            proj1.GetComponent<Rigidbody2D>().AddForce(projectileSpeed, ForceMode2D.Impulse);
        GameObject proj2 = Instantiate(projectileToSpawn, targetPos2, projectileToSpawn.transform.rotation) as GameObject;

        //if (proj2.GetComponent<Rigidbody2D>())
        //    proj2.GetComponent<Rigidbody2D>().AddForce(projectileSpeed, ForceMode2D.Impulse);
        //GameObject proj3 = Instantiate(projectileToSpawn1, targetPos3, projectileToSpawn1.transform.rotation) as GameObject;

        //if (proj3.GetComponent<Rigidbody2D>())
        //    proj3.GetComponent<Rigidbody2D>().AddForce(projectileSpeed, ForceMode2D.Impulse);
        //GameObject proj4 = Instantiate(projectileToSpawn2, targetPos4, projectileToSpawn2.transform.rotation) as GameObject;

        if (proj2.GetComponent<Rigidbody2D>())
            proj2.GetComponent<Rigidbody2D>().AddForce(projectileSpeed, ForceMode2D.Impulse);

        
    }

    private bool closerToMin = false, closerToMax = false, exec = false;

    private void Update()
    {
 
        if (enemyType == EnemyType.Individual && moveToFro)
        {
            
            if (!exec)
            {
                transform.position = Vector2.SmoothDamp(transform.position, minW, ref vel1, smoothTime, maxSpeed, Time.deltaTime);
                if (transform.position.x - 0.1f <= minW.x)
                {
                    closerToMin = true;
                    closerToMax = false;
                    exec = true;
                }


            }
            else
            {
                if (transform.position.x - 0.1f <= minW.x)
                {
                    closerToMin = true;
                    closerToMax = false;
                }
                if (transform.position.x + 0.1f >= maxW.x)
                {
                    closerToMax = true;
                    closerToMin = false;
                }

                if (closerToMax)
                    transform.position = Vector2.SmoothDamp(transform.position, minW, ref vel1, smoothTime, maxSpeed, Time.deltaTime);
                else if (closerToMin)
                    transform.position = Vector2.SmoothDamp(transform.position, maxW, ref vel2, smoothTime, maxSpeed, Time.deltaTime);
            }

        }

    }

    //private void OnTriggerEnter2D(Collider2D target)
    //{
    //    if (target.tag == "Enemy" || target.tag == "Rock" || target.tag == "GreenBullet")
    //    {
    //        DamageHealthbarEnemy();
    //       Destroy(target.gameObject);

    //        if (health <= 0)
    //        {
    //            Destroy(gameObject);
    //        }

    //    }
    //}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "GreenBullet" )
        {
            DamageHealthbarEnemy();
            //DamagePlayerHealthbar();
            Destroy(target.gameObject);
            if (health <= 0)
            {
                Destroy(gameObject);
                Destroy(target.gameObject);
                _explosionBoss = (GameObject)Instantiate(_explosionBoss, target.transform.position, Quaternion.identity);
                Destroy(_explosionBoss, 1);
                GamePlayController.instance.playerScore += 10;
                AudioSource.PlayClipAtPoint(_explosionBossClip, target.transform.position);

            }


           
        }
    }



    void DamageHealthbarEnemy()
    {
        if(health > 0)
       {
            health -= 1;
            barSize = barSize - damage;
            healthbarBoss1.SetSize(barSize);
        }
    }

    //void DamagePlayerHealthbar()
    //{
    //    if (health > 0)
    //    {
    //        health -= 1;
    //        barFillAmount = barFillAmount - damage;
    //        healthbar.SetAmount(barFillAmount);
    //    }
    //}



    // Use this for initialization
    void Start()
    {
       
        //damage = barFillAmount / health;
        if (projectileToSpawn != null)
        {
            InvokeRepeating("Fire", 0.01f, fireRate);

        }

        if (enemyType == EnemyType.Individual)
        {
                
            minHeight = Screen.height * 0.6f;
            maxHeight = Screen.height * 0.8f;
            Vector2 minH = Camera.main.ScreenToWorldPoint(new Vector2(0f, minHeight));
            Vector2 maxH = Camera.main.ScreenToWorldPoint(new Vector2(0f, maxHeight));
            float height = Random.Range(minH.y, maxH.y);

            minWidth = Screen.width * 0.2f;
            maxWidth = Screen.width * 0.8f;
            minW = Camera.main.ScreenToWorldPoint(new Vector2(minWidth, 0f));
            maxW = Camera.main.ScreenToWorldPoint(new Vector2(maxWidth, 0f));
            minW.y = height;
            maxW.y = height;
            float width = Random.Range(minW.x, maxW.x);

            transform.position = new Vector2(width, height);
        
        }
        //damage = barSize / health;
        damage = barSize / health;

    }


    
}
