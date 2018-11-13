using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisSpawner : MonoBehaviour
{
	public GameObject m_Player;

	public GameObject m_Biker;
	public GameObject m_Sniper;

	private GameObject[] m_BikerSpawns;
	private GameObject[] m_SniperSpawns;

	private List<GameObject> m_AvailableSniperSpawns = new List<GameObject>();

	public int m_nMaxBikers = 10;
	public int m_nMaxSnipers = 10;
	
	public int m_nActiveBikers = 0;
	public int m_nActiveSnipers = 0;

	public float m_fInitBikerSpawnTime = 10.0f;
	public float m_fInitSniperSpawnTime = 20.0f;

	[Range(1.0f, 2.0f)]
	public float m_fBikerBase = 1.2f;
	[Range(1.0f, 2.0f)]
	public float m_fSniperBase = 1.2f;

	private float m_fBikerSpawnTime = 0.0f;
	private float m_fSniperSpawnTime = 0.0f;

	private float m_fLastBikerSpawnTime = 0.0f;
	private float m_fLastSniperSpawnTime = 0.0f;

	private bool m_bBikerExists = false;
	private bool m_bSniperExists = false;

	[Tooltip("The Min Distance Between the Player and Biker Spawn point required to spawn")]
	[Range(0, 60)]
	public float m_fMinRangeToBiker = 0;
	[Tooltip("The Min Distance Between the Player and Sniper Spawn point required to spawn")]
	[Range(0, 80)]
	public float m_fMinRangeToSniper = 0;

	void Awake()
	{
		m_bBikerExists = false;
		m_bSniperExists = false;
		m_BikerSpawns = GameObject.FindGameObjectsWithTag("BikerSpawn");
		m_SniperSpawns = GameObject.FindGameObjectsWithTag("SniperSpawn");

		m_AvailableSniperSpawns.AddRange(m_SniperSpawns);

		m_bBikerExists = (m_BikerSpawns.Length > 0 && m_Biker != null);

		m_bSniperExists = (m_SniperSpawns.Length > 0 && m_Sniper != null);

		if (m_nMaxSnipers > m_SniperSpawns.Length)
		{
			m_nMaxSnipers = m_SniperSpawns.Length;
		}

		m_fBikerSpawnTime = m_fInitBikerSpawnTime;
		m_fSniperSpawnTime = m_fInitSniperSpawnTime;
	}

	void Update()
	{
		if (m_bBikerExists && m_nActiveBikers < m_nMaxBikers)
		{
			SpawnBiker();
		}
		if (m_bSniperExists && m_nActiveSnipers < m_nMaxSnipers)
		{
			SpawnSniper();
		}
	}

	public void FreeSniperSpawn(int index)
	{
		m_AvailableSniperSpawns.Add(m_SniperSpawns[index]);
	}

	void SpawnBiker()
	{
		if (Time.time > m_fLastBikerSpawnTime + m_fBikerSpawnTime)
		{
			bool bSearching = true;
			int nSearchCount = 0;

			while (bSearching)
			{
				if (nSearchCount > 5)
				{
					Debug.LogWarning("Failed to spawn Biker");
					return;
				}

				int nRandom = Random.Range(0, m_BikerSpawns.Length);
				var curSpawn = m_BikerSpawns[nRandom];

				float fDist = Vector3.Distance(m_Player.transform.position, curSpawn.transform.position);
				if (fDist > m_fMinRangeToBiker)
				{
					var temp = Instantiate(m_Biker, curSpawn.transform);
					temp.SetActive(true);

					var tracker = temp.AddComponent<Tracker>();
					tracker.m_Spawner = this;

					m_nActiveBikers++;

					m_fLastBikerSpawnTime = Time.time;
					m_fBikerSpawnTime = m_fInitBikerSpawnTime * Mathf.Pow(m_fBikerBase, m_nActiveBikers);

					bSearching = false;
				}
				else
				{
					nSearchCount++;
				}
			}
		}
	}

	void SpawnSniper()
	{
		if (Time.time > m_fLastSniperSpawnTime + m_fSniperSpawnTime)
		{
			bool bSearching = true;
			int nSearchCount = 0;

			while (bSearching)
			{
				if (nSearchCount > 5)
				{
					Debug.LogWarning("Failed to spawn Sniper");
					return;
				}

				int nRandom = Random.Range(0, m_AvailableSniperSpawns.Count);
				var curSpawn = m_AvailableSniperSpawns[nRandom];

				float fDist = Vector3.Distance(m_Player.transform.position, curSpawn.transform.position);
				if (fDist > m_fMinRangeToBiker)
				{
					var temp = Instantiate(m_Sniper, curSpawn.transform);
					temp.SetActive(true);

					var tracker = temp.AddComponent<Tracker>();
					tracker.m_Spawner = this;
					tracker.m_bIsSniper = true;


					for (int i = 0; i < m_SniperSpawns.Length; ++i)
					{
						if (m_SniperSpawns[i] == curSpawn)
						{
							tracker.m_nSpawnIndex = i;
							break;
						}
					}

					m_AvailableSniperSpawns.RemoveAt(nRandom);

					m_nActiveSnipers++;

					m_fLastSniperSpawnTime = Time.time;
					m_fSniperSpawnTime = m_fInitSniperSpawnTime * Mathf.Pow(m_fSniperBase, m_nActiveSnipers);

					bSearching = false;
				}
				else
				{
					nSearchCount++;
				}
			}
		}
	}
}
