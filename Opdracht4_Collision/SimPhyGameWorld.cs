#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Opdracht4_Collision
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SimPhyGameWorld : GameEnvironment
    {
        public SimPhyGameWorld()
            : base()
        {
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();

            screen = new Point(1280, 800);
            this.SetFullScreen(false);
            gameStateManager.AddGameState("playingState", new PlayingState());

            gameStateManager.SwitchTo("playingState");
            IsMouseVisible = true;
        }
    }
}
