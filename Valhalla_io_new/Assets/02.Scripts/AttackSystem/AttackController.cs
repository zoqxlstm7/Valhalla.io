using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    #region Variables
    private bool isLongRangeAttack;
    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        isLongRangeAttack = GetComponentInChildren<ManualCollider>() != null;
    }
    #endregion Unity Methods

    #region Main Methods
    public void AttackManagement()
    {
        if(isLongRangeAttack)
        {

        }
        else
        {

        }
    }
    #endregion Main Methods
}
