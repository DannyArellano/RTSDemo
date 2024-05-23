using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace DA.RTS.Units.Player{
    [RequireComponent(typeof(NavMeshAgent))]
public class PlayerUnit : MonoBehaviour
{
    public UnitStatTypes.Base baseStats;
    private NavMeshAgent agent;
    void OnEnable(){
        agent = GetComponent<NavMeshAgent>();
    }
    void Start(){
    }
    
    void Update(){
    }
    public void MoveUnit(Vector3 _destination){
        agent.SetDestination(_destination);
    }
}


}

