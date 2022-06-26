using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureMoveAndAnimator : MonoBehaviour{
    protected Animator anim;

    public abstract void DyingAnimation(bool state);
    public abstract void MovementAnimation(float walkSpeed, bool jump);
}
