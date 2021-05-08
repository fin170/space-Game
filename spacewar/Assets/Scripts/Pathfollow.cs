using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfollow : MonoBehaviour
{
    public Transform target;
    public float movementSpeed = 10f;
    public float rotDamp = 0.5f;
    //public Transform e;
    //float jimmy = 1f;

    public float dectectionDistance = 20f;
    public float rayCastOffSet = 2.5f;
    public Team team;
    public GameObject bullet;
    public float shotSpeed=1f;
    float shotRate = 5f;
    private GameObject _instBullet;
    public Transform gun;
    private void Start()
    {
       movementSpeed = Random.Range(10f,20f);
   rotDamp = Random.Range(0.4f,0.6f);
}
    void Update()
    {


        shotRate -= 1 * Time.deltaTime;
        //   jimmy -= 1f * Time.deltaTime;
        // if (jimmy < 0) {
        //  e.localScale += new Vector3(1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime);
        //  jimmy = 10f;
        //   }
        Pathfinding();
       Move();
        Fire();

       // transform t = GetComponent<waypoints>().waypoint[0];
       // target = t.positon
      
    }


    void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotDamp * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    void Pathfinding()
    {


        RaycastHit hit;
        Vector3 raycastOffSet = Vector3.zero;


        Vector3 left = transform.position - transform.right * rayCastOffSet;
        Vector3 right = transform.position + transform.right * rayCastOffSet;
        Vector3 up = transform.position + transform.up * rayCastOffSet;
        Vector3 down = transform.position - transform.up * rayCastOffSet;




        Debug.DrawRay(left, transform.forward * dectectionDistance, Color.cyan);
        Debug.DrawRay(right, transform.forward * dectectionDistance, Color.cyan);
        Debug.DrawRay(up, transform.forward * dectectionDistance, Color.cyan);
        Debug.DrawRay(down, transform.forward * dectectionDistance, Color.cyan);

        if (Physics.Raycast(left, transform.forward, out hit, dectectionDistance))
        {
            raycastOffSet += Vector3.right;

        }
        else if (Physics.Raycast(right, transform.forward, out hit, dectectionDistance))
        {
            raycastOffSet -= Vector3.right;

        }

        if (Physics.Raycast(up, transform.forward, out hit, dectectionDistance))
        {
            raycastOffSet -= Vector3.up;

        }
        else if (Physics.Raycast(down, transform.forward, out hit, dectectionDistance))
        {
            raycastOffSet += Vector3.up;

        }

        if (raycastOffSet != Vector3.zero)
        {
            transform.Rotate(raycastOffSet * 5f * Time.deltaTime);
        } else
        {
            Turn();
        }


    }

    void Fire()
    {

        //GameObject clone = Instantiate(bullet, transform.position + new Vector3(0, 0, 1), Quaternion.identity) ;
        //Rigidbody instBulletRigidbody = bullet.GetComponent<Rigidbody>();
        ////instBulletRigidbody.AddForce((target.transform.position - transform.position).normalized * shotSpeed);
        //// clone.transform.LookAt(target.position);
        ////  clone.transform.position += transform.forward * shotSpeed * Time.deltaTime;
        //Vector3 shoot = (target.position - clone.transform.position).normalized;
        //instBulletRigidbody.AddForce(shoot * 500.0f);
        //Destroy(clone, 5);
        shotRate -= 1 * Time.deltaTime;
        if (shotRate <= 0)
        {
            Vector3 pos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(pos);
            
            GameObject bul = Instantiate(bullet, gun.position, Quaternion.identity) as GameObject;
            //Rigidbody instBulletRigidbody = bul.GetComponent<Rigidbody>();
            bul.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotDamp * Time.deltaTime);
            //instBulletRigidbody.AddForce((target.transform.position - transform.position).normalized * shotSpeed);
            bul.transform.position += transform.forward * shotSpeed/100f * Time.deltaTime;
            Destroy(bul, 2);
        }


        if (shotRate <= 0)
        {
            shotRate = Random.Range(2f, 5f);
        }

    }


    private void OnTriggerStay(Collider other)
    {
        if (target == null)
        {
            if (team == Team.good)
            {


                if (other.tag == "evil")
                {

                    target = other.transform;
                  //  Debug.Log("new target");
                }
            }
            if (team == Team.evil)
            {


                if (other.tag == "good")
                {

                    target = other.transform;
                  //  Debug.Log("new target");
                }
            }

            // Debug.Log("target is null");

          

        }
       
        if (shotRate <0)
        {

            Fire();
            shotRate = 5f;
        }
        

    }



    public enum Team {
        evil,
        good
        }
}
