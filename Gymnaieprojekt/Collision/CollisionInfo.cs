using Microsoft.Xna.Framework;

namespace Gymnaieprojekt.Collision
{
    public class CollisionInfo
    {
        public int TileId { get; set; }
        public Rectangle BoundingBox { get; set; }

        public CollisionInfo(int id, Rectangle boundingBox)
        {
            TileId = id;
            BoundingBox = boundingBox;
        }
    }
}
