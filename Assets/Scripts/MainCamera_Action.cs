using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Action : MonoBehaviour
{
    public GameObject player;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    public float followSpeed;

    Vector3 cameraPosition;

    void LateUpdate()
    {
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);
    }

    void Start ()
    {
		
	}

	void Update ()
    {
		
	}
}
