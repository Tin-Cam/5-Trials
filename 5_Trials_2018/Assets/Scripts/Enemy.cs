using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float maxHealth;
    private float health;

    //Reduces the enemy's health
	public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killEnemy();
        }
    }

    //Controls removing the enemy from the scene
    private void killEnemy()
    {
        Destroy(this.gameObject);
    }
}
