using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxX, maxZ, minX, minZ;
    private Rigidbody characterRb;
    void Start()
    {
        characterRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterRb.MovePosition(transform.position + move * Time.deltaTime * PlayerManager.instance.speedMovement);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, Mathf.Clamp(transform.position.z, minZ, maxZ));
    }
}
