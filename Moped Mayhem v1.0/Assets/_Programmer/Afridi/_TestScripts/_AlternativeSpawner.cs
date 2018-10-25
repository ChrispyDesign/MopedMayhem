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

    [Tooltip("This is the Distance Between the Player and The Biker Spawn point")]
    [Range(0, 60)]
    public float DistanceBetweenBiker = 0;
    [Tooltip("This is the Distance Between the Player and The Biker Spawn point")]
    [Range(0, 80)]
    public float DistanceBetweenSniper = 0;
    [Tooltip("This is the Distance Between the Player and The Biker Spawn point")]
    [Range(0, 100)]
    public float DistanceBetweenDemo = 0;

    void Awake()
    {
        BikerSpawn = GameObject.FindGameObjectsWithTag("BikerSpawn");
        SniperSpawn = GameObject.FindGameObjectsWithTag("SniperSpawn");
        DemoSpawn = GameObject.FindGameObjectsWithTag("DemoSpawn");
    }

    void Update()
    {  
        MafiaBikerSpawnController();
        MafiaSniperSpawnController();
        MafiaDemoSpawnController();
    }

    void MafiaBikerSpawnController() {
        RateOfBikerSpawn -= Time.deltaTime;
        var BiDist = Vector3.Distance(Player.transform.position, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.position);
        if (BiDist > DistanceBetweenBiker)
        {
            if (RateOfBikerSpawn <= 0.0f)
            {
                Instantiate(Biker, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.position, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.rotation);

				var tempMovement = Biker.GetComponent<BikerMovement>();
				tempMovement.m_Player = Player;
				tempMovement.m_Line = Biker.GetComponent<LineRenderer>();

				var tempAI = Biker.GetComponent<BikerAI>();
				tempAI.m_ParentObject = Biker;
				tempAI.m_Player = Player;

                RateOfBikerSpawn = 10.0f;
                RateOfBikerSpawn += 1.9f;
            }
        }
    }

    void MafiaSniperSpawnController() {
        RateOfSniperSpawn -= Time.deltaTime;
        var SniDist = Vector3.Distance(Player.transform.position, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.position);
        if (SniDist > DistanceBetweenSniper)
        {
            if (RateOfSniperSpawn <= 0.0f)
            {
                Instantiate(Sniper, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.position, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.rotation);
                RateOfSniperSpawn = 20.0f;
                RateOfSniperSpawn += 10.9f;
            }
        }
    }

    void MafiaDemoSpawnController()
    {
        RateOfDemoSpawn -= Time.deltaTime;
        var DemDist = Vector3.Distance(Player.transform.position, DemoSpawn[Random.Range(0, AmountofDemoSpawns)].transform.position);
        Debug.Log(DemDist);
        if (DemDist > DistanceBetweenDemo)
        {
            if (RateOfDemoSpawn <= 0.0f)
            {
                Instantiate(Demolisher, DemoSpawn[Random.Range(0, AmountofDemoSpawns)].transform.position, DemoSpawn[Random.Range(0, AmountofDemoSpawns)].transform.rotation);
                RateOfDemoSpawn = 40.0f;
                RateOfDemoSpawn += 20.9f;
            }
        }
    }
}
