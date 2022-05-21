using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : Damageable
{
    // Start is called before the first frame update
    public GameManager gameManager;
    //bool IsDead = false;
    int HealthAmount = 100;
    int damageAmount = 100;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead(HealthAmount))
        {
            Debug.Log("Yippie i died");
            gameManager.points += 100;
            DestroyThis();
        }
    }

    public override void DealDamage(float damageAmount)
    {
        Debug.Log("Yippie you Scored");
        gameManager.points += 100;
        base.DealDamage(damageAmount);
    }

    public override void DestroyThis()
    {
        Debug.Log("Yippie i died");
        gameManager.points += 100;
        base.DestroyThis();
    }

    bool IsDead(float HealthBool)
    {
        if (HealthBool <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
