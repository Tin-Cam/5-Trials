using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private PlayerMove playerMove;

    public bool canAttack;

    public float speed;
    public float refreshRate;
    public float holdTime;
    public float radius;
    public float arcLength;

    public GameObject sword;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        sword.SetActive(false);
    }

    void FixedUpdate()
    {
        //Vector3 point = transform.position;
        //Vector3 axis = new Vector3(0, 0, 1);


        //sword.transform.RotateAround(point, axis, attackSpeed);
        //sword.transform.Rotate(Vector3.back * Time.deltaTime * attackSpeed);

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
        sword.transform.position = new Vector2(transform.position.x, transform.position.y + 1.5f);
        sword.transform.Rotate(Vector3.right);
        sword.SetActive(true);

        sword.transform.position = calculateStartPosition();

        //for(int i = 0; i <= arcLength; i++)
        //{
        //    sword.transform.position = calculateSwordPosition(i);
        //    yield return new WaitForEndOfFrame();
        //}
        
        yield return new WaitForSeconds(holdTime);
        sword.SetActive(false);
        canAttack = true;
        playerMove.canMove = true;
    }

    //Calculates where the sword appears
    private Vector3 calculateStartPosition()
    {
        //Sets the rotation of the sword using the player's direction
        sword.transform.rotation = Quaternion.Euler(0, 0, -90 * playerMove.direction);


        switch (playerMove.direction)
        {
            //Attacking up
            case 0:
                return new Vector3(transform.position.x, transform.position.y + radius, 0f);

            //Attacking right
            case 1:
                return new Vector3(transform.position.x + radius, transform.position.y, 0f);

            //Attacking down
            case 2:
                return new Vector3(transform.position.x, transform.position.y - radius, 0f);

            //Attacking left
            case 3:
                return new Vector3(transform.position.x - radius, transform.position.y, 0f);

            default:
                return new Vector3(transform.position.x, transform.position.y, 0f);
        }
    }

    //Moves the sword in an arc
    private Vector3 calculateSwordPosition(float angle)
    {
        //Calculate the sword's rotation
        sword.transform.rotation = Quaternion.Euler(0, 0, angle + (-90 * playerMove.direction));

        Vector3 result;

        result = new Vector3(
            (transform.position.x + radius) * Mathf.Cos(angle),    //x
            (transform.position.y + radius) * Mathf.Sin(angle),    //y
            0f);                                                         //z

        return result;
    }
}
