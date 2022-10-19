using App1.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed class Mirav : FrameworkElement
    {

    }
    public sealed partial class GamePage : Page
    {
        private Manager myManager;
        private CharacterType characterType;
        public GamePage()
        {
            this.InitializeComponent();
            
        }

        /// <summary>
        /// הפעולה מקבלת את המידע כאשר הדף הנוכחי יפתח
        /// </summary>
        /// <param name="e">מכיל מידע שהועבר</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //קיבלנו את סוג הדמות שבחר המשתמש
            this.characterType = (CharacterType)e.Parameter;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.myManager = new Manager(canvas, this.characterType);
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

        }

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            this.myManager.StopCharacter();
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            this.myManager.MoveCharacter(args.VirtualKey);
        }
    }
}
