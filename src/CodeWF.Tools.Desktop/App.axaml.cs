using Avalonia.Logging;
using System.Net.Mime;

namespace CodeWF.Tools.Desktop;

public class App : PrismApplication
{
    private INotificationService? _notificationService;

    public App()
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        _notificationService?.Show($"异常", "");
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        base.Initialize(); // <-- Required
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
        string modulePath = $"{AppDomain.CurrentDomain.BaseDirectory}Modules";
        if (!Directory.Exists(modulePath))
        {
            throw new Exception($"请生成模块到目录{modulePath}");
        }

        return new DirectoryModuleCatalog { ModulePath = modulePath };
    }

    protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
    {
        base.ConfigureRegionAdapterMappings(regionAdapterMappings);

        regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(Grid), Container.Resolve<GridRegionAdapter>());
        regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<TabControlAdapter>());
    }

    protected override AvaloniaObject CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        IContainer? container = containerRegistry.GetContainer();
        // Views - Generic
        containerRegistry.Register<MainWindow>();

        IRegionManager? regionManager = Container.Resolve<IRegionManager>();
        regionManager.RegisterViewWithRegion<DashboardView>(RegionNames.ContentRegion);
        regionManager.RegisterViewWithRegion<FooterView>(RegionNames.FooterRegion);

        containerRegistry.RegisterSingleton(typeof(FooterViewModel));
        containerRegistry.RegisterSingleton(typeof(DashboardViewModel));

        containerRegistry.RegisterSingleton<INotificationService, NotificationService>();
        containerRegistry.RegisterSingleton<IClipboardService, ClipboardService>();
        containerRegistry.RegisterSingleton<IToolManagerService, ToolManagerService>();
        containerRegistry.RegisterSingleton<IFileChooserService, FileChooserService>();

        IToolManagerService? toolManagerService = container.Resolve<IToolManagerService>();
        toolManagerService.AddTool("首页",
            "这是一个基于Avalonia UI + Prism框架打造的模块化跨平台工具平台，汇聚了众多开发实用小工具，目前已开发或即将开发的如编码解码、数据加密等，轻量且强大，开箱即用，助力开发者提升工作效率。",
            nameof(DashboardView),
            IconHelper.Home,
            ToolStatus.Complete);
        _notificationService = container.Resolve<INotificationService>();
    }

    /// <summary>
    ///     1、DryIoc.Microsoft.DependencyInjection低版本可不要这个方法（5.1.0及以下）
    ///     2、高版本必须，否则会抛出异常：System.MissingMethodException:“Method not found: 'DryIoc.Rules
    ///     DryIoc.Rules.WithoutFastExpressionCompiler()'.”
    ///     参考issues：https://github.com/dadhi/DryIoc/issues/529
    /// </summary>
    /// <returns></returns>
    protected override Rules CreateContainerRules()
    {
        return Rules.Default.WithConcreteTypeDynamicRegistrations(reuse: Reuse.Transient)
            .With(Made.Of(FactoryMethod.ConstructorWithResolvableArguments))
            .WithFuncAndLazyWithoutRegistration()
            .WithTrackingDisposableTransients()
            //.WithoutFastExpressionCompiler()
            .WithFactorySelector(Rules.SelectLastRegisteredFactory());
    }
}