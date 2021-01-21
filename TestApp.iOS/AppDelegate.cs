using Foundation;
using LightInject;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace TestApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        private static ServiceContainer m_serviceContainer;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            var application = new App(CreateContainer());

            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }

        private static IServiceContainer CreateContainer()
        {
            m_serviceContainer = new ServiceContainer();
            m_serviceContainer.RegisterFrom<PlatformCompositionRoot>();
            m_serviceContainer.RegisterFrom<SharedCompositionRoot>();
            m_serviceContainer.Register<IServiceContainer>(factory => m_serviceContainer, new PerContainerLifetime()); // Register itself
            return m_serviceContainer;
        }
    }
}