using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    public Transform player;
    float distance;
    bool active = false;
    public GameObject coursor;

    void Update()
    {
        distance = player.transform.position.sqrMagnitude;
        if (distance > 10)
        {
            DisplayCursore();
            Active();
        }
        else
        {
            Deactive();
        }
    }
    private void DisplayCursore()
    {
        Vector2 direction = -player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void Active()
    {
        if (active == false)
        {
            active = true;
            coursor.SetActive(true);
        }
    }
    private void Deactive()
    {
        if (active == true)
        {
            active = false;
            coursor.SetActive(false);
        }
    }
}
