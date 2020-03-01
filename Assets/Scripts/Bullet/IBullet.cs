using UnityEngine;

namespace Game.Bullet
{
    /// <summary>
    /// 弾のインターフェース
    /// </summary>
    public interface IBullet
    {
        Vector3 Position { get; set; }
        float Radius { get; set; }
        float Speed { get; set; }

        void Initialize(float x, float y, float radius, float speed);
        void Destroy();
    }
}