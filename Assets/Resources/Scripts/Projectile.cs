using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    public float lifeTime;
    public Rigidbody2D rb;

    public void Start()
    {
        Destroy(gameObject, lifeTime);
        rb.velocity = transform.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<Asteroid>().HPHandler(damage);
            Destroy(gameObject);
        }
    }
}
