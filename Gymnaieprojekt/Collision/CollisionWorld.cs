using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Gymnaieprojekt.Collision
{
    class CollisionWorld
    {
        private List<ICollisionWorld> worlds;
        private List<ICollisionObject> objects;

        public CollisionWorld() { }

        public void AddWorld(ICollisionWorld world)
        {
            worlds.Add(world);
        }

        public void AddObject(ICollisionObject collisionObject)
        {
            objects.Add(collisionObject);
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
