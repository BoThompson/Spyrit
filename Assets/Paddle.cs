using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float position;
    public float speed;
    public Vector3 startPosition;
    public Vector3 alphaPosition;
    public Vector3 betaPosition;
    public Vector3 endPosition;
    const float ALPHA = 0.4f;
    const float BETA = 0.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0;
        if (Input.GetKey(KeyCode.A))
        {
            movement -= 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += 1;
        }

        position += movement * speed * Time.deltaTime;
        //If position 0 - alpha lerp rotation 0
        if (position <= ALPHA)
        {
            transform.position = Vector3.Lerp(startPosition, alphaPosition, position / ALPHA);
            transform.rotation = Quaternion.identity;
        }
        else if (position <= BETA)
        //If position alpha - beta lerp and rotate
        {
            transform.position = Vector3.Lerp(alphaPosition, betaPosition, (position - ALPHA) / (BETA - ALPHA));
            transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0, 0, 270), (position - ALPHA) / (BETA - ALPHA));
        }
        else
        {
            //If position beta - 1 lerp rotation 90
            transform.position = Vector3.Lerp(betaPosition, endPosition, position - BETA);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        
    }
}
