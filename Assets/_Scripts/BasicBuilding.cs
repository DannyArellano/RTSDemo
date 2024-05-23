using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.RTS.Buildings{
    [CreateAssetMenu(fileName = "Building", menuName = "New Building/Basic")]
    public class BasicBuilding : ScriptableObject
{
    public enum buildingType{
        Barracks
    }

    [Space(15)]
    [Header("Building Settings")]
    public buildingType type;

    public new string name;
    public GameObject buildingPrefab;
    public GameObject icon;
    
    [Space(15)]
    [Header("Building Base Stats")]
    [Space(15)]
    public BuildingStatTypes.Base baseStats;


}

}