using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageTypes
{
    Melee = 8,
    Ranged = 9,
    Magic = 10
}

public class Unit : MonoBehaviour
{
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ball")
        {
            health--;
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
