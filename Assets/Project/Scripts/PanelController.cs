using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [Header("Objects Menu")]
    [SerializeField] private Button objectsButton;
    [SerializeField] private Button closeObjectsButton;
    [SerializeField] protected GameObject objectsMenu;
    [SerializeField] protected GameObject statusMenu;

    protected virtual void Start()
    {
        objectsMenu.SetActive(false);
        statusMenu.SetActive(false);

        objectsButton.onClick.AddListener(()  => objectsMenu.SetActive(true));
        closeObjectsButton.onClick.AddListener(CloseObjectMenu);
    }

    public void CloseObjectMenu()
    {
        objectsMenu.SetActive(false);
        statusMenu.SetActive(false);
    }
}