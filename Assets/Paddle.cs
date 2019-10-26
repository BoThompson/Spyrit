using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PaddleTypes
{
    Ranged = 11,
    Magic = 12,
    Melee = 13
}
public class Paddle : MonoBehaviour
{
    public float position;
    public float speed;
    public float angularSpeed;
    public Vector3 startPosition;
    public Vector3 alphaPosition;
    public Vector3 betaPosition;
    public Vector3 endPosition;
    const float ALPHA = 0.4f;
    const float BETA = 0.6f;
    public float rotationOffset;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Ball"))
        {
            Ball ball = collision.transform.GetComponent<Ball>();
            int layer;
            switch ((PaddleTypes)gameObject.layer)
            {
                case PaddleTypes.Magic:
                    layer = (int)DamageTypes.Magic;
                    break;
                case PaddleTypes.Ranged:
                    layer = (int)DamageTypes.Ranged;
                    break;
                case PaddleTypes.Melee:
                    layer = (int)DamageTypes.Melee;
                    break;
                default: layer = 0; break;
            }
            
            ball.SetMode(layer);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float movement = 0;
        float rotation = 0;
        if (Input.GetKey(KeyCode.A))
        {
            movement -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += 1;
        }

        if(Input.GetKey(KeyCode.J))
        {
            rotation -= 1;
        }
        if(Input.GetKey(KeyCode.L))
        {
            rotation += 1;
        }

        //Ranged
        if(Input.GetKeyDown(KeyCode.W))
        {
            gameObject.layer = (int)PaddleTypes.Ranged;
            spriteRenderer.color = Color.yellow;
        }
        //Magic
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.layer = (int)PaddleTypes.Magic;
            spriteRenderer.color = Color.blue;
        }
        //Melee
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.layer = (int)PaddleTypes.Melee;
            spriteRenderer.color = Color.red;
        }
        position = Mathf.Clamp(position + movement * speed * Time.deltaTime, 0, 1);
        rotationOffset = Mathf.Clamp(rotationOffset + rotation * angularSpeed * Time.deltaTime, -30, 30);
        //If position 0 - alpha lerp rotation 0
        if (position <= ALPHA)
        {
            transform.position = Vector3.Lerp(startPosition, alphaPosition, position / ALPHA);
            transform.rotation = Quaternion.Euler(0, 0, rotationOffset);
        }
        else if (position <= BETA)
        //If position alpha - beta lerp and rotate
        {
            transform.position = Vector3.Lerp(alphaPosition, betaPosition, (position - ALPHA) / (BETA - ALPHA));
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, rotationOffset), Quaternion.Euler(0, 0, 270 + rotationOffset), (position - ALPHA) / (BETA - ALPHA));
        }
        else
        {
            //If position beta - 1 lerp rotation 90
            transform.position = Vector3.Lerp(betaPosition, endPosition, (position - BETA) / (1 - BETA));
            transform.rotation = Quaternion.Euler(0, 0, 270 + rotationOffset);
        }
        
    }
}
