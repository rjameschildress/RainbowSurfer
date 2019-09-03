using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfCameraController : MonoBehaviour
{
    public GameObject RainbowSurfer;
    private Vector3 OffsetX;

    private void Start()
    {
        OffsetX = new Vector3(transform.position.x - RainbowSurfer.transform.position.x, 0, -1);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(RainbowSurfer.transform.position.x + OffsetX.x, RainbowSurfer.transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        Vector3 currPosition = transform.position;
        currPosition.y = Mathf.Clamp(currPosition.y, -6f, 6f);
        transform.position = currPosition;
    }
}
