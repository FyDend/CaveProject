using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    public List<Transform> patrolPosition = new List<Transform>();
    public NavMeshAgent agent;
    private GameObject ghoul, player;

    int currentPatrolPosition;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ghoul = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        patrolPosition = ghoul.GetComponent<GhoulManager>().patrolPosition;
        currentPatrolPosition = Random.Range(0, patrolPosition.Count-1);
        agent = ghoul.GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolPosition[currentPatrolPosition].position);
        agent.speed = 1.5f;
        ghoul.GetComponent<Animation>().Play("Walk");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PatrolMethod(animator);
        if(agent.isStopped)
        {
            PatrolMethod(animator);
        }
    }

    private void PatrolMethod(Animator animator)
    {
        if (Vector3.Distance(ghoul.transform.position, patrolPosition[currentPatrolPosition].position) < 1)
        {
            currentPatrolPosition = Random.Range(0, patrolPosition.Count);
            agent.SetDestination(patrolPosition[currentPatrolPosition].position);
        }
        if (Vector3.Distance(ghoul.transform.position, player.transform.position) < 15)
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
