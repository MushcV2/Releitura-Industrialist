using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private int maxZoom;
    [SerializeField] private int minZoom;
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
        MoveCamera();

        if (Input.mouseScrollDelta.y > 0 && transform.position.y >= minZoom) transform.position -= new Vector3(0f, 1f, 0f);
        else if (Input.mouseScrollDelta.y < 0 && transform.position.y <= maxZoom) transform.position += new Vector3(0f, 1f, 0f);
    }

    private void MoveCamera()
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