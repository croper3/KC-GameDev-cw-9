using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public Transform groundposs;
    public float speed;
    public LayerMask ground;
    public float rad;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemypatrol();
    }

   

    void enemypatrol()
    {
        rb.velocity = new Vector2(speed, 0f);

        bool isgrounded = Physics2D.OverlapCircle(groundposs.position , rad , ground);

        if(!isgrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bulet")
        {
            Destroy(gameObject);
        }
    }
}
