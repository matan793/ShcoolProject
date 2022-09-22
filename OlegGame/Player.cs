using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;

internal class Player
{
    private Image image; //מראה הדמות     
    private double PlaceX;//מיקום הדמות במישור האופקי
    private double PlaceY;//מיקום הדמות במישור האנכי
    private Canvas Arena;//זירת המשחק
    private StateType state;//מצב הדמות
    private double speedX;//מהירות אופקית
    private DispatcherTimer moveTimer;//הטיימר יאפשר התקדמות הדמות


    /// <summary>
    /// הפעולה בונה עצם מטיפוס שחקן במצבו נורמל 
    /// </summary>
    /// <param name="placeX"> מיקום אופקי </param>
    /// <param name="placeY"> מיקום אנכי </param>
    /// <param name="arena"> גבולות זירת המשחק </param>
    /// <param name="size"> גודל הדמות </param>
    public Player(double placeX, double placeY, Canvas arena, double size)
    {
        this.image = new Image();
        this.PlaceX = placeX;
        this.PlaceY = placeY;
        this.speedX = 0;
        this.state = StateType.IdleRight;


        this.Arena = arena;
        this.image.Height = size;
        this.image.Width = size;

        MatchGiftoState();

        Canvas.SetLeft(this.image, this.PlaceX);//קביעת מיקום אופקי
        Canvas.SetTop(this.image, this.PlaceY);//קביעת מיקום אנכי
        this.Arena.Children.Add(this.image);//שיוך הדמות לזירה
        this.moveTimer = new DispatcherTimer();
        this.moveTimer.Interval = TimeSpan.FromMilliseconds(1);
        this.moveTimer.Start();
        this.moveTimer.Tick += MoveTimer_Tick;
    }
    /// <summary>
    /// פעולה הנקראת כל מאית שנייה ובדקת האם השחקן נגעה בשולי המשחק וכו
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MoveTimer_Tick(object sender, object e)
    {
        if (this.PlaceX <= 0)//נגיעה בשול שמאל
        {
            this.speedX = 0;
            this.PlaceX += 7;
            Canvas.SetLeft(this.image, this.PlaceX);//קביעת מיקום אופקי
        }
        if (this.PlaceX + this.image.Width >= this.Arena.Width)//נגיעה בשול ימין
        {

            this.speedX = 0;
            this.PlaceX += 7;
            Canvas.SetLeft(this.image, this.PlaceX);//קביעת מיקום אופקי

        }
        this.PlaceX += this.speedX;
        Canvas.SetLeft(this.image, this.PlaceX);//קביעת מיקום אופקי

    }
    /// <summary>
    /// פעולה המתאימה את קבצי הגיף לתנועת השחקן     
    /// </summary>
    private void MatchGiftoState()
    {
        switch (this.state)
        {
            case StateType.IdleRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/IdleRight.gif")); break;
            case StateType.IdleLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/IdleLeft.gif")); break;
            case StateType.RunRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/RunRight.gif")); break;
            case StateType.RunLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/RunLeft.gif")); break;
            case StateType.DeadRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/DeadRight.gif")); break;
            case StateType.DeadLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/DeadLeft.gif")); break;
            case StateType.JumpRight: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/JumpRight.gif")); break;
            case StateType.JumpLeft: this.image.Source = new BitmapImage(new Uri("ms-appx:///Assets/character/JumpLeft.gif")); break;
        }
    }
    /// <summary>
    /// פעולה המאפשרת לשחקן לזוז ימינה 
    /// </summary>
    public void MoveRight()
    {
        if (this.state != StateType.RunRight)
        {
            this.speedX = 7;
            this.state = StateType.RunRight;
            MatchGiftoState();
        }
    }
    /// <summary>
    /// פעולה המאפשרת לשחקן לזוז שמאלה 
    /// </summary>
    public void MoveLeft()
    {
        if (this.state != StateType.RunLeft)
        {
            this.speedX = -7;
            this.state = StateType.RunLeft;
            MatchGiftoState();
        }
    }
    /// <summary>
    /// פעולה המפסיקה את השחקן מעת תנעותו 
    /// </summary>
    public void Stop()
    {
        if (this.state == StateType.RunLeft)
            this.state = StateType.IdleLeft;
        else
            if (this.state == StateType.RunRight)
            this.state = StateType.IdleRight;
        this.speedX = 0;
        MatchGiftoState();
    }
}
/// <summary>
/// מצבי השחקן בעת תנועותו
/// </summary>
public enum StateType
{
    IdleLeft,
    IdleRight,
    DeadRight,
    DeadLeft,
    RunLeft,
    RunRight,
    JumpLeft,
    JumpRight
}
