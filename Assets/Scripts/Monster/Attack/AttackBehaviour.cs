using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    protected Attack _attack;
    protected float _damage;
    private float destroyDelay = 1f;

    private void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        //
    }
    
    public void InitAttack(Attack a, float d)
    {
        _attack = a;
        _damage = d;
    }
    
}
