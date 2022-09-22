using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace OlegGame
{
    internal class Manager
    {
        private Player player;
        //private Player_Sword player_sword;
        public Manager(Canvas Arena)
        {
            this.player = new Player(50, 400, Arena, 100);
        }
        internal void GoCharacter(VirtualKey virtualKey)
        {
            switch (virtualKey)
            {
                case VirtualKey.Left:
                case VirtualKey.A: this.player.MoveLeft(); break;
                case VirtualKey.Right:
                case VirtualKey.D: this.player.MoveRight(); break;
            }
        }
        internal void StopCharacter()
        {
            this.player.Stop();
        }
    }
}
