﻿using Microsoft.Xna.Framework;

namespace Gymnaieprojekt.Collision
{
    interface ICollisionObject
    {
        Rectangle BoundingBox();
        void OnCollision(CollisionInfo info);
    }
}
