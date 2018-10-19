using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestSpawner : MonoBehaviour {

    public GameObject m_Biker;
    public GameObject m_Sniper;

    public GameObject m_BikerSpwn;
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
        BikerSpawnRate -= Time.deltaTime;
        if (BikerSpawnRate <= 0f)
        {
            SpawnMe(BikerSpawnAmount, 5.0f, m_Biker.transform, m_BikerSpwn.transform);
            BikerSpawnRate = 10.0f;
            BikerSpawnRate += 1.9f;
        }
        

    }

    public void SpawnMe(int EnemyAmount, float spaceBetween, Transform Enemy, Transform SpawnPint)
    {
        for (int Spawns = 0; Spawns < EnemyAmount; Spawns++)
        {
            Instantiate(Enemy, SpawnPint.position, SpawnPint.rotation);
        }
    }
}

