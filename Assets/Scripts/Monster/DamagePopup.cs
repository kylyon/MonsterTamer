using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;
    private Transform attackerTransform;

    [SerializeField]
    private float dissapearTime = 0.5f;
    [SerializeField]
    private float fadeOutSpeed = 5f;
    [SerializeField]
    private float moveYSpeed = 1f;

    public void SetUp(int damage)
    {
        textMesh = GetComponent<TextMeshPro>();
        attackerTransform = Camera.main.transform;
        textColor = textMesh.color;
        textMesh.SetText(damage.ToString());
    }

    private void LateUpdate()
    {
        transform.LookAt(2 * transform.position - attackerTransform.position);

        transform.position += new Vector3(0f, moveYSpeed * Time.deltaTime, 0f);

        dissapearTime -= Time.deltaTime;
        if (dissapearTime <= 0f)
        {
            textColor.a -= fadeOutSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
