﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    /// <summary> 
    /// This is the master of all spawn points 
    /// This is not an actual spawn point
    /// It controls things such as spawn rate, what enemies can spawn, and overall game behavior
    /// </summary>
    /// 

    #region Variables
    [Range(1, 60)]
    [Tooltip("Wait x seconds to spawn a new enemy")]
    public int spawnRate;

    [Tooltip("Put in the NPCs you want the spawner to create")]
    public EnemyType[] npcTypes;           //Npc types

    GameObject[] spawnPoints;             //The actual spawnPoints in the scene

    GameObject player;
    #endregion

    //[Tooltip("Set the spawner to isActive when the player gets close. Open script for more.")]
    /*public bool IsActive
    {
        //This should be set by actual spawn points
        //When this property is activated, start spawning, else stop spawning
        get
        {
            return isActive;
        }
        set
        {
            IsActive = value;
            if (IsActive)
            {
                StartCoroutine(Spawn());
            } else
            {
                StopCoroutine(Spawn());
            }
        }
    }
    bool isActive = false; */


    void Awake()
    {
        //Get all of the spawn-points in the scene
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if ((spawnPoints != null) && (npcTypes != null))
            {
                // If there is a spawn point in the scene, spawn an enemy from the list of enemy types
         
                GameObject npc = npcTypes[0].EnemyPrefab;

                GameObject spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject newNpc = Instantiate(npc, spawn.transform.position, Quaternion.identity) as GameObject;

                Debug.Log("Enemy spawned:");
                Debug.Log("Type: " + newNpc.name);
                Debug.Log("Spawn location: " + spawn.transform.position);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }
	
}
