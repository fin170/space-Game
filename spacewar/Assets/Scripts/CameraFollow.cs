using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform evilShip;
    float second=1f; 
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate() {   
        if(Time.time > 10f && Time.time< 20f){
            transform.position = evilShip.position + new Vector3(0, 100f, 0);
    }


        if (Time.time > 20f)
        {
            transform.position = target.position + new Vector3(0, 15f, 0);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(target== null)
        {

            if(other.tag == "good")
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
