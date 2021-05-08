using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody body;
   public float speed;
    public float shotSpeed=10f;
    public Transform target;
    public float detect=10;
    bool battle;
    public GameObject bullet;
    float second=1f;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        speed = 150;
    }

    // Update is called once per frame
    void Update()
    {

        if (!battle)
        {
            NoBattle();
        }
        InBattle();
    }


    void NoBattle()
    {
        transform.position += new Vector3(0, 0, 10f*Time.deltaTime);
        //float dist = Vector3.Distance(target.position, transform.position);
        //Debug.Log(dist);
        //if (dist > detect)
        //{
        //    body.velocity = -transform.forward * speed * Time.deltaTime;
        //}else body.velocity = transform.forward*speed*Time.deltaTime;

    }



   void InBattle()
    {
       GameObject bul= Instantiate(bullet, transform.position , Quaternion.identity);
        Rigidbody instBulletRigidbody = bul.GetComponent<Rigidbody>();
        instBulletRigidbody.AddForce((target.transform.position - transform.position).normalized * shotSpeed);
        Destroy(bul, 5);
       
    }



    private void OnTriggerStay(Collider other)
    {
        if (target == null)
        {

            if (other.tag == "good")
            {
                second -= 1f * Time.deltaTime;
                if (second < 0)
                {
                    target = other.transform;
                    second = 1f;
                }
            }
        }
    }
}



