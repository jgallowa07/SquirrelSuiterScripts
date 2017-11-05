using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obticles : MonoBehaviour {

    public GameObject[] ObsticalPrefabs;

    private Transform playerTransform;
    private float spawnZ = 000.0f;
    private float ObsLength = 195.0f;
    private float SafeZone = 325.0f;
    public int amountObsOnScreen = 13;
    private int lastPrefabIndex = 0;
    private int numObs;
    private List<GameObject> activeObs;
    private List<GameObject> activeResetObs;

    // Use this for initialization
    private void Start () {

        activeObs = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        //SpawnObs(0); // Starting Terrain;
        for(int i=0; i<amountObsOnScreen-1; i++)
        {
			SpawnObs ();
			if (i < 8) {
				activeObs [i].SetActive (false);
			}
        }
    }
	
	// Update is called once per frame
    private void Update () {
        //if (playerTransform.position.z >= 2500.0f)
        //{
            //ResetLocation();
        //}
        if (playerTransform.position.z - SafeZone > (spawnZ - (amountObsOnScreen * ObsLength)))
        {
            SpawnObs();
            DeleteObs();
        }
	}

    private void SpawnObs(int prefabIndex = -1)
    {
        //amountObsOnScreen++;

        GameObject go;
        if(prefabIndex == -1)
        {
            go = Instantiate(ObsticalPrefabs[RandomPrefabIndex()]) as GameObject;
        }else
        {
            go = Instantiate(ObsticalPrefabs[prefabIndex]) as GameObject;
        }
        
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        numObs++;
        spawnZ += ObsLength;
        activeObs.Add(go);
    }

    private void DeleteObs()
    {
        /*
        if (numObs < 20)
        {
            return;
        }*/
        Destroy(activeObs[0]);
        activeObs.RemoveAt(0);
        numObs--;
    }

    private int RandomPrefabIndex()
    {
        if(ObsticalPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, ObsticalPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    public void ResetLocation()
    {
        //Debug.Log("we made it");
        spawnZ = 0.0f;
        for( int i=0; i< amountObsOnScreen-1; i++)
        {

            //Debug.Log("we made it to th for loop");
			activeObs[i].transform.position = new Vector3(activeObs[i].transform.position.x, activeObs[i].transform.position.y, activeObs[i].transform.position.z-2970.0f);
            spawnZ += ObsLength;
        }
        //playerTransform.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - 3000.0f);
    }
}
