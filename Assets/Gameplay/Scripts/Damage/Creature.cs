using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : DamageTaker{
    [SerializeField] float maxLife = default;
    [SerializeField] CreatureMoveAndAnimator anim = default;

    private float actualLife;

    protected void Start() {
        actualLife = maxLife;
    }

    public override void TakeDamage(float damage){
        if(damage > actualLife){
            anim.DyingAnimation(true);
            return;
        }

        actualLife -= damage;
    }

    protected float GetMaxLife(){
        return this.maxLife;
    }

    protected float GetActualLife(){
        return this.actualLife;
    }
}
