using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSC : MonoBehaviour
{
    static CharacterSC _instance = null;
    public static CharacterSC Instance()
    {
        return _instance;
    }

    public float moveSpeed = 0.1f;
    public float ladderSpeed;
    public Animation playerAnim;
    public float jumpPower = 4f;
    public int jumpCount = 1;
    Rigidbody rigidBody;
    public bool ladderCol = false;
    public GameObject magicSkill;
    public Transform magicPos;
    public GameObject playerCamera;
    Vector3 cameraPos;
    public float oriTime;
    public float ShakeTime;
    public bool hitted = false;
    public float playerHP = 100f;
    public float playerMP = 100f;
    public float playerAttackDamage;
    public UIProgressBar hpBar;
    public UILabel hpTX;
    public UIProgressBar mpBar;
    public UILabel mpTX;
    public float mpFillCool;
    public float mpFillTime;
    public GameObject mpFillEF;
    public bool Up = false;
    public bool Down = false;
    public bool Left = false;
    public bool Right = false;

    void Start ()
    {
        playerAnim = GetComponent<Animation>();
        rigidBody = GetComponent<Rigidbody>();

        if (_instance == null)
            _instance = this;
	}

    void Update ()
    {
        cameraPos = playerCamera.GetComponent<Transform>().position;
        playerAnim.Play("idle");

        if(playerHP <= 0)
            playerHP = 0;

        if (playerMP <= 0)
            playerMP = 0;

        if(playerHP >= 100)
            playerHP = 100;

        if (playerMP >= 100)
           playerMP = 100;

        hpBar.value = playerHP * 0.01f;
        mpBar.value = playerMP * 0.01f;

        hpTX.text = "" + (int)playerHP;
        mpTX.text = "" + (int)playerMP;

        mpFillTime += Time.deltaTime;

        if (mpFillTime > mpFillCool)
        {
            if(playerMP < 100)
            {
                playerMP += 10;
                Instantiate(mpFillEF, transform.position, transform.rotation);
            }
            mpFillTime = 0;
        }

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
                SoundSC.Instance().Sound.clip = SoundSC.Instance().Jump;
                SoundSC.Instance().Sound.Play();
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
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                playerAnim.Play("attack");
                if(playerMP > 0)
                {
                    SoundSC.Instance().Sound.clip = SoundSC.Instance().Attack;
                    SoundSC.Instance().Sound.Play();
                    Instantiate(magicSkill, magicPos.position, magicPos.rotation);
                    playerMP -= 10;
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

        if(Up == true)
        {
            if (ladderCol == true)
            {
                transform.Translate(0, ladderSpeed, 0);
            }
        }

        if(Down == true)
        {
            if (ladderCol == true)
            {
                transform.Translate(0, -ladderSpeed, 0);
            }
        }

        if(Left == true)
        {
            playerAnim.Play("run");
            transform.rotation = Quaternion.Euler(new Vector3(0, -90f, 0));
            transform.Translate(0, 0, moveSpeed);
        }

        if(Right == true)
        {
            playerAnim.Play("run");
            transform.rotation = Quaternion.Euler(new Vector3(0, 90f, 0));
            transform.Translate(0, 0, moveSpeed);
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

        if(other.gameObject.tag == "Goal")
        {
            StageManager.Instance().goal = true;
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

        if (other.gameObject.tag == "Goal")
        {
            StageManager.Instance().goal = false;
        }
    }

    public void HpUp()
    {
        playerState.Instance().hpPotion -= 1;
        playerHP += 10;
    }

    public void MpUp()
    {
        playerState.Instance().mpPotion -= 1;
        playerMP += 30;
    }

    public void UpKey()
    {
        Up = true;
    }

    public void UpKeyRelease()
    {
        Up = false;
    }

    public void DownKey()
    {
        Down = true;
    }

    public void DownKeyRelease()
    {
        Down = false;
    }

    public void LeftKey()
    {
        Left = true;
    }

    public void LeftKeyRelease()
    {
        Left = false;
    }

    public void RightKey()
    {
        Right = true;
    }

    public void RightKeyRelease()
    {
        Right = false;
    }

    public void JumpKey()
    {
        if (jumpCount > 0)
        {
            SoundSC.Instance().Sound.clip = SoundSC.Instance().Jump;
            SoundSC.Instance().Sound.Play();
            rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpCount = 0;
        }
    }

    public void AttackKey()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        if (ladderCol == false)
        {
            playerAnim.Play("attack");
            if (playerMP > 0)
            {
                SoundSC.Instance().Sound.clip = SoundSC.Instance().Attack;
                SoundSC.Instance().Sound.Play();
                Instantiate(magicSkill, magicPos.position, magicPos.rotation);
                playerMP -= 10;
            }
        }
    }
}