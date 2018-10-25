using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlockTB : MonoBehaviour
{
    public float movingSpeed;
    public float movingDistance;
    public Vector3 blockPos;
    public float startY;
    public float limitY;

    public enum BLOCKSTATE
    {
        MoveT = 0,
        MoveB
    }
    public BLOCKSTATE blockMove;

    void Start()
    {
        blockPos = GetComponent<Transform>().position;
        startY = blockPos.y;
        limitY = blockPos.y + movingDistance;
    }

    void Update()
    {
        switch (blockMove)
        {
            case BLOCKSTATE.MoveT:
                transform.Translate(0, movingSpeed, 0);
                if (transform.position.y > limitY)
                {
                    transform.position = new Vector3(transform.position.x, limitY, transform.position.z);
                    blockMove = BLOCKSTATE.MoveB;
                }
                break;
            case BLOCKSTATE.MoveB:
                transform.Translate(0, -movingSpeed, 0);
                if (transform.position.y < startY)
                {
                    transform.position = new Vector3(transform.position.x, startY, transform.position.z);
                    blockMove = BLOCKSTATE.MoveT;
                }
                break;
            default:
                break;
        }
    }
}
