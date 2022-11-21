using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 lookDir;
    public Animator animator;
    [SerializeField]
    private GameObject target;
    void Start()
    {
        animator.GetComponent<Animator>();
    }
    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0f, z) * Time.deltaTime * 3f;

        InputPlayerRotation(x, z);
        transform.position += dir;

        if(x == 0 && z == 0)
        {
            Animation("Idle");
        }
        else
        {
            Animation("Move");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animation("Attack");
        }

        float disValue = Vector3.Distance(transform.position, target.transform.position);
        if(disValue < 2)
        {
            Animation("Hit");
        }
    }

    void InputPlayerRotation(float x, float z)
    {
        lookDir = x * Vector3.right + z * Vector3.forward;
        if(lookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDir);
        }
    }

    void Animation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }
}
