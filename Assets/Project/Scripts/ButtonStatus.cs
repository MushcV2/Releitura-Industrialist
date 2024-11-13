using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatus : PanelController
{
    [SerializeField] private string objectName;
    [SerializeField] private int objectPrice;
    [SerializeField] private GameObject placeabledObject;
    [SerializeField] private Sprite objectImage;
    [SerializeField] private Button objectButton;
    [SerializeField] private Button placeObjectButton;
    private GameObject objectToPlace;
    private bool haveObject;

    private void Awake()
    {
        objectButton = GetComponent<Button>();
    }

    protected override void Start()
    {
        objectButton.onClick.AddListener(ChangeStatusMenu);
        placeObjectButton.onClick.AddListener(PlaceObject);

        haveObject = false;
    }

    private void Update()
    {
        if (haveObject)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                haveObject = false;
                objectToPlace = null;
            }
        }
    }

    private void ChangeStatusMenu()
    {
        statusMenu.SetActive(true);

        Sprite _sprite = statusMenu.transform.Find("ObjectImage").GetComponent<Image>().sprite;
        if (objectImage != null) _sprite = objectImage;

        TMP_Text _price = statusMenu.transform.Find("Price").GetComponent<TextMeshProUGUI>();
        _price.text = "$" + objectPrice.ToString();

        TMP_Text _name = statusMenu.transform.Find("ObjectName").GetComponent<TextMeshProUGUI>();
        _name.text = objectName;
    }

    private void PlaceObject()
    {
        CloseObjectMenu();

        haveObject = true;
        objectToPlace = Instantiate(placeabledObject, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}