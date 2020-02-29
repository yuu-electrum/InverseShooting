using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

[RequireComponent(typeof(Camera))]
public class CameraControl : MonoBehaviour
{
    private Camera cam;

    public void Start()
    {
        cam = this.GetComponent<Camera>();
    }

    /// <summary>
    /// その座標がカメラの描写範囲内か
    /// </summary>
    /// <param name="target">判別対象となる座標</param>
    public bool IsInCamera(Vector3 target)
    {
        var viewportPosition = cam.WorldToViewportPoint(target);
        return viewportPosition.x > Configurations.STAGE_BOUNDARY_LEFT
            && viewportPosition.x < Configurations.STAGE_BOUNDARY_RIGHT
            && viewportPosition.y > Configurations.STAGE_BOUNDARY_TOP
            && viewportPosition.y < Configurations.STAGE_BOUNDARY_BOTTOM;
    }
}