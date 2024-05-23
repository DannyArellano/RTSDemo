using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DA.RTS.Units.Player;

namespace DA.RTS.InputManager{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler instance;
        private RaycastHit hit;
        public List<Transform> selectedUnits = new List<Transform>();
        public Transform selectedBuilding = null;
        public LayerMask interactableLayer = new LayerMask();
        private bool isDragging = false;
        private Vector3 mousePos;
        void Awake()
        {
            instance = this;
        }

        private void OnGUI(){
            if(isDragging){
                Rect rect = Multiselect.GetScreenRect(mousePos, Input.mousePosition);
                Multiselect.DrawScreenRect(rect, new Color(0f,0f,0f, .2f));
                Multiselect.DrawScreenRectBorder(rect, 3, Color.black);
            }
        }

        public void manejarMovimiento(){
            if (Input.GetMouseButtonDown(0)){
                mousePos = Input.mousePosition;
                Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(rayo, out hit, 100, interactableLayer)){
                    if(addedUnit(hit.transform, Input.GetKey(KeyCode.LeftShift))){

                    }
                    else if(addedBuilding(hit.transform)){

                    }
                }
                else{
                    isDragging = true;
                    DeselectUnits();
                }
            }
            if(Input.GetMouseButtonUp(0)){
                foreach(Transform child in Player.PlayerManager.instance.playerUnits){
                    foreach(Transform unit in child){
                        if(isWithinSelection(unit)){
                            addedUnit(unit, true);
                        }
                    }

                }
                isDragging = false;
            }
            if(Input.GetMouseButtonDown(1) && HaveSelection()){
                Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(rayo, out hit)){
                    LayerMask layerHit = hit.transform.gameObject.layer;
                    switch(layerHit.value){
                        case 8:
                            break;
                        case 9:

                            break;
                        default:
                            foreach(Transform unit in selectedUnits){
                                PlayerUnit pU = unit.gameObject.GetComponent<PlayerUnit>();
                                pU.MoveUnit(hit.point);
                            }
                            break;
                    }
                }
            }
        }
        private void DeselectUnits(){
            if(selectedBuilding){
                selectedBuilding.gameObject.GetComponent<Interactable.IBuilding>().OnInteractExit();
                selectedBuilding = null;
            }
            for(int i = 0; i< selectedUnits.Count; i++){
                selectedUnits[i].gameObject.GetComponent<Interactable.IUnit>().OnInteractExit();
                }
            selectedUnits.Clear();
        }
        private bool isWithinSelection(Transform tf){
        if(!isDragging){
            return false;
        }
        Camera cam = Camera.main;
        Bounds vpBounds = Multiselect.GetVPBounds(cam, mousePos, Input.mousePosition);
        return vpBounds.Contains(cam.WorldToViewportPoint(tf.position));
        }

        private bool HaveSelection(){
            if(selectedUnits.Count>0){
                return true;
            }
            return false;
        }

        private Interactable.IUnit addedUnit(Transform tf, bool canMultiselect = false){
            Interactable.IUnit iUnit = tf.GetComponent<Interactable.IUnit>();
            if(iUnit){
                if(!canMultiselect){
                    DeselectUnits();
                }
                selectedUnits.Add(iUnit.gameObject.transform);
                iUnit.OnInteractEnter();
                return iUnit;
                
            }else{
                return null;
            }
        }
        private Interactable.IBuilding addedBuilding(Transform tf){
            Interactable.IBuilding iBuilding = tf.GetComponent<Interactable.IBuilding>();
            if(iBuilding){
                DeselectUnits();

                selectedBuilding = iBuilding.gameObject.transform;

                iBuilding.OnInteractEnter();
                return iBuilding;
            }else{
                return null;
            }
        }
    }
}

