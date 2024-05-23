using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.RTS.Units{
    [CreateAssetMenu(fileName = "New Unit", menuName = "Crear nueva Unidad")] 
    public class Unit : ScriptableObject
    {
        public enum tipoUnidad{
            Worker,
            Warrior,
            Ranger
        };
        [Space(15)]
        [Header("Unit Settings")]
        public tipoUnidad tipo;
        public string nombreUnidad;
        public GameObject unitPrefab;
        public GameObject icon;

        [Space(15)]
        [Header("Stats de la unidad")]
        [Space(15)]
        public UnitStatTypes.Base baseStats;
    }

}

