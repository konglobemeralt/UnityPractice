using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
public class Enemy : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent pathfinder;
    Transform target;

	// Use this for initialization
	void Start () {
        pathfinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        pathfinder.SetDestination(target.position);
	}
}
