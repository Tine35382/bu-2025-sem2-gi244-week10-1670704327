using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] public List<GameObject> obstaclePrefab;

    
    //public GameObject obstaclePrefab;
    public Vector3 spawnPos = new(25, 0, 0);

    public float startDelay = 2;
    public float repeatRate = 2;

    private PlayerController playerController;

    private int currentIndexList = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);

        GameObject.Find("Player").GetComponent<PlayerController>();

        
    }

    /*void Start()
    {
        // Instantiate(obstaclePrefab, new Vector3(25, 0, 0), obstaclePrefab.transform.rotation);

        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);

        GameObject.Find("Player").GetComponent<PlayerController>();

        GameObject obstaclePrefab = obstaclePrefab[currentIndexList];
    } */
    void SpawnObstacle()
    {

        if (obstaclePrefab.Count == 0) return;

        GameObject currenObstacle =  obstaclePrefab[currentIndexList];

        Instantiate(currenObstacle , spawnPos , currenObstacle.transform.rotation);

        currentIndexList++;

        if (currentIndexList >= obstaclePrefab.Count)
        {
            currentIndexList = 0;
        }
        
    }

}
