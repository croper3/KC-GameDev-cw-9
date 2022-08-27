using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool faceRight = true;

    public GameObject bulet;
    GameObject bulletclone;

    public Transform leftspawn;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        Fire();
    }

    void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.D) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }
    void Fire()
    {
        if(Input.GetMouseButtonDown(0) && faceRight)
        {
            bulletclone = Instantiate(bulet, transform.position, transform.rotation);
            bulletclone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(bulletclone, 1.5f);
        }
        else if (Input.GetMouseButtonDown(0) && !faceRight)
        {
            bulletclone = Instantiate(bulet, leftspawn.position, leftspawn.rotation);
            bulletclone.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
            Destroy(bulletclone, 1.5f);
        }
        
    }
}
