using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.RTS.Units{
    public class UnitStatTypes : ScriptableObject
    {
        [System.Serializable]
        public class Base{
            public float woodCost, goldCost, aggroRange, range, health, attack, armor, atkSpeed;
        }
    }

}


