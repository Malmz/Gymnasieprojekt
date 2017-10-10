using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Gymnaieprojekt.Collision
{
    interface ICollisionStatic
    {
        List<Rectangle> BoundingBoxes();
    }
}
