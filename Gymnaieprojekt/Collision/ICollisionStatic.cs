using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Gymnaieprojekt.Collision
{
    interface ICollisionStatic
    {
        Dictionary<Rectangle, int> Tiles { get; }
    }
}
