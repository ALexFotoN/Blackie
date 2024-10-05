using UnityEngine;

namespace Interfaces
{
    public interface IControllable
    {
        public void Move(Rigidbody2D rb, float speed, Vector2 direction);
    }
}