using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfController : MonoBehaviour
{
    public Camera SurfCamera;
    public Rigidbody2D Rigidbody;
    public float ConstantSpeed;
    public float SurfSpeed;
    private Vector3 ScreenBoundary;
    private float HalfSurferHeight;

    private void Start()
    {
        ScreenBoundary = SurfCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, SurfCamera.transform.position.z));
        HalfSurferHeight = transform.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2.0f;
    }

    private void FixedUpdate()
    {
        float userInput = Input.GetAxis("Vertical");
        Vector2 currPosition = transform.position;
        Vector2 movement = new Vector2(ConstantSpeed + currPosition.x, (SurfSpeed * userInput) + currPosition.y);
        transform.position = movement;
    }

    private void LateUpdate()
    {
        Vector3 currPosition = transform.position;
        currPosition.y = Mathf.Clamp(currPosition.y, -ScreenBoundary.y + HalfSurferHeight, ScreenBoundary.y - HalfSurferHeight);
        transform.position = currPosition;
    }
}
