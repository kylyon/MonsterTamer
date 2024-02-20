using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager Instance;

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

    public CinemachineVirtualCamera virtualCamera;
}
