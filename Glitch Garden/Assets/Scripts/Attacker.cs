using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;

    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySeconds;
    private GameObject currentTarget;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from animator at the time of actual blow 
    public void StrikeCurrentTarger(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
