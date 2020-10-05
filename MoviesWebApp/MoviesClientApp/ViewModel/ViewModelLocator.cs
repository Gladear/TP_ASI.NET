using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;

namespace MoviesClientApp.ViewModel
{
    class ViewModelLocator
    {
        /// <summary>
        /// This class contains static references to all the view models in the
        /// application and provides an entry point for the bindings.
        /// <para>
        /// See http://www.mvvmlight.net
        /// </para>
        /// </summary>
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<CompteViewModel>();
        }

        /// <summary>
        /// Get the Compte property.
        /// </summary>
        public CompteViewModel Compte => ServiceLocator.Current.GetInstance<CompteViewModel>();
    }
}
