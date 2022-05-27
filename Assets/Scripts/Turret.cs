using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update

   public PlayerTarget target;
    private bool targetLocked;
    public GameObject firingPoint;


    public Transform castPoint;
    public float aiRange;
    public float aiTimeToShoot;
    private float timer;

    public GameObject turret;
    public GameObject bullet;
    public float fireTimer;
    public float fireTest;
    private bool shotready;



    private bool seen = false;
    void Start()
    {
        timer = aiTimeToShoot;
        target = FindObjectOfType<PlayerTarget>();
        fireTest = fireTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetLocked)
        {
            turret.transform.LookAt(target.transform);
            turret.transform.Rotate(0, -90, 0);

            //if (shotready)
            //{
            //    Shoot();
            //}

        }

        if (PlayerWithinDistance(aiRange))
        {

            if (CanSeePlayer(aiRange))
            {

                Debug.Log("i seee you!");
                turret.transform.LookAt(target.transform);


                Shoot();
                    


            }
 
            
        }
        else
        {
            ResetTimer();
        }
    }



    /// <summary>
    /// if the player is within the given distance
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    bool PlayerWithinDistance(float distance)
    {
        if (Vector3.Distance(target.transform.position, transform.position) < distance)
        {
            return true;
        }
        else
        {
            ResetTimer();
            return false;
        }
        //return false;
    }

    /// <summary>
    /// this function is if an object with a raycast can see the player
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
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

                Debug.Log("Rays hit!");
                return true;
            }

        }
        
        return false;
    }


    /// <summary>
    /// Turret Shooting Method, this will instantiate a bullet on the POS of the object
    /// </summary>
    public void Shoot()
    {

        fireTest -= 1 * Time.deltaTime;
        if (TimerBeforeShoot() && fireTimer >= 0)
        {
            Transform _Bullet = Instantiate(bullet.transform, transform.position, Quaternion.identity);
            _Bullet.transform.rotation = turret.transform.rotation;
            fireTest = fireTimer;
            ResetTimer();
        }

            
        
        
        //Transform _Bullet = Instantiate(bullet.transform, transform.position, Quaternion.identity);
        //_Bullet.transform.rotation = turret.transform.rotation;
    }


    bool TimerBeforeShoot()
    {
        timer -= Time.deltaTime * 1;

        if (timer <= 0)
        {
            
            return true;
        }
        else
        {
            return false;
        }

    }

   void ResetTimer()
   {
        timer = aiTimeToShoot;
   }


}
