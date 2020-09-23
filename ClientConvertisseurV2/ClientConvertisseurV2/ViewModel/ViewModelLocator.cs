using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;

namespace ClientConvertisseurV2.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReverseViewModel>();
        }
        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        /// <summary>
        /// Gets the Reverse property.
        /// </summary>
        public ReverseViewModel Reverse => ServiceLocator.Current.GetInstance<ReverseViewModel>();
    }
}