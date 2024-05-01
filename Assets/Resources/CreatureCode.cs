using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class CreatureCode : MonoBehaviour
{
    private bool Idle = true;
    private bool timer = false;
    Vector3 target;
    Vector3 alt_target;
    private int mode;
    Animator animator;
    
    void End_Timer()
    {
        timer = false;
    }

    void DefineTarget()
    {
        mode = 0;
        float delay = Random.Range(0.5f, 1f);
        float x = Random.Range(-2f, 2f);
        float y = Random.Range(-2f, 2f);

        target = transform.position + new Vector3(x, y, 0f);
        alt_target = transform.position + new Vector3(-x, -y, 0f);
        timer = true;
        Invoke("End_Timer", delay);

    }

    void Move()
    {
        animator.SetFloat("multiplier", 2);
        if (mode == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 1.5f * Time.deltaTime);
            if (target.x < transform.position.x)
            {
                animator.SetBool("Right/Left", true);
            }
            else
            {
                animator.SetBool("Right/Left", false);
            }
        }
        else if (mode == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, alt_target, 1.5f * Time.deltaTime);
            if (alt_target.x < transform.position.x)
            {
                animator.SetBool("Right/Left", true);
            }
            else
            {
                animator.SetBool("Right/Left", false);
            }
        }

        

    }

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Idle == true && timer == false)
        {
            animator.SetFloat("multiplier", 0);
            if (transform.position == target || transform.position == alt_target)
            {
                DefineTarget();
            }
            else
            {
                Move();
            }
            
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mode = 1;
    }
}
