using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.RTS.Interactable{
    public class Interactable : MonoBehaviour
{
    public bool isInteracting = false;
    public GameObject highlight = null;
    public virtual void Awake(){
        highlight.GetComponent<Renderer>().materials[1].SetFloat("_Scale", 0f);
    }
    public virtual void OnInteractEnter(){
        ShowHighlight();
        isInteracting = true;
    }

    public virtual void OnInteractExit(){
        HideHighlight();
        isInteracting = false;
    }
    public virtual void ShowHighlight(){
        highlight.GetComponent<Renderer>().materials[1].SetFloat("_Scale", 1.2f);
    }
    public virtual void HideHighlight(){
        highlight.GetComponent<Renderer>().materials[1].SetFloat("_Scale", 0f);
    }
}

}