using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject towerPrefab1;
    [SerializeField] private GameObject[] towerSlots; 
    void Start()
    {
        
    }

    private void PlaceTower(int towerSlotIndex)
    {
     GameObject newTower=   Instantiate(towerPrefab1);
        newTower. transform.position= towerSlots[towerSlotIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            if (hit.collider != null)
            {
                int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.gameObject);
                if (towerSlotIndex != -1)
                {
                    PlaceTower(towerSlotIndex);
                }
            }

        }
    }
}
