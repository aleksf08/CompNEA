using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class PatrolBehaviour : StateMachineBehaviour
{

    List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;

    Transform player;

    float sightRange = 60;
    float attackRange = 30;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject waypointCluster = GameObject.FindGameObjectWithTag("WayPoint");

        Transform patrolWaypoints = waypointCluster.transform;
        waypoints.Clear();

        foreach(Transform waypoint in patrolWaypoints)
        {
                waypoints.Add(waypoint);
        }

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if(agent.remainingDistance < agent.stoppingDistance + 0.2f)
        {
            int randomIndex = Random.Range(0, waypoints.Count);
            agent.SetDestination(waypoints[Random.Range(0, waypoints.Count)].position);
        }

        float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
        if(distanceToPlayer < sightRange)
        {
            animator.SetBool("isChasing", true);

        }


        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
