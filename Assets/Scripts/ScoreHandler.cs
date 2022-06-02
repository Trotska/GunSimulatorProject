using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gameManager;

    public Text PointsGained;
    public Text PointsLost;
    public Text Accuracy;
    public Text TotalScore;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PointsGained.text = gameManager.points.ToString();
        PointsLost.text = gameManager.pointslost.ToString();
    }
}
