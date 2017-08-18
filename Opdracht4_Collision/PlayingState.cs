using Microsoft.Xna.Framework;
using System;

namespace Opdracht4_Collision
{
    class PlayingState : GameObjectList
    {
		GameObjectList balls;

        public PlayingState()
            : base()
        {
			SpriteGameObject background = new SpriteGameObject("calligraphy");
            this.Add(background);
			balls = new GameObjectList(0, "balls");

			Random random = new Random();
			for (int i = 0; i < 20; i++)
			{
				int randomsprite = random.Next(1, 4);
				string assetName = "spr_ball_green";
				if (randomsprite == 1)
					assetName = "spr_ball_green";
				if (randomsprite == 2)
					assetName = "spr_ball_blue";
				if (randomsprite == 3)
					assetName = "spr_ball_red";

				balls.Add(new Ball(assetName, new Vector2(random.Next(100, 700), random.Next(100, 500)),
											new Vector2(((float)random.NextDouble()-0.5f)*10,
											((float)random.NextDouble()-0.5f)*10),
											15f, 0.1f, Vector2.Zero, 0.85f));
			}
			this.Add(balls);
        }

		protected void HandleCollisions()
		{
			for (int i = 0; i < balls.Objects.Count; i++)
			{
				Ball ball1 = balls.Objects[i] as Ball;
				for (int j = i + 1; j < balls.Objects.Count; j++)
				{
					Ball ball2 = balls.Objects[j] as Ball;
					ball1.ResolveCollisionWith(ball2);
				}
			}
		}

		public override void Update(GameTime gameTime)
        {
			HandleCollisions();
            base.Update(gameTime);
        }
    }
}