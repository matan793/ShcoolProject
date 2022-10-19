using App1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace App1
{
    internal class Manager
    {
        private Spaceship1 spaceship1;
        private Spaceship1 spaceship2;
        private CharacterType characterType;
        public Manager(Canvas Arena, CharacterType characterType)
        {
            this.characterType = characterType;
            if (this.characterType == CharacterType.Spaceship1)
                this.spaceship1 = new Spaceship1(50, 585, Arena, 100);
            else
                this.spaceship1 = new Spaceship1(50, 885, Arena, 100);

        }
        internal void MoveCharacter(VirtualKey virtualKey)
        {
            switch(virtualKey)
            {
                case VirtualKey.Left:
                    if (this.spaceship1 != null)
                        this.spaceship1.GoLeft();
                    else
                        this.spaceship2.GoLeft(); break; 

                case VirtualKey.A: if(this.spaceship1 != null ) 
                        this.spaceship1.GoLeft(); 
                else
                        this.spaceship2.GoLeft(); break;
                    
                case VirtualKey.Right:
                    if (this.spaceship1 != null)
                        this.spaceship1.GoRight();
                    else
                        this.spaceship2.GoRight(); break;
                case VirtualKey.D:
                    if (this.spaceship1 != null)
                        this.spaceship1.GoRight();
                    else
                        this.spaceship2.GoRight(); break;

            }
        }

        internal void StopCharacter()
        {
            if(this.spaceship1 != null)
                this.spaceship1.Stop();
            else if(this.spaceship2 != null)
                this.spaceship2.Stop();
        }
    }
}
