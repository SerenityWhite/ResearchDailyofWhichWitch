using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum ENEMYSTATE
    {
        RunL = 0,
        RunR,
        Attack,
        Damage,
        Death
    }
    public ENEMYSTATE enemyState;

    public float moveSpeed;
    public Animation mushAnim;
    public float offsetX;
    Vector3 enemyPos;
    public float startPosX;
    public float limitPosX;

    void Start ()
    {
        mushAnim = GetComponent<Animation>();
        enemyPos = GetComponent<Transform>().position;
        startPosX = enemyPos.x;
        limitPosX = startPosX - 12.3f;
    }
	
	void Update ()
    {
        switch (enemyState)
        {
            case ENEMYSTATE.RunL:
                mushAnim.Play("Run");
                transform.Translate(0, 0, moveSpeed);
                transform.rotation = Quaternion.Euler(new Vector3(0, -90f, 0));

                if (transform.position.x < limitPosX)
                {
                    transform.position = new Vector3(limitPosX, transform.position.y, transform.position.z);
                    enemyState = ENEMYSTATE.RunR;
                }

                break;
            case ENEMYSTATE.RunR:
                mushAnim.Play("Run");
                transform.Translate(0, 0, moveSpeed);
                transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));

                if (transform.position.x > limitPosX + 12.3f)
                {
                    transform.position = new Vector3(limitPosX + 12.3f, transform.position.y, transform.position.z);
                    enemyState = ENEMYSTATE.RunL;
                }
                break;
            case ENEMYSTATE.Attack:
                mushAnim.Play("Attack");
                break;
            case ENEMYSTATE.Damage:
                mushAnim.Play("Damage");
                break;
            case ENEMYSTATE.Death:
                mushAnim.Play("Death");
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyState = ENEMYSTATE.Attack;
        }
    }
}
