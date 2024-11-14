using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlacingSystem : MonoBehaviour
{
    [SerializeField] private LayerMask placementCollideMask;
    [SerializeField] private LayerMask placementCollideCheck;
    private GameObject currentTower;

    private void Update()
    {
        if (currentTower != null)
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit _hit;

            if (Physics.Raycast(_ray, out _hit, 100f, placementCollideMask))
            {
                currentTower.transform.position = new Vector3(_hit.point.x, _hit.point.y + 0.5f, _hit.point.z);

                if (Input.GetKeyDown(KeyCode.R)) currentTower.transform.eulerAngles += new Vector3(0f, 90f, 0f);
            }

            if (Input.GetButtonDown("Fire1") && _hit.collider.gameObject != null)
            {
                if (_hit.collider.gameObject.CompareTag("CanPlace"))
                {
                    BoxCollider TowerCollider = currentTower.gameObject.GetComponent<BoxCollider>();
                    TowerCollider.isTrigger = true;

                    Vector3 BoxCenter = currentTower.gameObject.transform.position + TowerCollider.center;
                    Vector3 HalfExtents = TowerCollider.size / 2;
                    if (Physics.CheckBox(BoxCenter, HalfExtents, Quaternion.identity, placementCollideCheck, QueryTriggerInteraction.Ignore))
                    {
                        TowerCollider.isTrigger = true;
                    }
                    else
                    {
                        TowerCollider.isTrigger = false;
                        currentTower = null;
                    }
                }
            }
        }
    }

    public void SetTower(GameObject _tower)
    {
        currentTower = Instantiate(_tower, Vector3.zero, Quaternion.identity);
        currentTower.transform.eulerAngles = new Vector3(-90f, 0f ,0f);
    }
}