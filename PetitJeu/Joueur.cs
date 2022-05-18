using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using IUTGame;
namespace PetitJeu
{
    class Joueur : GameItem, IAnimable, IKeyboardInteract
    {        
        private bool compte = false;
        private double time = 0;
        private ObjScore objScore;
        

        public double Time
        {
            get { return time; }
            set { time = value; }
        }

        public Joueur(double x, double y, Canvas c, Game g)
            :base(x,y,c,g,"joueur.png")
        {
            objScore = new ObjScore(0, 10, 10, c, g);
            Game.AddItem(objScore);
        }
        public override string TypeName => "joueur";

        public void Animate(TimeSpan dt)
        {
            if(compte)
            {
                time += dt.TotalMilliseconds;
                if (time > 500)
                    compte = false;
            }
        }

        public override void CollideEffect(GameItem other)
        {
            if(!compte)
            {
                objScore.Score++;
                if (objScore.Score >= 10)
                    Game.Win();
                compte = true;
                time = 0;
                PlaySound("blop.mp3");
            }
            

        }

        public void KeyDown(Key key)
        {
            switch(key)
            {
                case Key.Left:
                    MoveXY(-37, 0);break;
                case Key.Right:
                    MoveXY(37, 0);break;
            }
        }

       

        public void KeyUp(Key key)
        {
            
        }
    }
}
