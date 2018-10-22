using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSC : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float ladderSpeed;
    public Animation playerAnim;
    public float jumpPower = 4f;
    public int jumpCount = 1;
    Rigidbody rigidBody;
    public bool ladderCol = false;
    public GameObject magicSkill;
    public Transform magicPos;
    public float attackCool;
    public float attackTime;
    public GameObject playerCamera;
    Vector3 cameraPos;
    public float oriTime;
    public float ShakeTime;
    public bool hitted = false;

    void Start ()
    {
        playerAnim = GetComponent<Animation>();
        rigidBody = GetComponent<Rigidbody>();
	}

    void Update ()
    {
        cameraPos = playerCamera.GetComponent<Transform>().position;
        playerAnim.Play("idle");

        if (transform.position.x < -6f)
            transform.position = new Vector3(-6f, transform.position.y, transform.position.z);

        if (transform.position.x > 84f)
            transform.position = new Vector3(84f, transform.position.y, transform.position.z);

        if (transform.position.y < -3.4f)
            transform.position = new Vector3(transform.position.x, -3.4f, transform.position.z);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.Play("run");
            transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
            transform.Translate(0, 0, moveSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.Play("run");
            transform.rotation = Quaternion.Euler(new Vector3(0, -90f, 0));
            transform.Translate(0, 0, moveSpeed);
        }

        if (jumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                jumpCount = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        }

        if(ladderCol == false)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                playerAnim.Play("attack");
                attackTime += Time.deltaTime;
                if (attackTime > attackCool)
                {
                    Instantiate(magicSkill, magicPos.position, magicPos.rotation);
                    attackTime = 0;
                }
            }
        }

        if(ladderCol == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.2f);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            rigidBody.useGravity = false;
            rigidBody.velocity = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, ladderSpeed, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, -ladderSpeed, 0);
            }
        }

        if(hitted == true)
        {
            oriTime += Time.deltaTime;
            playerCamera.transform.position = new Vector3(Random.Range(cameraPos.x - 0.3f, cameraPos.x + 0.3f), cameraPos.y, cameraPos.z);
            if (oriTime > ShakeTime)
            {
                oriTime = 0;
                playerCamera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                hitted = false;
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jumpCount = 1;
        }

        if(col.gameObject.tag == "MovingBlock")
        {
            jumpCount = 1;
            gameObject.transform.parent = col.gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "MovingBlock")
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            ladderCol = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            hitted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            ladderCol = false;
            rigidBody.useGravity = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        }
    }
}