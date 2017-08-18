using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

namespace Opdracht4_Collision
{
    class Ball : SpriteGameObject
    {
        private float radius;
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        //variable for the acceleration
        private Vector2 acceleration;

        //variable for the gravity
        private float gravity;

        //variable for inelastic behaviour
        private float inelastic;

        public Ball(string assetName, Vector2 position, Vector2 velocity, float radius, float gravity, Vector2 acceleration, float inelastic)
            : base(assetName, 0, "ball")
        {
            this.position = position;
            this.velocity = velocity;
            origin = new Vector2(Width / 2, Height / 2);
            this.radius = radius;
            scale = radius * 2 / Width;
            this.gravity = gravity;
            this.acceleration = acceleration;
            this.inelastic = inelastic;
        }

        public override void Update(GameTime gameTime)
        {
            //Ball bouncing behaviour
            if (position.X < radius)
            {
                position.X = radius;
                velocity.X *= -1f;
            }
            if (position.X > GameEnvironment.Screen.X - radius)
            {
                position.X = GameEnvironment.Screen.X - radius;
                velocity.X *= -1f;
            }
            if (position.Y < radius)
            {
                position.Y = radius;
                velocity.Y *= -1f;
            }
            if (position.Y > GameEnvironment.Screen.Y - radius)
            {
                position.Y = GameEnvironment.Screen.Y - radius;
                velocity.Y *= -1f;

                //inelastic behaviour
                velocity.Y *= inelastic;
            }

            //acceleration behaviour
            velocity += acceleration;

            //gravity behaviour
            velocity.Y += gravity;

            base.Update(gameTime);
        }

        public void ResolveCollisionWith(Ball other)
        {
			//Step 1: calculate the vector from the position of this ball to the other ball
            Vector2 positionDifference = other.Position - this.position;
			//Step 2: calculate the distance between the two balls
            float distance = positionDifference.Length() - (other.Radius + this.radius);

			//Step 3: if there is a collision
			if (distance < 0)
			{

				//Step 4: calculate the collision normal
                Vector2 collisionNormal = (other.Position - this.position);
                collisionNormal.Normalize();
				//Step 5: Resolve interpenetration
                Vector2 resetVector = collisionNormal;
                resetVector *= distance;
                this.position += resetVector / 2;
                other.Position -= resetVector / 2;
				//Step 6: calculate the velocity component parallel to normal
                Vector2 velocityDifference = this.velocity - other.Velocity;
                float componentFactor = Vector2.Dot(this.velocity, collisionNormal);
				//Step 7: calculate the changeVelocity
                Vector2 changeVelocity = 2 * componentFactor * collisionNormal;
				//Step 8: change the velocities (assume equal mass)
                this.velocity = this.velocity - changeVelocity / 2;
                other.velocity = other.velocity + changeVelocity / 2;
			}
        }
    }
}