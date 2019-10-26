using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(Vector3.Reflect(direction, collision.contacts[0].normal));
        transform.Translate(-direction * speed * Time.deltaTime);
        Vector3 v = Vector3.Reflect(direction, collision.contacts[0].normal);
        direction.x = v.x;
        direction.y = v.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
