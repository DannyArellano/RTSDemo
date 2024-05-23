using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.RTS.Buildings{
public class StructHandler : MonoBehaviour
{
    public static StructHandler instance;
        [SerializeField] public BasicBuilding barracks;
        private void Awake(){
            instance = this;
        }

        public BuildingStatTypes.Base GetBasicStructureStats(string type){
            BasicBuilding building;
            switch(type){
                case "barrack":
                    building = barracks;
                    break;
                default:
                    Debug.Log("No existe ese tipo de estructura");
                    return null;
            }
            return building.baseStats;
        }
}

}

