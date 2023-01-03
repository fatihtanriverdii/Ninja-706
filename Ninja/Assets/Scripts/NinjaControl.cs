using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NinjaControl : MonoBehaviour
{
    Animator animator;
    RaycastHit nesne;
    public bool isTrue;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float xposition;
        xposition = Mathf.Clamp(transform.position.x, -5.4f, 5.4f);
        transform.position = new Vector3(xposition, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            transform.Translate(-4 * Time.deltaTime, 0, 0, Space.World);
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Jump", false);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) 
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(4 * Time.deltaTime, 0, 0, Space.World);
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Jump", false);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isTrue)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * 260);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane") 
        {
            isTrue = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            isTrue = false;
        }
    }
}