﻿using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

    public float damage = 100f;

    public float GetDamage()
    {
        return damage;
    }

   public void Hit()
    {
        Destroy(gameObject);
    }

}
