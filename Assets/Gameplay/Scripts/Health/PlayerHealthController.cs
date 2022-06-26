using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour{
    [SerializeField] Transform playerHealthBar = default;
    [SerializeField] GameObject healthPrefab = default;

    private int numberOfHealth;

    private delegate void TypeUpdate();

    public void SetQtdHealth(int numberOfHealth){
        this.numberOfHealth = numberOfHealth;
        int i;

        for(i = 0; i < numberOfHealth; i++){
            Instantiate<GameObject>(healthPrefab, playerHealthBar);
        }
    }

    public void UpdateQtdHealth(int newNumberOfHealth){
        TypeUpdate updater = DecreaceQtdHealth;

        if(newNumberOfHealth > numberOfHealth){
            updater = IncreaceQtdHealth;
        }

        while (numberOfHealth != newNumberOfHealth){
            updater();
        }
    }

    private void DecreaceQtdHealth(){
        GameObject toDestroy = playerHealthBar.GetChild(0).gameObject;
        
        Destroy(toDestroy);
        numberOfHealth--;
    }

    private void IncreaceQtdHealth(){
        Instantiate<GameObject>(healthPrefab, playerHealthBar);
        numberOfHealth++;
    }
}
