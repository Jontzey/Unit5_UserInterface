using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
   
    private Rigidbody targetRb;
    public float forceUpwards = 10;


    private float minSpeed = 14f;
    private float maxSpeed = 20f;
    private float maxTorque = 10f;
    private float xRange = 4;
    private float yRange = -6;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); 
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();

        if (targetRb.position.y < -10)
        {
            Destroy(targetRb);
        }
    }

   
    void Update()
    {
       

        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(targetRb, transform.position, Quaternion.identity);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), yRange);
    }


    private void OnMouseDown()
    {
        Destroy(gameObject);
        
    }
}
