using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points = 0;
    public int pointslost = 0;

    //Text variables
    public Text PointsGained;
    public Text PointsLost;
    public Text Accuracy;
    public Text TotalScore;

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
}
