using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#nullable enable

public class AIPlayerScript : MonoBehaviour
{
  NavMeshAgent? agent;
  GameObject? currentWaypoint;
  List<GameObject> waypoints = new List<GameObject>();
  int currentWaypointIndex = -1;

  void DebugDrawWaypointRoute(GameObject currentWaypoint)
  {
    Debug.DrawLine(transform.position, currentWaypoint.transform.position, Color.red);
  }

  System.Collections.IEnumerator WaypointLoop(NavMeshAgent agent)
  {
    while (true)
    {
      yield return new WaitForSeconds(3f);

      var waypoint = waypoints[(++currentWaypointIndex) % waypoints.Count];

      currentWaypoint = waypoint;
      agent.SetDestination(waypoint.transform.position);
    }
  }

  void Awake()
  {
    agent = GetComponent<NavMeshAgent>();

    waypoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Waypoint"));
  }

  void Start()
  {
    if (agent != null)
    {
      StartCoroutine(WaypointLoop(agent: agent));
    }
  }

  void LateUpdate()
  {
    if (currentWaypoint != null)
    {
      DebugDrawWaypointRoute(currentWaypoint: currentWaypoint);
    }
  }
}
