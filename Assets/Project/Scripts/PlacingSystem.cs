using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingSystem : MonoBehaviour
{
    private GameObject currentTower;

    private void Update()
    {
        if (currentTower != null)
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out RaycastHit _hit, 100f))
            {
                currentTower.transform.position = new Vector3(_hit.point.x, _hit.point.y + 0.5f, _hit.point.z);

                if (Input.GetKeyDown(KeyCode.R)) currentTower.transform.eulerAngles += new Vector3(0f, 90f, 0f);
            }

            if (Input.GetButtonDown("Fire1")) currentTower = null;
        }
    }

    public void SetTower(GameObject _tower)
    {
        currentTower = Instantiate(_tower, Vector3.zero, Quaternion.identity);
        currentTower.transform.eulerAngles = new Vector3(-90f, 0f ,0f);
    }
}