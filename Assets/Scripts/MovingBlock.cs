using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public float movingSpeed;
    public float movingDistance;
    public Vector3 blockPos;
    public float startX;
    public float limitX;

    public enum BLOCKSTATE
    {
        MoveR = 0,
        MoveL
    }
    public BLOCKSTATE blockMove;

	void Start ()
    {
        blockPos = GetComponent<Transform>().position;
        startX = blockPos.x;
        limitX = blockPos.x + movingDistance;
    }
	
	void Update ()
    {
        switch (blockMove)
        {
            case BLOCKSTATE.MoveR:
                transform.Translate(movingSpeed, 0, 0);
                if (transform.position.x > limitX)
                {
                    transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
                    blockMove = BLOCKSTATE.MoveL;
                }
                    break;
            case BLOCKSTATE.MoveL:
                transform.Translate(-movingSpeed, 0, 0);
                if (transform.position.x < startX)
                {
                    transform.position = new Vector3(startX, transform.position.y, transform.position.z);
                    blockMove = BLOCKSTATE.MoveR;
                }
                    break;
            default:
                break;
        }
    }
}
