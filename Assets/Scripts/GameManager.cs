using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;
    public int pointslost;
    
    //MaleTarget:54
    //FemaleTargets:34
    //Total:88

    //Text variables
    public Text PointsGained;
    public Text PointsLost;
    public Text Accuracy;
    public Text TotalScore;

    //Menu Variables
    public Canvas SimulationCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PointsGained.text = points.ToString();
        PointsLost.text = pointslost.ToString();
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
}
