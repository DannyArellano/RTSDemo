using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DA.RTS.InputManager;

namespace DA.RTS.Player{
    public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Transform playerUnits;
    public Transform enemyUnits;
    public Transform playerBuildings;
    void Awake()
    {
        instance = this;
        SetBasicStats(playerUnits);
        SetBasicStats(enemyUnits);
        SetBasicStats(playerBuildings);
        
    }
    void Update()
    {
        InputHandler.instance.manejarMovimiento();
    }
    public void SetBasicStats(Transform type){
            foreach(Transform child in type){
                foreach(Transform tf in child){
                    string name = child.name.Substring(0, child.name.Length-1).ToLower();
                    //var stats = Units.UnitHandler.instance.GetBasicUnitStats(unitName);
                    if(type == playerUnits){
                        Units.Player.PlayerUnit pU = tf.GetComponent<Units.Player.PlayerUnit>();
                        pU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);
                    }else if(type == enemyUnits){
                        Units.Enemy.EnemyUnit eU = tf.GetComponent<Units.Enemy.EnemyUnit>();
                        eU.baseStats = Units.UnitHandler.instance.GetBasicUnitStats(name);
                    }else if(type == playerBuildings){
                        Buildings.Player.PlayerBuilding pB = tf.GetComponent<Buildings.Player.PlayerBuilding>();
                        pB.baseStats = Buildings.StructHandler.instance.GetBasicStructureStats(name);
                    }
                }
            }
        }
}
}

