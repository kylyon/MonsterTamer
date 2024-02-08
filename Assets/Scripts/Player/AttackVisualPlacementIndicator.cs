using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVisualPlacementIndicator : MonoBehaviour
{
    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 9;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;
        
        int lm = LayerMask.GetMask(new string[]{"Terrain", "Monster"});

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out hit, Mathf.Infinity,
                lm))
        {
            Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward * hit.distance,
                Color.yellow);
            Debug.Log("Did Hit");
            Debug.Log(hit.collider.name);
        }
        else
        {
            Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}