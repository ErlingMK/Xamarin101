# Example app
 
Changed container structure so its possible to inject other classes into platform services. 

Each platform creates the container and injects it into `App(IServiceContainer container)`.

        // iOS
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            var application = new App(CreateContainer());

            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }


        // Shared
        public App(IServiceContainer serviceContainer)
        {
            ServiceContainer = serviceContainer;

            InitializeComponent();
            var navigationPage = ServiceContainer.GetInstance<NavigationPage>();
            ServiceContainer.GetInstance<INavigationService>().Navigation = navigationPage.Navigation;
            MainPage = navigationPage;
        }

The platform services are set in `PlatformCompositionRoot` in the platform projects and the shared services are set in`SharedCompositionRoot` in the shared project. 

Also added a `INavigationService` as an example. 

`Task PushPage<TPage, T>(Action<T> beforeNavigation = null) where TPage : Page;`, where TPage is a `Page` registered in the container and T is assumed to be its `BindingContext`. 

Can set `BindingContext` when registering a page.

        serviceRegistry.Register(factory => new AnotherPage
        {
            BindingContext = factory.GetInstance<IAnotherPageViewModel>()
        });