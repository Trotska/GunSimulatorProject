using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Turret : MonoBehaviour
{

    public float moveSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }
}
