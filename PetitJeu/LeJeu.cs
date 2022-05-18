﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace PetitJeu
{
    class LeJeu : IUTGame.Game
    {
        public LeJeu(Canvas canvas):base(canvas,"Sprites","Sounds")
        {

        }
        protected override void InitItems()
        {
            double y = this.Canvas.ActualHeight - 90;
            double x = this.Canvas.ActualWidth / 2;
            Joueur j = new Joueur(x, y, Canvas, this);
            AddItem(j);
            AddItem(new GenerateurBalle(this,Canvas));
            //PlayBackgroundMusic("music.mp3");
        }

        protected override void RunWhenLoose()
        {
            System.Windows.MessageBox.Show(Res.Strings.Perdu);
        }

        protected override void RunWhenWin()
        {
            System.Windows.MessageBox.Show(Res.Strings.Gagne);
        }
    }
}
