using Foundation;
using UIKit;

namespace ExpandableTableView
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        private static void Main(string[] args)
        {
            UIApplication.Main(args, null, "AppDelegate");
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                RootViewController = new UINavigationController(new TableViewController())
            };

            Window.MakeKeyAndVisible();

            return true;
        }
    }
}
