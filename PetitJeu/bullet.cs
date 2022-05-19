using IUTGame;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace PetitJeu
{
    class bullet : GameItem, IAnimable
    {

        private double vitesse = 600;
        private double angle = 90;
        private static int nombre = 0;

        public bullet(double x, double y, Canvas c, Game g)
            : base(x, y, c, g, "bulletvf.png")
        {
            ++nombre;
        }

        public override string TypeName => "bullet";

        public void Animate(TimeSpan dt)
        {
            if (this.Top < 0)
            {
                Top = 0;
                angle = 360 - angle;
                
            }
            else if (Bottom > GameHeight)
            {
                Game.RemoveItem(this);
                --nombre;
                if (nombre == 0)
                    Game.Loose();
            }
            else if (Left < 0)
            {
                angle = (360 + 180 - angle) % 360;
                Left = 0;
                
            }
            else if (Right > GameWidth)
            {
                angle = (360 + 180 - angle) % 360;
                Right = GameWidth;
                
            }
            MoveDA(vitesse * dt.TotalSeconds, angle);
        }

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "1")
            {
                angle = 360 - angle;
            }
            else if (other.TypeName == this.TypeName)
            {
                angle = (angle + 180) % 360;
            }
            Game.RemoveItem(this);
        }

        /*public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Space:
                     
                    break;              
            }          
        }*/


    }
}
