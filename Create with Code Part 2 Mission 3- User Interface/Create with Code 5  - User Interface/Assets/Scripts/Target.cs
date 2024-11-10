using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    [SerializeField] private float minSpeed = 12;
    [SerializeField]private float maxSpeed = 16;
    [SerializeField]private float maxTorque = 10;
    [SerializeField] private float xRange = 4;
    [SerializeField] private float ySpawnPos = -6;

    private GameManager gameManager;

    public int pointValue;

    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); 
        
       targetRb.AddForce(RandomForce(),ForceMode.Impulse);
       targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
       transform.position = RandomSpawnPos();
       
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager> ();
             } 

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private  Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

   private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
private Vector3 RandomSpawnPos()
{
    return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
}
}