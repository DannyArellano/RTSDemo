using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace DA.RTS.Units.Enemy{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyUnit : MonoBehaviour
    {
        public UnitStatTypes.Base baseStats;
        public Collider[] rangeColliders;
        private Transform aggroTarget;
        private bool hasAggro;
        private float distance;
        private NavMeshAgent agent;
        private float atkCooldown;
        private UnitStatDisplay aggroUnit;
        private void Start(){
            agent = gameObject.GetComponent<NavMeshAgent>();
        }

        private void Update(){
            atkCooldown -= Time.deltaTime;
            if(!hasAggro){
                CheckForTargets();
            }
            else{
                Attack();
                PursuitFunction();
            }
        }

        private void CheckForTargets(){

            rangeColliders = Physics.OverlapSphere(transform.position, baseStats.aggroRange, UnitHandler.instance.pUnitLayer);
            for(int i = 0; i<rangeColliders.Length; i++){
                aggroTarget = rangeColliders[i].gameObject.transform;
                aggroUnit = aggroTarget.gameObject.GetComponentInChildren<UnitStatDisplay>();
                Debug.Log(aggroUnit.name);
                hasAggro = true;
            }
        }

        private void Attack(){
            if(atkCooldown <= 0 && distance <= baseStats.range+1){
                aggroUnit.TakeDamage(baseStats.attack);
                atkCooldown = baseStats.atkSpeed;
            }
        }
        private void PursuitFunction(){
            if(aggroTarget == null){
                agent.SetDestination(transform.position);
                hasAggro = false;
            }else{
                distance = Vector3.Distance(aggroTarget.position, transform.position);
                agent.stoppingDistance = (baseStats.range + 1);
                if(distance <= baseStats.aggroRange){
                agent.SetDestination(aggroTarget.transform.position);
                }
            }
        }
        

        
    }
}


