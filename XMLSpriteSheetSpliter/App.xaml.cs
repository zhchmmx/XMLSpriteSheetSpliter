using System.Windows;
using System.Windows.Threading;

namespace XMLSpriteSheetSpliter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        //UI线程未捕获异常处理事件
        this.DispatcherUnhandledException += App_DispatcherUnhandledException;
        //Task线程内未捕获异常处理事件
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        //非UI线程未捕获异常处理事件
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        
        MessageBox.Show((string)e.ExceptionObject, "An Error Occurred");
    }

    private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.Message, "An Error Occurred");
    }

    private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(e.Exception.Message, "An Error Occurred");
    }
}


