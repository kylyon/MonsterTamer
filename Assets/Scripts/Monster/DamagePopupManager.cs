using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopupManager : MonoBehaviour
{
    public static DamagePopupManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] private GameObject popupPrefab;

    public void DisplayPopup(int damage, Transform popupParent)
    {
        GameObject go = Instantiate(popupPrefab, popupParent.transform.position, Quaternion.identity, popupParent);
        go.GetComponent<DamagePopup>().SetUp(damage);
    }
}
