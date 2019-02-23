using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float speed;
    private Animator animator;
    //private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero;
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        if(horizontal > 0)
        {
            moveDirection.x = 1;
            animator.SetTrigger("walkAnimation");
            //animator.SetInteger("Direction", 2);
        }
        if (horizontal < 0)
        {
            moveDirection.x = -1;
            animator.SetTrigger("walkAnimation");
            //animator.SetInteger("Direction", 0);
        }
        if (vertical > 0)
        {
            moveDirection.y = 1;
            animator.SetTrigger("walkAnimation");
            //animator.SetInteger("Direction", 1);
        }
        if (vertical < 0)
        {
            moveDirection.y = -1;
            animator.SetTrigger("walkAnimation");
            //animator.SetInteger("Direction", 3);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(horizontal != 0 || vertical != 0)
            {
                horizontal = 0;
                vertical = 0;
                animator.SetBool("wasWalking", true);
            }
            animator.SetTrigger("attackAnimation");
            
        }
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        
    }
}
