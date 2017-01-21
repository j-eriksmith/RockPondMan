using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    private GameObject[] waypoints;
    private int currentWaypoint = 0;
    private bool backwards = false;

    public float movespeed;
    public string tagSeek;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectsWithTag(tagSeek);
        Array.Sort(waypoints, compareWaypoints);
        
	}
	
	// Update is called once per frame
	void Update () {
        moveToWaypoint();
	}
    void moveToWaypoint() { //Using current waypoint destination, gradually move towards destination (called by Update)
        Vector3 target = waypoints[currentWaypoint].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, movespeed);
        if (transform.position == target)
        {
            findNextWaypoint();
        }
    }
    void findNextWaypoint() //Calculates which waypoint to head to next when it reaches a destination.
    {
        if (currentWaypoint == waypoints.Length - 1)
        {
            currentWaypoint = waypoints.Length - 2;
            backwards = true;
        }
        else if (currentWaypoint == 0)
        {
            currentWaypoint = 1;
            backwards = false;
        }
        else
        {
            if (backwards == false)
                currentWaypoint++;
            if (backwards)
                currentWaypoint--;
        }
    }
    void flattenWaypoints() //Puts each waypoint on the same z-axis as the moving object regardless of their initial placement.
    {
        foreach (GameObject point in waypoints)
        {
            point.transform.position = new Vector3(point.transform.position.x, point.transform.position.y, this.transform.position.z);
        }
    }

    int compareWaypoints(GameObject x, GameObject y) //Sorting algorithm for alphabatizing waypoints by their Unity names (letters then nums)
    {
        return x.name.CompareTo(y.name);
    }
}
