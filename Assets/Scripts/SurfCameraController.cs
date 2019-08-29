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

    private void LateUpdate()
    {
        transform.position = new Vector3(RainbowSurfer.transform.position.x + OffsetX.x, transform.position.y, transform.position.z);
    }
}
