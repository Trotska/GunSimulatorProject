using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnderCheck : MonoBehaviour
{
    public GameManager gameManager;
    public bool SceneLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsSimulationEnd() && SceneLoaded != true)
        {
            EndScene();
            SceneLoaded = true;
        }
    }

    void EndScene()
    {
        Debug.Log("Scene has been loaded");
        SceneManager.LoadScene("End Scene");
    }


}
