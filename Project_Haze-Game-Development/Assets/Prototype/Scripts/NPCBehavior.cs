using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCBehavior : MonoBehaviour {

    NavMeshAgent agent;
    GameObject destination;
    GameObject player;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            Debug.LogWarning("No player is in scene");
        }
        agent = GetComponent<NavMeshAgent>();
        GoTo();
	}

    void GoTo()
    {
        if (player)
        {
            agent.SetDestination(player.transform.position);
            Debug.Log("NPC moving to destination: " + player.transform.position);
        } else
        {
            Debug.LogWarning("NPC attempting to move to null navPoint");
        }
    }
}
