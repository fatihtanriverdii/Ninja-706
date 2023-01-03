using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public float zaman;
    public TextMeshProUGUI Tzaman;
    public GameObject panel2;

    private void Start()
    {
        zaman = 60;
        Tzaman.text = "" + (int)zaman;
    }

    private void Update()
    {
        zaman -= Time.deltaTime;
        Tzaman.text = "" + (int)zaman;
        if((int)zaman == 0) 
        {
            Time.timeScale = 0;
            panel2.SetActive(true);
            Destroy(GameObject.FindWithTag("Right"));
            Destroy(GameObject.FindWithTag("Left"));
        }
    }

    public void Restart_button2()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1;
        GameObject.Find("Canvas/Health_bar_back/Health_bar").GetComponent<Image>().fillAmount = 1;
        zaman = 60;
    }
}
