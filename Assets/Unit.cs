using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int health = 3;

    Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponentInChildren<Text>();
        healthText.text = health.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ball")
        {
            health--;
            healthText.text = health.ToString();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
