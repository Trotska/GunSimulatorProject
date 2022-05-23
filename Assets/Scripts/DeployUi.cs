using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeployUi : MonoBehaviour
{
    public Canvas SimulationResults;
    GameManager gameManager;
    private bool PositionIsSet = false;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsSimulationEnd())
        {
            DisplayResults();
        }
    }

    /// <summary>
    /// Display the preprogrammed Simulation results window
    /// </summary>
   public void DisplayResults()
    {
        Instantiate(SimulationResults, gameObject.transform.forward, gameObject.transform.rotation);
        if (PositionIsSet == false)
        {
            SetPosition();
            PositionIsSet = true;
        }
    }

    /// <summary>
    /// Set position of the simulation results window
    /// </summary>
    public void SetPosition()
    {
        SimulationResults.transform.position = gameObject.transform.position;
        SimulationResults.transform.rotation = gameObject.transform.rotation;
    }
}
