using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class Shooting : MonoBehaviour
{
    public Transform[] muzzles;
    public Bullet bullet;
    public LayerMask groundMask;
    private Vector3 shootingDirection;
    private Vector3 shootingDirectionMuzzle1;
    private Vector3 shootingDirectionMuzzle2;
    public static float shootingRate = 0.15f;
    private float shootingTimer = -1f;
    public Camera mainCam;
    public ParticleSystem[] muzzleFlashes;

    void Start()
    {

    }
    void Update()
    {
        if (GameManager.instance.gameOver == false && GameManager.instance.gamePaused == false)
        {
            Aim();
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Shoot();
            }
        }

    }

    void Shoot()
    {
        if (Time.time > shootingTimer)
        {
            shootingTimer = Time.time + shootingRate;

            Bullet bulletIstantiated1 = Instantiate(bullet, muzzles[0].transform.position, Quaternion.Euler(0, 0, 90));
            muzzleFlashes[0].Play();
            bulletIstantiated1.bulletRb.AddForce(shootingDirectionMuzzle1 * bullet.shootingSpeed, ForceMode.Impulse);
            Bullet bulletIstantiated2 = Instantiate(bullet, muzzles[1].transform.position, Quaternion.Euler(0, 0, 90));
            muzzleFlashes[1].Play();
            bulletIstantiated2.bulletRb.AddForce(shootingDirectionMuzzle2 * bullet.shootingSpeed, ForceMode.Impulse);
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
            shootingDirection.y = -0.7f;
            transform.forward = shootingDirection;
            shootingDirectionMuzzle1 = position - muzzles[0].transform.position;
            shootingDirectionMuzzle2 = position - muzzles[1].transform.position;
            shootingDirectionMuzzle1.y = -0.7f;
            shootingDirectionMuzzle2.y = -0.7f;
        }
    }
}
