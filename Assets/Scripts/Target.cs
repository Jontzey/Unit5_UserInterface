using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
   
    private Rigidbody targetRb;
    private int pointValue;
    private Game_Manager manager;

    public ParticleSystem particlesExplosion;

    private float minSpeed = 14f;
    private float maxSpeed = 20f;
    private float maxTorque = 10f;
    private float xRange = 4;
    private float yRange = -6;
    void Start()
    {

        manager = GameObject.Find("Game Manager").GetComponent<Game_Manager>();
        targetRb = GetComponent<Rigidbody>();
        //particlesExplosion = GetComponent<ParticleSystem>();


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
        PointManager();
        Destroy(gameObject);
        particlesExplosion.Play();
        Instantiate(particlesExplosion, transform.position, Quaternion.identity);
    }

    void SendPoint(int value)
    {
        manager.UpdateScore(pointValue + value);
    }
    void PointManager()
    {
        if (gameObject.CompareTag("Good1"))
        {
            SendPoint(1);
        }
        if (gameObject.CompareTag("Good2"))
        {
            SendPoint(3);
        }
        if (gameObject.CompareTag("Good3"))
        {
            SendPoint(5);
        }
        if (gameObject.CompareTag("Bad1"))
        {
            SendPoint(0);
        }
    }
}
