using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove3 : MonoBehaviour {
    private Transform _destination;

    UnityEngine.AI.NavMeshAgent _navMeshAgent;

    // Use this for initialization
    void Start()
    {
        _navMeshAgent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }
    private void SetDestination()
    {
        _destination = GameObject.FindGameObjectWithTag("Target3").transform;
        if (_destination != null)
        {

            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
