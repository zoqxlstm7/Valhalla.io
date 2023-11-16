using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private AttackBehaviour baseAttack;
    #endregion Variables

    #region Unity Methods
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            AttackManagement(baseAttack);
        }
    }
    #endregion Unity Methods

    #region Main Methods
    public void AttackManagement(AttackBehaviour behaviour)
    {
        behaviour.ExecuteAttack();
    }
    #endregion Main Methods
}
