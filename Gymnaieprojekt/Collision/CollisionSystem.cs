using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Gymnaieprojekt.Collision
{
    class CollisionSystem
    {
        private List<ICollisionStatic> staticObjects;
        private List<ICollisionObject> dynamicObjects;

        public CollisionSystem()
        {
            staticObjects = new List<ICollisionStatic>();
            dynamicObjects = new List<ICollisionObject>();
        }

        public void AddWorld(ICollisionStatic world)
        {
            staticObjects.Add(world);
        }

        public void AddObject(ICollisionObject collisionObject)
        {
            dynamicObjects.Add(collisionObject);
        }

        public void Collide()
        {
            foreach (var world in staticObjects)
            {
                foreach (var item in world.BoundingBoxes())
                {
                    foreach (var dynamic in dynamicObjects)
                    {
                        if (dynamic.BoundingBox().Intersects(item))
                        {
                            dynamic.OnCollision(item);
                        }
                    }
                }
            }
        }
    }
}
