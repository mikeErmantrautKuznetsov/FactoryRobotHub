using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private IPlayer playerMove;

    void Start()
    {
        playerMove = GetComponent<IPlayer>();
    }

    void Update()
    {
        playerMove.MovePlayer();
    }
}
