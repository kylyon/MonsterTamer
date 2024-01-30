using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterBehaviour : MonoBehaviour
{
    public Type primaryType;
    public Type secondaryType;
    
    
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
