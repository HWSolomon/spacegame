using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnComet : MonoBehaviour
{

    public Transform CometSpawner;
    public GameObject Comet;
    public float spawnstart = 2f;
    public float spawnloop = 2f;

    void Start()
    {
        InvokeRepeating("SpawnComet", spawnstart, spawnloop);
    }
    // Update is called once per frame
    void SpawnComet()
    {
        Instantiate(Comet, CometSpawner.position, CometSpawner.rotation);
    }

}
