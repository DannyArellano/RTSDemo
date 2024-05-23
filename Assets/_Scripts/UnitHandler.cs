using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DA.RTS.Player;

namespace DA.RTS.Units{
    public class UnitHandler : MonoBehaviour
    {
        public static UnitHandler instance;
        public Unit worker, warrior, ranger;

        public LayerMask pUnitLayer, eUnitLayer;
        private void Awake(){
            instance = this;
        }

        public UnitStatTypes.Base GetBasicUnitStats(string type){
            Unit unit;
            switch(type){
                case "worker":
                    unit = worker;
                    break;
                case "warrior":
                    unit = warrior;
                    break;
                case "ranger":
                    unit = ranger;
                    break;
                default:
                    Debug.Log("No existe ese tipo de unidad");
                    return null;
            }
            return unit.baseStats;
        }
    }
}

