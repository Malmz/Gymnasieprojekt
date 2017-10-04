using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Gymnaieprojekt.Collision
{
    interface ICollisionWorld
    {
        List<Rectangle> BoundingBoxes();
    }
}
