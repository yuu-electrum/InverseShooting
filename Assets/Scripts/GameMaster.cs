using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Bullet;

namespace Game
{
    /// <summary>
    /// ゲーム全体の管理者
    /// </summary>
    public class GameMaster : MonoBehaviour
    {
        [SerializeField]
        private Bullet.TaskManager taskManager = null;

        public void Start()
        {
            taskManager.AddTask(0, taskManager.gameObject.AddComponent<Circle>() as BasicBulletTask);
        }

        public void Update()
        {

        }
    }
}