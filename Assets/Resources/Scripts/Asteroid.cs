using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private int asteroidID;
    private int score;
    private float speedX;
    private float speedY;
    private GameObject spawner;
    private bool damagble = true;
    private float lifetime = 75;

    public int hp;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("GameManager");
        StartCoroutine(Timer());
    }

    public void AsteroidInfo(int ID, float SX, float SY)
    {
        asteroidID = ID;
        score = ID + 1;
        if (asteroidID == 2) hp = Random.Range(10, 21);
        if (asteroidID == 1) hp = Random.Range(5, 11);
        if (asteroidID == 0) hp = Random.Range(1, 6);
        speedX = SX;
        speedY = SY;
    }

    public void HPHandler(int damage)
    {
        if (hp >= damage) hp -= damage;
        else hp = 0;
        if (hp <= damage && damagble == true)
        {
            damagble = false;
            SplitAsteroid(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            spawner.GetComponent<AsteroidSpawner>().DispalyScore(score);
            spawner.GetComponent<AsteroidSpawner>().MinusAsteroid();
            Destroy(gameObject);
        }
    }
    private void SplitAsteroid(float x, float y, float z)
    {
        if (asteroidID > 0)
        {
            asteroidID -= 1;
            for (int i = 0; i < score; i++)
            {
                float x1 = Random.Range(-0.5f, 0.5f);
                float y1 = Random.Range(-0.5f, 0.5f);
                GameObject asteroid = Instantiate(spawner.GetComponent<AsteroidSpawner>().asteroids[asteroidID], new Vector3(x + x1, y + y1, 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                speedX += Random.Range(-0.2f, 0.2f);
                speedY += Random.Range(-0.2f, 0.2f);
                asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3(speedX, speedY, 0);
                asteroid.GetComponent<Asteroid>().AsteroidInfo(asteroidID, speedX, speedY);
                spawner.GetComponent<AsteroidSpawner>().PlusAsteroid();
            }
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(lifetime);
        spawner.GetComponent<AsteroidSpawner>().MinusAsteroid();
        Destroy(gameObject);
    }
}
