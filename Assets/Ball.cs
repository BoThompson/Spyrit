using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector2 direction;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = speed * direction;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetMode(int layer)
    {
        gameObject.layer = layer;
        switch((DamageTypes)layer)
        {
            case DamageTypes.Magic: spriteRenderer.color = Color.blue; break;
            case DamageTypes.Ranged: spriteRenderer.color = Color.yellow; break;
            case DamageTypes.Melee: spriteRenderer.color = Color.red; break;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
