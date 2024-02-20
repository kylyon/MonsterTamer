using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] private GameObject teamHolder;
    [SerializeField] private GameObject[] monstersSlot;
    [SerializeField] private Color selectedSlotColor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeSlot(int teamSize)
    {
        for (int i = teamSize; i < 5; i++)
        {
            var slot = monstersSlot[i];
            slot.GetComponentsInChildren<Transform>()[0].gameObject.SetActive(false);
            slot.GetComponentsInChildren<Transform>()[1].gameObject.SetActive(false);
        }
    }

    public void ChangeCurrentSlot(int index)
    {
        foreach (var slot in monstersSlot)
        {
            var img = slot.GetComponentsInChildren<Image>();
            if (img.Length > 1)
            {
                img[1].color = Color.white;
            }
        }
        
        monstersSlot[index].GetComponentsInChildren<Image>()[1].color = selectedSlotColor;
    }
}
