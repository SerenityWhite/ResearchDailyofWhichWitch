using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapApple : MonoBehaviour
{
    public Vector3 StartPos;
    public float moveDistance;
    public float moveSpeed;

	void Start ()
    {
        StartPos = transform.position;
	}
	
	void Update ()
    {
        transform.Translate(0, -moveSpeed, 0);

        if(transform.position.y < StartPos.y - moveDistance)
            transform.position = new Vector3(transform.position.x, StartPos.y, transform.position.z);
	}

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            CharacterSC.Instance().playerHP -= 2;
        }
    }
}
