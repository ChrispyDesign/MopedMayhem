using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AlternativeSpawner : MonoBehaviour {

    public GameObject Biker;
    public GameObject Sniper;
    public GameObject Demolisher;
    public GameObject Player;

    public GameObject[] BikerSpawn;
    public GameObject[] SniperSpawn;
    public GameObject[] DemoSpawn;


    public int AmountofBikerSpawns = 0;
    public int AmountofSniperSpawns = 0;
    public int AmountofDemoSpawns = 0;

    public float RateOfBikerSpawn = 0;
    public float RateOfSniperSpawn = 0;
    public float RateOfDemoSpawn = 0;

    private bool BikerExists = false;
    private bool SniperExists = false;
    private bool DemoExists = false;

    [Tooltip("This is the Distance Between the Player and The Biker Spawn point")]
    [Range(0, 60)]
    public float DistanceBetweenBiker = 0;
    [Tooltip("This is the Distance Between the Player and The Sniper Spawn point")]
    [Range(0, 80)]
    public float DistanceBetweenSniper = 0;
    [Tooltip("This is the Distance Between the Player and The Demo Spawn point")]
    [Range(0, 100)]
    public float DistanceBetweenDemo = 0;

    void Awake()
    {
        BikerExists = false;
        SniperExists = false;
        DemoExists = false;
        BikerSpawn = GameObject.FindGameObjectsWithTag("BikerSpawn");
        SniperSpawn = GameObject.FindGameObjectsWithTag("SniperSpawn");
        DemoSpawn = GameObject.FindGameObjectsWithTag("DemoSpawn");

        if (BikerSpawn.Length > 0 && AmountofBikerSpawns > 0) {
            BikerExists = true;
        }
        if (SniperSpawn.Length > 0 && AmountofSniperSpawns > 0)
        {
            SniperExists = true;
        }
        if (DemoSpawn.Length > 0 && AmountofDemoSpawns > 0)
        {
            DemoExists = true;
        }
    }

    void Update()
    {
        if (BikerExists == true)
        {
            MafiaBikerSpawnController();
        }
        if (SniperExists == true)
        {
            MafiaSniperSpawnController();
        }
        if (DemoExists == true)
        {
            MafiaDemoSpawnController();
        }
    }

    void MafiaBikerSpawnController() {
        if (RateOfBikerSpawn != -0)
        {
            RateOfBikerSpawn -= Time.deltaTime;
        }
        var BiDist = Vector3.Distance(Player.transform.position, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.position);
        if (BiDist < DistanceBetweenBiker)
        {
            if (RateOfBikerSpawn <= 0.0f)
            {
                Instantiate(Biker, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.position, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.rotation).SetActive(true);

                RateOfBikerSpawn = 10.0f;
                RateOfBikerSpawn += 1.9f;
            }
        }
    }

    void MafiaSniperSpawnController() {
        if (RateOfSniperSpawn != -0)
        {
            RateOfSniperSpawn -= Time.deltaTime;
        }
        var SniDist = Vector3.Distance(Player.transform.position, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.position);
        if (SniDist < DistanceBetweenSniper)
        {
            if (RateOfSniperSpawn <= 0.0f)
            {
                Instantiate(Sniper, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.position, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.rotation).SetActive(true);

                RateOfSniperSpawn = 20.0f;
                RateOfSniperSpawn += 10.9f;
            }
        }
    }

    void MafiaDemoSpawnController()
    {
        if (RateOfDemoSpawn != -0)
        {
            RateOfDemoSpawn -= Time.deltaTime;
        }
        var DemDist = Vector3.Distance(Player.transform.position, DemoSpawn[Random.Range(0, AmountofDemoSpawns)].transform.position);
        if (DemDist < DistanceBetweenDemo)
        {
            if (RateOfDemoSpawn <= 0.0f)
            {
                Instantiate(Demolisher, DemoSpawn[Random.Range(0, AmountofDemoSpawns)].transform.position, DemoSpawn[Random.Range(0, AmountofDemoSpawns)].transform.rotation).SetActive(true);
                RateOfDemoSpawn = 40.0f;
                RateOfDemoSpawn += 20.9f;
            }
        }
    }
}
