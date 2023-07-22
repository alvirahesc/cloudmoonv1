using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 10/3/2023 note
    fix the grab why the hell is it pushing caherine to the left
   12/6/2023 
    Fixing it, used layermask to ignore (dont work), attempting to disable collider using script attached to it.

 
 */



public class test_move : MonoBehaviour
{
    //player physics
    private Rigidbody2D rb;
    float horizontal;
    float speed = 8f;
    float jumpForce = 3f;


    //object interaction
    private GameObject grabbedObject;
    [SerializeField] float grabRadius = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking walk input
          horizontal = Input.GetAxisRaw("Horizontal");
        //heres the jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //object interaction player control
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (grabbedObject != null)
            {
                //releasing the object
                grabbedObject = null;
            }
            else
            {
                //grabbing the object
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, grabRadius);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Grabbables"))
                    {
                        grabbedObject = collider.gameObject;
                        break;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        //walking physics
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        GrabObjects();
    }

    public void GrabObjects()
    {
        //grab ctrl continued
        if (grabbedObject != null)
        {
            //move the object along with the player
            Rigidbody2D grabbedRb = grabbedObject.GetComponent<Rigidbody2D>();
            grabbedRb.MovePosition(transform.position);

            //rotate object to follow player rotation
            grabbedObject.transform.rotation = transform.rotation;
        }

    }

    //im not using this yet
    /* private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "collectible")
         {
             //Debug.Log("Triggered by collectible");
             Destroy(collision.gameObject);
         }
     }
 */
}
