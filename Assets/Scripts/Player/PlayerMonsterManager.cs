using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMonsterManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monstersInTeam;
    [SerializeField] private GameObject ballPrefab;

    private int indexMonster = 0;

    private int indexMonsterOut = -1;

    private GameObject monsterSpawned = null;

    private PlayerUIManager ui;

    private float delayScroll = 0.1f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<PlayerUIManager>();
        ui.InitializeSlot(monstersInTeam.Length);
        ui.ChangeCurrentSlot(indexMonster);
    }


    private void GetMonsterOut()
    {
        //Instantiate monster in the scene
        monsterSpawned = Instantiate(monstersInTeam[indexMonster], transform.position + Vector3.forward * 2, Quaternion.identity);
        indexMonsterOut = indexMonster;
        
        //Change the follow target of the camera
        WorldManager.Instance.virtualCamera.Follow = monsterSpawned.GetComponent<MonsterInfoElements>().followTarget;
        
        //Enable controls on the monster
        monsterSpawned.GetComponent<PlayerMovement>().enabled = true;
        monsterSpawned.GetComponent<PlayerRotation>().enabled = true;
        monsterSpawned.GetComponent<CharacterController>().enabled = true;
        monsterSpawned.GetComponent<MonsterBehaviour>().GetOwnership(GetComponent<PlayerInfo>());
        monsterSpawned.tag = "Player";
        foreach (Transform t in monsterSpawned.transform)
        {
            t.tag = "Player";
        }
        
        //Disable controls on the player
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerRotation>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
    }

    private void GetMonsterIn()
    {
        WorldManager.Instance.virtualCamera.Follow = GetComponent<PlayerInfo>().followTarget;
                
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerRotation>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        Destroy(monsterSpawned);
    }

    // Update is called once per frame
    void Update()
    {
        delayScroll -= Time.deltaTime;
        if (monstersInTeam.Length > 1 && Input.GetAxis("Mouse ScrollWheel") != 0 && delayScroll < 0f)
        {
            indexMonster -= (int)(Input.GetAxis("Mouse ScrollWheel") * 10);
            indexMonster += monstersInTeam.Length;
            indexMonster %= monstersInTeam.Length;
            ui.ChangeCurrentSlot(indexMonster);
            delayScroll = 0.1f;
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!monsterSpawned)
            {
                GetMonsterOut();
            }
            else if (monsterSpawned && indexMonster == indexMonsterOut)
            {
                GetMonsterIn();
            }
            else
            {
                GetMonsterIn();
                GetMonsterOut();
            }
        }
    }
}
