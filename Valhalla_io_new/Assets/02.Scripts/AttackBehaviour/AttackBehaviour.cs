using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviour : MonoBehaviour
{
    #region Variables
    public int animationIndex;
    public float coolTime;

    private float calcCoolTime;
    #endregion Variables

    #region Unity Methods
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateCoolTime();
    }
    #endregion Unity Methods

    #region Main Methods
    protected virtual void Initialize()
    {
        calcCoolTime = coolTime;
    }

    private void UpdateCoolTime()
    {
        if(calcCoolTime <= coolTime)
        {
            calcCoolTime += Time.deltaTime;
        }
    }

    public void ResetCoolTime()
    {
        calcCoolTime = 0;
    }

    public abstract void ExecuteAttack();
    #endregion Main Methods
}
