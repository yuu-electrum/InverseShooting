using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Game.Bullet
{
    /// <summary>
    /// タスクの管理者
    /// </summary>
    public class TaskManager : MonoBehaviour
    {
        [SerializeField]
        private BulletFactory bulletFactory;

        private Dictionary<int, List<BasicBulletTask>> taskSchedules = null;

        public void Start()
        {
            taskSchedules = new Dictionary<int, List<BasicBulletTask>>();
        }

        public void Update()
        {
            var completedSchedules = taskSchedules.Where(ts => ts.Value.Count == 0);
            foreach(var cs in completedSchedules)
            {
                // そのフレームに開始したタスクがすべて完了していたら削除する
                taskSchedules.Remove(cs.Key);
            }

            foreach(var ts in taskSchedules)
            {
                // 完了したタスクはリストから削除する
                ts.Value.RemoveAll(t => t.ShouldTerminate);

                // 残っているタスクを実行する
                ts.Value.ForEach(t => t.Continue());
            }
        }
    }
}

