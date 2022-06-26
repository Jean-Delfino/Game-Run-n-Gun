using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreature : Creature{
    [SerializeField] PlayerHealthController bar;

    private new void Start() {
        base.Start();
        bar.SetQtdHealth((int) GetMaxLife());
    }

    public override void TakeDamage(float damage){
        //GetMaxLife()
        base.TakeDamage(damage);
        bar.UpdateQtdHealth((int) GetActualLife());
    }
}
