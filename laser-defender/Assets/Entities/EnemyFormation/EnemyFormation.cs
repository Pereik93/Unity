using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour
{
    public GameObject projectile;
    public GameObject explosion;
    public float projectileSpeed = 10;
    public float health = 150;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 150;
    public AudioClip fireSound;
    public AudioClip deathSound;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
       scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject missile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        ProjectileScript missile = collider.gameObject.GetComponent<ProjectileScript>();

        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        PuffSmoke();
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }


}
