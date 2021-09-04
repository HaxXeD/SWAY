using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float speed = 10f;
    float cameraPass;
    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        float halfWidth = transform.localScale.x / 2;
        cameraPass = Camera.main.aspect * Camera.main.orthographicSize + halfWidth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if(transform.position.x<-cameraPass)
        {
            transform.position = new Vector2(cameraPass, transform.position.y);
        }

        if (transform.position.x > cameraPass)
        {
            transform.position = new Vector2(-cameraPass, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spawn Object")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
