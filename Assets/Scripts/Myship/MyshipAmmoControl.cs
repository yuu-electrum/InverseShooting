using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Game
{
    /// <summary>
    /// 自機攻撃
    /// </summary>
    public class MyshipAmmoControl : MonoBehaviour
    {
        [SerializeField]
        private InversibleAreaControl inversibleAreaControl = null;

        void Start()
        {

        }

        void Update()
        {
            var keyboard = Keyboard.current;

            if(keyboard.zKey.isPressed)
            {
                inversibleAreaControl.EnableArea();
            }
            else
            {
                inversibleAreaControl.DisableArea();
            }
        }
    }
}