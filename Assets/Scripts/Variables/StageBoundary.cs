using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Variables
{
    /// <summary>
	/// ユーザ座標を表すクラス
	/// </summary>
    public class StageBoundary : MonoBehaviour, IGameVariable<Rect>
    {
        [SerializeField]
        CameraControl cam;

        [SerializeField]
        Game.Variables.Variables variables;

        private Rect variable;

        public void Start()
        {
            var distance = cam.Camera.nearClipPlane;

            var left   = cam.Camera.ViewportToWorldPoint(new Vector3(Configurations.STAGE_BOUNDARY_LEFT , 0.0f, distance)).x;
            var right  = cam.Camera.ViewportToWorldPoint(new Vector3(Configurations.STAGE_BOUNDARY_RIGHT, 0.0f, distance)).x;
            var top    = cam.Camera.ViewportToWorldPoint(new Vector3(0.0f, Configurations.STAGE_BOUNDARY_TOP, distance)).y;
            var bottom = cam.Camera.ViewportToWorldPoint(new Vector3(0.0f, Configurations.STAGE_BOUNDARY_BOTTOM, distance)).y;

            variable = new Rect(right, bottom, Mathf.Abs(left - right), Mathf.Abs(top - bottom));
        }

        public Rect Get()
        {
            return variable;
        }

        /// <summary>
        /// その座標がステージ境界内か
        /// </summary>
        /// <param name="position">比較対象の座標</param>
        public bool IsInBoundary(Vector3 position)
        {
            return cam.IsInCamera(position);
        }
    }
}