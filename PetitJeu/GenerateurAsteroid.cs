using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using IUTGame;
namespace PetitJeu
{
    public class GenerateurAsteroid : GameItem, IAnimable
    {
        private TimeSpan timeToCreate;
        private Canvas canvas;
        private Joueur t;
        public GenerateurAsteroid(Game g, Canvas c): base(0,0,c,g)
        {
            this.canvas = c;
            timeToCreate = new TimeSpan(0, 0, 2);
        }
        public override string TypeName => "generateur";

        public void Animate(TimeSpan dt)
        {
            timeToCreate = timeToCreate - dt;
            if (timeToCreate.TotalMilliseconds < 0)
            {
                Random r = new Random();
                double x = r.NextDouble() * GameWidth;
                double y = 0 * GameHeight/2;

                Balle b = new Balle(x, y, canvas, Game);
                Game.AddItem(b);
                double ms = r.NextDouble() * 5000 + 1000;
                timeToCreate = new TimeSpan(0, 0, 0, 2, 0);
            }
        }

        public override void CollideEffect(GameItem other)
        {
            
        }
    }
}
