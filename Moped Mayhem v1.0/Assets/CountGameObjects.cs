using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountGameObjects : MonoBehaviour {

    public List<GameObject> numberOfGO;                 // list that stores all the game objects in the scene

    private void Awake()
    {
        // adds all game objects to a list, then counts them and prints it in debug log
        foreach (var item in FindObjectsOfType<GameObject>())
        {
            numberOfGO.Add(item);
        }
        Debug.Log(numberOfGO.Count);
    }

    // Use this for initialization
    void Start () {

	}

    //private void OnDrawGizmos()
    //{
    //    Debug.LogError(numberOfGO.Count);
    //}

    // Update is called once per frame
    void Update () {
		
	}
}
