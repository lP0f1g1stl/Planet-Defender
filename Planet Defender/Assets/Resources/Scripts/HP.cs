using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public int hpMax;
    public int hpCur;
    public Transform HPGameObject;
    public Text hpDisplay;
    public int objectID;
    public GameObject gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            int damage = collision.gameObject.GetComponent<Asteroid>().hp;
            if (hpCur >= damage) hpCur -= damage;
            else hpCur = 0;
            collision.gameObject.GetComponent<Asteroid>().HPHandler(hpCur);
            HealthHandler();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            int damage = collision.gameObject.GetComponent<Asteroid>().hp;
            if (hpCur >= damage) hpCur -= damage;
            else hpCur = 0;
            collision.gameObject.GetComponent<Asteroid>().HPHandler(hpCur);
            HealthHandler();
        }
    }
    private void HealthHandler()
    {
        float health = hpCur;
        int percentOfHealth = hpCur * 100 / hpMax;
        DisplayHealth(percentOfHealth, health);
        if (hpCur <= 0)
        {
            if (objectID == 0)
            {
                gameManager.GetComponent<PauseMenu>().Pause(true);
                gameObject.SetActive(false);
            }
            if (objectID == 1)
            {
                gameObject.transform.position = new Vector3(0, 0, 0);
                hpCur = hpMax;
                HealthHandler();
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
    private void DisplayHealth(int percentOfHealth, float health)
    {
        hpDisplay.text = percentOfHealth.ToString();
        HPGameObject.transform.localScale = new Vector3(health / hpMax * 1, 1, 1);
    }
}
