using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

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
        Timer();
    }

   public bool IsSimulationEnd()
   {
        if (points >= 8800)
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

}
