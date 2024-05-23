using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DA.RTS.UI.HUD{
    public class ActionFrame : MonoBehaviour
    {
        public static ActionFrame instance = null;
        [SerializeField] private Button actionButton = null;
        [SerializeField] private Transform layoutGroup = null;

        private List<Button> buttons = new List<Button>();
        private void Awake(){
            instance = this;
        }

        public void SetActionButtons(PlayerActions actions){
            if(actions.basicUnits.Length > 0){
                foreach(Units.Unit unit in actions.basicUnits){
                    Button btn = Instantiate(actionButton, layoutGroup);
                    GameObject icon = Instantiate(unit.icon, btn.transform);
                    btn.name = unit.name;
                    buttons.Add(btn);
                }
            }
            if(actions.basicBuildings.Length>0){
                foreach(Buildings.BasicBuilding building in actions.basicBuildings){
                    Button btn = Instantiate(actionButton, layoutGroup);
                    GameObject icon = Instantiate(building.icon, btn.transform);
                    btn.name = building.name;
                    buttons.Add(btn);
                }
            }
        }
        public void ClearActions(){
            foreach(Button btn in buttons){
                Destroy(btn.gameObject);
            }
            buttons.Clear();
        }

        public void Spawn(string objectToSpawn){
        }

        private Units.Unit IsUnit(string name){
            return null;
        }
        
        private Buildings.BasicBuilding IsBuilding(string name){
            return null;
        }
    }

}