using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCollider : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Vector3 boxSize = new Vector3(3, 2, 2);
    #endregion Variables

    #region Unity Methods
    private void Start()
    {
        var initialPos = new Vector3(0, (boxSize.y * 0.5f) * 0.5f, (boxSize.z * 0.5f) * 0.5f);
        transform.position = initialPos;
    }
    #endregion Unity Methods

    #region Main Methods
    public Collider[] CheckOverlapBox(LayerMask targetMask)
    {
        var targets = Physics.OverlapBox(transform.position, boxSize * 0.5f, transform.rotation, targetMask);
        return targets;
    }
    #endregion Main Methods

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(transform.localPosition, boxSize);
    }
#endif
}
