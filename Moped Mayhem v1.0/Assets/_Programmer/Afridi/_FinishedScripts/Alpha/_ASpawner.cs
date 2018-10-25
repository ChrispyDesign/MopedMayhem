using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ASpawner : MonoBehaviour
{

    public GameObject m_Biker;
    public GameObject m_Sniper;

    public GameObject[] m_BikerSpwn;
    public GameObject m_SniperSpwn;

    public int BikerSpawnAmount = 0;
    public float BikerSpawnRate = 0.0f;

    public int SniperSpawnAmount = 0;
    public float SniperSpawnRate = 0.0f;

    public bool KillAll;

    void Start()
    {
        KillAll = false;
    }
    void Update()
    {
        if (KillAll)
        {
            Destroy(m_Biker);
        }

        BikerSpawner();
    }
    void BikerSpawner()
    {

        BikerSpawnRate -= Time.deltaTime;
        if (BikerSpawnRate <= 0f)
        {
            for (int Spawns = 0; Spawns < BikerSpawnAmount; Spawns++)
            {
                Instantiate(m_Biker, m_BikerSpwn[Spawns].transform.position, m_BikerSpwn[Spawns].transform.rotation);
                BikerSpawnRate = 10.0f;
                BikerSpawnRate += 1.9f;
            }
        }
    }
}
