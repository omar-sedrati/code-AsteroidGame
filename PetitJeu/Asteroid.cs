using IUTGame;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PetitJeu
{
    class Balle : GameItem, IAnimable
    {
        private double vitesse = 600;
        private double angle = 90;
        private static int nombre = 0;        

        public Balle(double x, double y, Canvas c, Game g) :
            base(x, y, c,g,"balle.png")
        {
            ++nombre;
        }

        private void Rebondir()
        {            
            vitesse += 10;
        }
        public override string TypeName => "balle";

        public override void CollideEffect(GameItem other)
        {
            if (other.TypeName == "joueur")
            {
                angle = 360 - angle;
            }
            else if (other.TypeName == this.TypeName)
            {
                angle = (angle + 180) % 360;
            }
            Game.RemoveItem(this);
        }

        public void Animate(TimeSpan dt)
        {
            if (this.Top < 0)
            {
                Top = 0;
                angle = 360 - angle;
                Rebondir();
            }                
            else if(Bottom>GameHeight)
            {
                Game.RemoveItem(this);
                --nombre;
                if (nombre == 0)
                    Game.Loose();
            }
            else if(Left<0)
            {
                angle = (360 + 180 - angle) % 360;
                Left = 0;
                Rebondir();
            }
            else if(Right>GameWidth)
            {
                angle = (360 + 180 - angle) % 360;
                Right = GameWidth;
                Rebondir();
            }
            MoveDA(vitesse * dt.TotalSeconds, angle);
        }
    }
}
