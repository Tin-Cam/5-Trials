using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private PlayerMove playerMove;

    public bool canAttack = true;
    public float attackSpeed;
    public float attackRefresh;
    public float attackHoldTime;
    public float attackDistance;
    public GameObject sword;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        sword.SetActive(false);
    }

    void Update()
    {
        Vector3 point = transform.position;
        Vector3 axis = new Vector3(0, 0, 1);


        sword.transform.RotateAround(point, axis, attackSpeed);

        if (!canAttack)
            return;

        Attack();

    }

    //Stops the player from moving, then starts the Attack Coroutine
    private void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            canAttack = false;
            playerMove.canMove = false;
            StartCoroutine("AttackCo");
        }
    }

    private IEnumerator AttackCo()
    {
        sword.transform.position = new Vector2(transform.position.x, 1.5f);
        sword.SetActive(true);

        canAttack = true;
        playerMove.canMove = true;
        yield return new WaitForSeconds(1);
    }
}
