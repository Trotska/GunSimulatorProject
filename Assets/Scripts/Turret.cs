using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject target;
    private bool targetLocked;

    public Transform castPoint;

    public GameObject turret;
    public GameObject bullet;
    public float fireTimer;
    private bool shotready;

    private bool seen = false;
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

    bool PlayerWithinDistance(float distance)
    {
        if (Vector3.Distance(target.transform.position, transform.position) < distance)
        {
            return true;
        }
        return false;
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        var castDist = distance;

        Vector3 playerDirection = (target.transform.position - gameObject.transform.position);
        RaycastHit rayhit;
        //Vector3 endpos = gameObject.p;
        //RaycastHit hit = Physics.Linecast(transform.position, transform.rotation);
        if (Physics.Raycast(castPoint.position, playerDirection, out rayhit, distance))
        {
            if (rayhit.collider.CompareTag("Player"))
            {
                return true;
            }


        }
        return false;
    }



    public void Shoot()
    {
        Transform _Bullet = Instantiate(bullet.transform, transform.position, Quaternion.identity);
        _Bullet.transform.rotation = turret.transform.rotation;
    }
}
