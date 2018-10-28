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
    public float moveDistance;
    public Transform targetPos;
    public GameObject magicHitEF;
    public float enemyTime;
    public float hittedTime;
    public int enemyDamage;
    public float enemyHp;

    void Start ()
    {
        mushAnim = GetComponent<Animation>();
        enemyPos = GetComponent<Transform>().position;
        startPosX = enemyPos.x;
        limitPosX = startPosX - moveDistance;
    }
	
	void Update ()
    {
        if (enemyHp <= 0)
        {
            enemyHp = 0;
            enemyState = ENEMYSTATE.Death;
        }

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

                if (transform.position.x > limitPosX + moveDistance)
                {
                    transform.position = new Vector3(limitPosX + moveDistance, transform.position.y, transform.position.z);
                    enemyState = ENEMYSTATE.RunL;
                }

                break;
            case ENEMYSTATE.Attack:
                mushAnim.Play("Attack");
                break;
            case ENEMYSTATE.Damage:
                mushAnim.Play("Damage");
                enemyTime += Time.deltaTime;
                if(enemyTime > hittedTime)
                {
                    enemyTime = 0;
                    if (targetPos.position.x > transform.position.x)
                    {
                        enemyState = ENEMYSTATE.RunR;
                    }

                    if (targetPos.position.x < transform.position.x)
                    {
                        enemyState = ENEMYSTATE.RunL;
                    }
                }
                break;
            case ENEMYSTATE.Death:
                StartCoroutine(DeathDelay());
                break;
            default:
                break;
        }
    }

    IEnumerator DeathDelay()
    {
        mushAnim.Play("Death");
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        StageManager.Instance().deadEnemy++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            EnemySound.Instance().enemySound.clip = EnemySound.Instance().EnemyAttack;
            EnemySound.Instance().enemySound.Play();
            CharacterSC.Instance().playerHP -= enemyDamage;
            enemyState = ENEMYSTATE.Attack;
        }

        if(other.gameObject.tag == "Magic")
        {
            Instantiate(magicHitEF, transform.position, transform.rotation);
            enemyHp -= CharacterSC.Instance().playerAttackDamage;
            enemyState = ENEMYSTATE.Damage;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (targetPos.position.x > transform.position.x)
            {
                enemyState = ENEMYSTATE.RunR;
            }

            if (targetPos.position.x < transform.position.x)
            {
                enemyState = ENEMYSTATE.RunL;
            }
        }
    }
}
