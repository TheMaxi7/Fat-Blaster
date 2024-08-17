using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    public Transform gunHolder;
    public Bullet bullet;
    private Camera mainCam;
    public LayerMask groundMask;
    private Vector3 shootingDirection;

    public float shootingRate = 0.15f;
    private float shootingTimer = -1f;

    void Start()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        Aim();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time > shootingTimer)
        {
            shootingTimer = Time.time + shootingRate;
            Bullet bulletIstantiated = Instantiate(bullet, gunHolder.transform.position, Quaternion.identity);
            bulletIstantiated.bulletRb.AddForce(shootingDirection * bullet.shootingSpeed, ForceMode.Impulse);
        }

    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            shootingDirection = position - transform.position;
            shootingDirection.y = 0.5f;
            transform.forward = shootingDirection;
        }
    }
}
