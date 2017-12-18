using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float playerMaxHealth;
    private float playerHealth;

    public HealthBar healthBar;

    // Use this for initialization
    void Start()
    {
        healthBar.setHealth(playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            healthBar.addHealth(-1);
        }
    }
}
