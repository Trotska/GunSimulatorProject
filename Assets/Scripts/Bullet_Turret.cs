using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Turret : MonoBehaviour
{

    public float moveSpeed = 100.0f;
    public float lifeTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerTarget>().TakeDamage();

        }
    }

    void Movement()
    {
        transform.position += Time.deltaTime * moveSpeed * transform.forward;
    }
}
