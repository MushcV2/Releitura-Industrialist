using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletTowers : MonoBehaviour
{
    [SerializeField] private LayerMask towerLayer;
    [SerializeField] private Button deletButton;
    private bool canDelet;

    private void Start()
    {
        deletButton.onClick.AddListener(CanDelet);       
    }

    private void Update()
    {
        if (canDelet) DeletTower();
    }

    private void CanDelet()
    {
        canDelet = !canDelet;
    }

    private void DeletTower()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit _hit, 100f, towerLayer))
        {
            if (Input.GetButtonDown("Fire1")) Destroy(_hit.collider.gameObject);
        }
    }
}