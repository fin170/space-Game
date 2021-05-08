using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp = 100f;
    public Teams t;
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
      if (t == Teams.good)
        {
            if (collision.gameObject.tag == "BadBullet")
            {

                Destroy(collision.gameObject);
                hp -= 20f;
                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
                Debug.Log(hp);
            }
        }
        if (t== Teams.evil)
        {
            if (collision.gameObject.tag == "Bullet")
            {

                Destroy(collision.gameObject);
                hp -= 20f;
                if (hp <= 0)
                {
                    Destroy(gameObject);
                }
                Debug.Log(hp);
            }
        }
    }



    public enum Teams
    {
        evil,
        good
    }
}
