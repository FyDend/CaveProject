using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ChaseBehaviour : StateMachineBehaviour
{
    public NavMeshAgent agent;
    private GameObject ghoul, player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ghoul = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        ghoul.GetComponent<Animation>().Play("Run");
        agent = ghoul.GetComponent<NavMeshAgent>();
        agent.speed = 6f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.transform.position);
        if (Vector3.Distance(ghoul.transform.position, player.transform.position) > 20)
        {
            animator.SetBool("isChasing", false);
        }
        if (Vector3.Distance(ghoul.transform.position, player.transform.position) < 3 && !player.GetComponent<PlayerController>().isDead)
        {
            agent.speed = 0;
            player.GetComponent<PlayerController>().Death();
            ghoul.GetComponent<Animation>().Play("Idle");
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
