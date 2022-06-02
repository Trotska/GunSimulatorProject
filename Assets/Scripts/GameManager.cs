using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int points;
    public int pointslost;


    public float timeRemaining = 300;
    public bool timerIsRunning = false;
    //MaleTarget:54
    //FemaleTargets:34
    //Total:88

    //Text variables
    public Text PointsGained;
    public Text PointsLost;
    public Text Accuracy;
    public Text TotalScore;
    public Text TimeRemaining;

    //Menu Variables
    public Canvas SimulationCanvas;
    public bool ResetData = true;


    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Start the timer
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        PointsGained.text = points.ToString();
        PointsLost.text = pointslost.ToString();
        TimeRemaining.text = timeRemaining.ToString();
        if (points > 100)
        {
            Timer();
        }
        //Timer();

        if (IsSimulationEnd())
        {

        }

    }

   public bool IsSimulationEnd()
   {
        if (points >= 8800 || timeRemaining <= 0)
        {
            return true;
        }
        else
            return false;
   }

   public void Timer()
   {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
        }

   }

    void ResetScene()
    {
        timeRemaining = 300;
        points = 0;
    }


    void EndScene()
    {
        Debug.Log("Scene has been loaded");
        SceneManager.LoadScene("End Scene");
    }
}
