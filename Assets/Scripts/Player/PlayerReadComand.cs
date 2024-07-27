using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerReadComand : MonoBehaviour, IPlayer
{
    private float RateBoundsXNegative = 8.3f;
    private float RateBoundsZNegative = 7.5f;
    private float RateBoundsX = 6.7f;
    private float RateBoundsZ = 4.2f;
    [SerializeField]
    private NavMeshAgent meshAgent;
    [SerializeField]
    private Camera cameraMash;
    [SerializeField]
    private Animator animator;
    private bool isMove;

    public void MovePlayer()
    {
        BoundsPosition();
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRacast = cameraMash.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHitMy;

            if (Physics.Raycast(myRacast, out raycastHitMy))
            {
                meshAgent.SetDestination(raycastHitMy.point);
            }
        }

        if (meshAgent.remainingDistance <= meshAgent.stoppingDistance)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }

        animator.SetBool("IsMove", isMove);
    }

    private void BoundsPosition()
    {
        if (transform.position.x < -RateBoundsXNegative)
        {
            transform.position = new Vector3(-RateBoundsXNegative, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > RateBoundsX)
        {
            transform.position = new Vector3(RateBoundsX, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > RateBoundsZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, RateBoundsZ);
        }
        else if (transform.position.z < -RateBoundsZNegative)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -RateBoundsZNegative);
        }
    }
}
