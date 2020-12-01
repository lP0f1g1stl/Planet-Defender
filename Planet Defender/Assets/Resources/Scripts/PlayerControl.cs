using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    public Joystick jsMovement;
    private Vector3 direction;
    public Rigidbody2D rb;

    public bool shooting = false;
    private float fireRate = 0.5f;
    private float nextFire = 0;
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject projectile; 


    void FixedUpdate()
    {
        direction = jsMovement.InputDirection;
        float angleJS = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        if (angleJS < 0.1) angleJS = 360 + angleJS;
        float angleShip = rb.transform.rotation.eulerAngles.z;
        float thrust = direction.sqrMagnitude;
        if (direction.magnitude != 0)
        {
            rb.AddRelativeForce(Vector3.up * thrust * speed, ForceMode2D.Force);
            if (angleShip < angleJS)
            {
                float angleBtw = angleJS - angleShip;
                if (angleBtw < 180)
                {
                    rb.AddTorque(turnSpeed);
                }
                if (angleBtw > 180)
                {
                    rb.AddTorque(-turnSpeed);
                }
            }
            if (angleShip > angleJS)
            {
                float angleBtw = angleShip - angleJS;
                if (angleBtw < 180)
                {
                    rb.AddTorque(-turnSpeed);
                }
                if (angleBtw > 180)
                {
                    rb.AddTorque(turnSpeed);

                }
            }
        }
        if (shooting == true && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject clone1 = Instantiate(projectile, firePoint1.position, firePoint1.rotation);
            GameObject clone2 = Instantiate(projectile, firePoint2.position, firePoint2.rotation);
        }
    }
    public void StartShooting()
    {
        shooting = true;
    }
    public void StopShooting()
    {
        shooting = false;
    }
    
}
