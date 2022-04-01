using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Debut : MonoBehaviour
{


    public GameObject main, credits;

    // Start is called before the first frame update
    void Start()
    {

        main.SetActive(true);
        credits.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void jouer()
    {

        Debug.Log("apppt Let's play");

        SceneManager.LoadScene("demoScene_free");
    }

    public void creditClick()
    {
        main.SetActive(false);
        credits.SetActive(true);
        Debug.Log("apppt credit clique");
    }

    public void menuPrincipal()
    {
        main.SetActive(true);
        credits.SetActive(false);
        Debug.Log("apppt menu principal clique");
    }

    public void quitter()
    {
        Debug.Log("apppt bye bye");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
