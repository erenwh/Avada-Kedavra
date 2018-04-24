using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove2 : MonoBehaviour {
    //public Transform player;
    private Transform _destination;
    private Animator anim;

    NavMeshAgent _navMeshAgent;

    public bool startAttack = false;

    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();

        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    void Update()
    {
        Vector3 targetVector = _destination.transform.position;
        if (Vector3.Distance(targetVector, this.transform.position) < 5)
        {

            startAttack = true;
            Vector3 direction = _destination.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                Quaternion.LookRotation(direction), 0.1f);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);

        }
    }


    private void SetDestination()
    {
        _destination = GameObject.FindWithTag("Target2").transform;


        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
        }



    }
}
