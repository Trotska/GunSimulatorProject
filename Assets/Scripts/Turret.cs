using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject target;
    private bool targetLocked;

    public GameObject turret;
    public GameObject bullet;
    public float fireTimer;
    private bool shotready;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetLocked)
        {
            turret.transform.LookAt(target.transform);
            turret.transform.Rotate(0, -90, 0);

            if (shotready)
            {
                Shoot();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.gameObject; 
            targetLocked = true;
        }

    }



    public void Shoot()
    {
        Transform _Bullet = Instantiate(bullet.transform, transform.position, Quaternion.identity);
        _Bullet.transform.rotation = turret.transform.rotation;
    }
}
