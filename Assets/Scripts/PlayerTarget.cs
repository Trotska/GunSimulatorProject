using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    GameManager gameManager;
    public float HealthPoints = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public void TakeDamage()
    {
        HealthPoints -= 25;
    }

    public void Death()
    {
        if (HealthPoints <= 0)
        {
            //
            //death scene here
        }
    }
}
