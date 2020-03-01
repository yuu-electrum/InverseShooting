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
            taskManager.AddTask(0, taskManager.gameObject.AddComponent<Opening>() as BasicBulletTask);
            taskManager.AddTask(1000, taskManager.gameObject.AddComponent<Ceil>() as BasicBulletTask);
            taskManager.AddTask(2000, taskManager.gameObject.AddComponent<SurroundAndRelease>() as BasicBulletTask);
        }

        public void Update()
        {

        }
    }
}