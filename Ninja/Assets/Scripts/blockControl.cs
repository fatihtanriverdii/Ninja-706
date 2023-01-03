using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockControl : MonoBehaviour
{
    private void Update()
    {
        if(gameObject.tag == "Left") 
        {
            transform.Translate(2.5f * Time.deltaTime, 0, 0, Space.World);
            if(transform.position.x >= 6) 
            {
                Destroy(gameObject);
            }
        }
        else 
        {
            transform.Translate(-2.5f * Time.deltaTime, 0, 0, Space.World);
            if (transform.position.x <= -6)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
            GameObject.Find("Canvas/Health_bar_back/Health_bar").GetComponent<Image>().fillAmount -= 0.34f;
        }
    }
}
