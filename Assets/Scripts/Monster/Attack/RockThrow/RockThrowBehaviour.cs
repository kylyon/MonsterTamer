using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrowBehaviour : AttackBehaviour
{
    private Rigidbody rb;
    public float speed;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
    
    protected override void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (other.gameObject.CompareTag("Monster"))
            {
                MonsterBehaviour mb = other.gameObject.GetComponentInParent<MonsterBehaviour>();
                mb.GetHit(_attack, _damage);
            }
            
        }
        
    }
    
}
