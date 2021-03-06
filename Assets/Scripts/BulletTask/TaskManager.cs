using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Variables;

namespace Game.Bullet
{
    /// <summary>
    /// タスクの管理者
    /// </summary>
    public class TaskManager : MonoBehaviour
    {
        [SerializeField]
        private BulletFactory bulletFactory = null;

        [SerializeField]
        private Game.Variables.Variables variables = null;

        private Dictionary<int, int> taskIndexes;
        private Dictionary<int, BasicBulletTask> allTasks;
        private List<BasicBulletTask> tasks;

        private int currentFrame = 0;
        private int terminatedScene = 0;

        public void Start()
        {
            taskIndexes = new Dictionary<int, int>();
            allTasks = new Dictionary<int, BasicBulletTask>();
            tasks = new List<BasicBulletTask>();
        }

        public void Update()
        {
            if(allTasks.Count == terminatedScene)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Clear");
            }

            var activatedTaskIndexes = taskIndexes.Where(i => i.Value == currentFrame);
            foreach(var taskIndex in activatedTaskIndexes)
            {
                allTasks[taskIndex.Key].enabled = true;
                tasks.Add(allTasks[taskIndex.Key]);
            }
            tasks.ForEach(t => t.Continue());

            for(var i = tasks.Count - 1; i >= 0; i--)
            {
                if(tasks[i].ShouldTerminate)
                {
                    tasks[i].Terminate();
                    Destroy(tasks[i]);
                    tasks.RemoveAt(i);
                    terminatedScene++;
                }
            }

            currentFrame++;
        }

        /// <summary>
        /// タスクを追加する
        /// </summary>
        /// <param name="startFrame">タスク開始フレーム</param>
        /// <param name="task">タスク</param>
        public void AddTask(int startFrame, BasicBulletTask task)
        {
            // タスクを初期化しておく
            task.Initialize(bulletFactory, variables);
            task.enabled = false;

            var id = allTasks.Count;
            taskIndexes.Add(id, startFrame);
            allTasks.Add(id, task);
        }
    }
}

