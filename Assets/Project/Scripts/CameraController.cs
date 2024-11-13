using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody rb;
    private Camera cam;
    private Vector3 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) mousePos = Input.mousePosition;
        else if (Input.GetMouseButton(0))
        {
            Vector3 _deltaMouse = Input.mousePosition - mousePos;
            Vector3 _move = new Vector3(-_deltaMouse.x, 0, -_deltaMouse.y) * speed * Time.deltaTime;

            transform.Translate(_move, Space.World);
            mousePos = Input.mousePosition;
        }
    }
}