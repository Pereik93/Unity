using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
 
    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator anim;
    private Spawner myLaneSpawner;

    private void Start()
    {
        anim = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + " can't find spawner in lane");
    }


    bool IsAttackerAheadInLane()
    {
        //Exit if no attackers in lane
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }


        foreach(Transform attackers in myLaneSpawner.transform)
        {
            if(attackers.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }
	
}
