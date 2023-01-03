using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    public GameObject blockRight;
    public GameObject blockLeft;
    public GameObject panel;

    private void Start()
    {
        InvokeRepeating("createBlock", 0, 2);
    }
    private void Update()
    {
        if(GameObject.Find("Canvas/Health_bar_back/Health_bar").GetComponent<Image>().fillAmount == 0) 
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            Destroy(GameObject.FindWithTag("Right"));
            Destroy(GameObject.FindWithTag("Left"));
        }
    }
    void createBlock() 
    {
        int x = Random.Range(1, 3);
        if (x == 1) 
        {
            GameObject blockGameObject = Instantiate(blockRight, new Vector3(6, 0.623f, -4.43f), Quaternion.identity);
        }
        else 
        {
            GameObject blockGameObject = Instantiate(blockLeft, new Vector3(-6, 0.623f, -4.43f), Quaternion.identity);
        }
    }

    public void Restart_button() 
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1;
        GameObject.Find("Canvas/Health_bar_back/Health_bar").GetComponent<Image>().fillAmount = 1;
    }
}
