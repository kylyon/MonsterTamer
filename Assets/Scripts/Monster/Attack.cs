using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttack", menuName = "Attack", order = 2)]
public class Attack : ScriptableObject
{
    [SerializeField]
    private string name;
    [SerializeField]private Type type;
    [SerializeField]private int damage = 0;
    [SerializeField]private bool isSpecialAttack;
    [SerializeField]private bool isStatusAttack;
    [SerializeField] private GameObject attackPrefab;

    public virtual string GetAttackName()
    {
        return "NullAttack";
    }

    public virtual Type GetType()
    {
        return type;
    }

    public virtual int GetDamageAmount()
    {
        return damage;
    }

    public virtual void UseAttack(Transform positionLauncher, float damageDealed)
    {
        Debug.Log("Attack");
        var go = Instantiate(attackPrefab,positionLauncher.position, Quaternion.LookRotation(positionLauncher.gameObject.GetComponentInParent<Transform>().forward, Vector3.up));
        go.GetComponent<AttackBehaviour>().InitAttack(this, damageDealed);
        return;
    }
}
