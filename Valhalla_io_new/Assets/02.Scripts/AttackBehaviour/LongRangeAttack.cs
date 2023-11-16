using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeAttack : AttackBehaviour
{
    #region Variablse
    private SimulateProjectile simulateProjectile;

    private Animator animator;
    #endregion Variablse

    #region Main Methods
    protected override void Initialize()
    {
        base.Initialize();

        // Todo: add component 형식으로 바꾸기
        // 원거리 공격인지 구분하여 발사체 정보를 가져오도록 하기
        simulateProjectile = GetComponent<SimulateProjectile>();

        animator = GetComponentInParent<Animator>();
    }

    public override void ExecuteAttack()
    {
        animator.SetInteger("AttackIndex", animationIndex);
        animator.SetTrigger("AttackTrigger");
        
        simulateProjectile.Fire();
    }
    #endregion Main Methods
}
