using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroids;
    public int numOfAsteroidsInWave;
    public int numOfAsteroids;
    private int score;
    public Text scoreDisplay;

    private int radius = 25;

    void Start()
    {
        CreateWave();
    }

    private void SpawnAsteroid()
    {
        int asteroidID = Random.Range(0, 3);
        int degrees = Random.Range(0, 360);
        float angle = Mathf.PI * degrees / 180;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        float speedX = -x / radius / 1.5f + Random.Range(-0.2f, 0.2f);
        float speedY = -y / radius / 1.5f + Random.Range(-0.2f, 0.2f);
        GameObject asteroid = Instantiate(asteroids[asteroidID], new Vector3(x, y, 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3(speedX, speedY, 0);
        asteroid.GetComponent<Asteroid>().AsteroidInfo(asteroidID, speedX, speedY);
        PlusAsteroid();
    }

    public void PlusAsteroid()
    {
        numOfAsteroids++;
    }

    public void MinusAsteroid()
    {
        numOfAsteroids--;
        if (numOfAsteroids <= 0)
        {
            CreateWave();
            numOfAsteroidsInWave += Random.Range(1, 3);
        }
    }
    IEnumerator Coroutine()
    {
        for (int i = 0; i < numOfAsteroidsInWave; i++)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(1);
        }
    }
    private void CreateWave()
    {
        StartCoroutine(Coroutine());
    }

    public void DispalyScore(int id)
    {
        score += id;
        scoreDisplay.text = score.ToString();
    }
}
