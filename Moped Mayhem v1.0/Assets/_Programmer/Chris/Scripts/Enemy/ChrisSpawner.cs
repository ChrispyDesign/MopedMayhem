using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisSpawner : MonoBehaviour
{

	public GameObject Biker;
	public GameObject Sniper;
	public GameObject Player;

	private GameObject[] BikerSpawn;
	private GameObject[] SniperSpawn;

	private bool[] m_UsedSniperSpawns;

	public List<GameObject> m_ActiveBikers = new List<GameObject>();
	public List<GameObject> m_ActiveSnipers = new List<GameObject>();

	public int AmountofBikerSpawns = 0;
	public int AmountofSniperSpawns = 0;

	public float RateOfBikerSpawn = 0;
	public float RateOfSniperSpawn = 0;

	private bool BikerExists = false;
	private bool SniperExists = false;

	[Tooltip("This is the Distance Between the Player and The Biker Spawn point")]
	[Range(0, 60)]
	public float DistanceBetweenBiker = 0;
	[Tooltip("This is the Distance Between the Player and The Sniper Spawn point")]
	[Range(0, 80)]
	public float DistanceBetweenSniper = 0;

	void Awake()
	{
		BikerExists = false;
		SniperExists = false;
		BikerSpawn = GameObject.FindGameObjectsWithTag("BikerSpawn");
		SniperSpawn = GameObject.FindGameObjectsWithTag("SniperSpawn");

		if (BikerSpawn.Length > 0 && AmountofBikerSpawns > 0)
		{
			BikerExists = true;
		}
		if (SniperSpawn.Length > 0 && AmountofSniperSpawns > 0)
		{
			SniperExists = true;
			m_UsedSniperSpawns = new bool[SniperSpawn.Length];
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
	}

	void MafiaBikerSpawnController()
	{
		if (RateOfBikerSpawn != -0)
		{
			RateOfBikerSpawn -= Time.deltaTime;
		}
		var BiDist = Vector3.Distance(Player.transform.position, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.position);
		if (BiDist < DistanceBetweenBiker)
		{
			Debug.Log("Too Close Get Away From Me");
		}
		else
		{
			if (RateOfBikerSpawn <= 0.0f)
			{
				Instantiate(Biker, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.position, BikerSpawn[Random.Range(0, AmountofBikerSpawns)].transform.rotation).SetActive(true);

				RateOfBikerSpawn = 10.0f;
				RateOfBikerSpawn += 1.9f;
			}
		}
	}

	void MafiaSniperSpawnController()
	{
		if (RateOfSniperSpawn != -0)
		{
			RateOfSniperSpawn -= Time.deltaTime;
		}
		var SniDist = Vector3.Distance(Player.transform.position, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.position);
		if (SniDist < DistanceBetweenSniper)
		{
			Debug.Log("Too Close Get Away");
		}
		else
		{
			if (RateOfSniperSpawn <= 0.0f)
			{
				Instantiate(Sniper, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.position, SniperSpawn[Random.Range(0, AmountofSniperSpawns)].transform.rotation).SetActive(true);

				RateOfSniperSpawn = 20.0f;
				RateOfSniperSpawn += 10.9f;
			}
		}
	}
}
