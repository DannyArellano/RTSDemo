using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DA.RTS.Units{

public class UnitStatDisplay : MonoBehaviour
{
    public float maxHealth, armor, currentHealth;
    [SerializeField] private Image healthIcon;
    private bool isPlayerUnit = false;

    public void Start(){
        try{
            maxHealth = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.health;
            armor = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.armor;
            isPlayerUnit = true;
        }
        catch(Exception){
            try{
                maxHealth = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.health;
                armor = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.armor;
                isPlayerUnit = false;
            }catch(Exception){
            }

        }
        currentHealth = maxHealth;
    }
    public void Update(){
        HandleHealth();

    }
    private void HandleHealth(){
            Camera camera = Camera.main;
            gameObject.transform.LookAt(gameObject.transform.position + camera.transform.rotation*Vector3.forward, camera.transform.rotation*Vector3.up);

            healthIcon.fillAmount = currentHealth/maxHealth;

            if(currentHealth <= 0){
                Die();
            }
        }
    private void Die()
        {
            if(isPlayerUnit){
                InputManager.InputHandler.instance.selectedUnits.Remove(gameObject.transform.parent.gameObject.transform); 
                Destroy(gameObject.transform.parent.gameObject);
            }else{
                Destroy(gameObject.transform.parent.gameObject);
            }
            
        }
        
        
    public void TakeDamage(float damage){
        float totalDamage = damage - armor;
        currentHealth -= totalDamage;
    }
}


}

