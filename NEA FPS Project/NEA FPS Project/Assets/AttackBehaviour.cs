using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{

    Transform player;
    float attackRange = 30;
    float sightRange = 60;
    Enemy enemyScript;
    UnityEngine.AI.NavMeshAgent agent;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyScript = animator.GetComponent<Enemy>();
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();

        
        
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        animator.transform.Rotate(15, 35f, 5);
        enemyScript.Attack();

        float distanceToPlayer = Vector3.Distance(animator.transform.position, player.position);
        if (distanceToPlayer > attackRange) 
        {
             agent.isStopped = false;
             animator.SetBool("isAttacking", false);
        }
        else if (distanceToPlayer < attackRange && distanceToPlayer > 5) 
        {
             agent.isStopped = true;
        }
        else if (distanceToPlayer > sightRange) 
        {
             animator.SetBool("isChasing", true);
        }
        else if (distanceToPlayer > sightRange) 
        {
             animator.SetBool("isChasing", false);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
