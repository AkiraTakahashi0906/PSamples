using PSamples.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PSamples.ViewModels;

namespace PSamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA>();//ナビゲーション表示
            containerRegistry.RegisterDialog<ViewB,ViewBViewModel>();
            containerRegistry.RegisterForNavigation<ViewC>();//ナビゲーション表示

            containerRegistry.RegisterSingleton<MainWindowViewModel>();//シングルトン　子画面からメイン画面にアクセス

        }
    }
}
