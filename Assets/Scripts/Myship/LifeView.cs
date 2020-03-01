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
    [RequireComponent(typeof(TMPro.TextMeshPro))]
    public class LifeView : MonoBehaviour
    {
        [SerializeField]
        private GameMaster gameMaster;

        private TMPro.TextMeshPro textMeshPro;

        void Start()
        {
            textMeshPro = GetComponent<TMPro.TextMeshPro>();
        }

        void Update()
        {
            textMeshPro.text = gameMaster.Life.ToString();
        }
    }
}