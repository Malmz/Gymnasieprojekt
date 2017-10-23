using Microsoft.Xna.Framework;

namespace Gymnaieprojekt.Collision
{
    public interface ICollisionObject
    {
        Rectangle BoundingBox();
        void OnCollision(CollisionInfo info);
    }
}
