using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public List<GameObject> ships = new  List<GameObject>();
    float totalX,cenX;
    float totalY,cenY;
    float totalZ,cenZ;
    
  
    void Update()
    {

        totalX = 0;
        totalY = 0;
        totalZ = 0;
        foreach (GameObject ship in ships)
        {
            totalX += ship.transform.position.x;
            totalY += ship.transform.position.y;
            totalZ += ship.transform.position.z;
        }
        cenX = totalX / ships.Count;
        cenY = totalY / ships.Count;
        cenZ = totalZ / ships.Count;
        Debug.Log("x" +cenX +"y" +cenY + "z"+ cenZ) ;
       
    }
}
