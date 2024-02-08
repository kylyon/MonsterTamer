using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MonsterBehaviour : MonoBehaviour
{
    public string monsterName;
    
    //Stats
    private float pvStat = 200;
    private float pvLeft;
    private float attackStat = 50;
    private float specialAttackStat = 50;
    private float defenseStat = 50;
    private float specialDefenseStat = 50;
    private float speedStat = 50;
    
    public Type primaryType;
    public Type secondaryType;

    public Attack firstAttack;
    public Attack secondAttack;
    public Attack thirdAttack;

    public Transform popupParent;
    public Transform attackLauncher;
    
    //UI WorldSpace
    public TMP_Text textNameMonster;
    public Image hpBar;
    
    // Start is called before the first frame update
    void Start()
    {
        if (textNameMonster)
        {
            textNameMonster.text = monsterName;
        }
        pvLeft = pvStat;
        if (primaryType != null)
        {
            var mesh = GetComponentInChildren<MeshRenderer>();
            mesh.material.SetColor("_TintColorA", primaryType.color);
            if (secondaryType != null)
            {
                mesh.material.SetColor("_TintColorB", secondaryType.color);
            }
            else
            {
                mesh.material.SetColor("_TintColorB", primaryType.color);
            }
            
        }
    }

    public void GetHit(Attack attackReceived, float damage)
    {
        Type attackingType = attackReceived.GetType();
        
        if (popupParent == null)
        {
            return;
        }
        var finalDamage = (damage - defenseStat) * (primaryType.multiplierEffectiveness(attackingType) *
                                    secondaryType.multiplierEffectiveness(attackingType));
        
        DamagePopupManager.Instance.DisplayPopup((int)finalDamage, popupParent);
        pvLeft -= finalDamage;
        pvLeft = Mathf.Clamp(pvLeft, 0, pvStat);
        UpdateWorldSpaceUI();
        CheckDeath();
    }

    public void Attack(Attack attackUsed)
    {
        if (CompareTag("Monster"))
        {
            return;
        }
        attackUsed.UseAttack(attackLauncher,attackStat + attackUsed.GetDamageAmount());
        /*
        var monster = GameObject.FindGameObjectWithTag("Monster");
        if (monster)
            monster.GetComponent<MonsterBehaviour>().GetHit(attackUsed, attackStat + attackUsed.GetDamageAmount());*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && firstAttack != null)
        {
            Attack(firstAttack);
        }

        if (Input.GetMouseButtonDown(1) && secondAttack != null)
        {
            Attack(secondAttack);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && thirdAttack != null)
        {
            Attack(thirdAttack);
        }
    }

    void UpdateWorldSpaceUI()
    {
        hpBar.rectTransform.sizeDelta = new Vector2((pvLeft / pvStat) * 2f, 0.5f);
    }

    void CheckDeath()
    {
        if (pvLeft <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
