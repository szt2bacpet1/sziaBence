using Flyhigh.Desktop.ViewModels;
using Flyhigh.Desktop.ViewModels.ControlPanel;
using Flyhigh.Desktop.ViewModels.Login;
using Flyhigh.Desktop.ViewModels.Felhasznalok;
using Flyhigh.Desktop.ViewModels.Legijaratok;
using Flyhigh.Desktop.ViewModels.JegyKezeles;
using Flyhigh.Desktop.Views;
using Flyhigh.Desktop.Views.ControlPanel;
using Flyhigh.Desktop.Views.Login;
using Flyhigh.Desktop.Views.Felhasznalok;
using Flyhigh.Desktop.Views.Legijaratok;
using Flyhigh.Desktop.Views.JegyKezeles;
using Microsoft.Extensions.DependencyInjection;
using Flyhigh.Desktop.ViewModels.Administration;
using Flyhigh.Desktop.Views.Administration;

namespace KretaDesktop.Extensions
{
    public static class ViewViewModelsExtensions
    {
        public static void ConfigureViewViewModels(this IServiceCollection services)
        {
            // MainView
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainView>(s => new MainView()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            // LoginView
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<LoginView>(s => new LoginView()
            {
                DataContext = s.GetRequiredService<LoginViewModel>()
            });

            // ControlPanel
            services.AddSingleton<ControlPanelViewModel>();
            services.AddSingleton<ControlPanelView>(s => new ControlPanelView()
            {
                DataContext = s.GetRequiredService<ControlPanelViewModel>()
            });
            // Felhasználok
            services.AddSingleton<FelhasznalokViewModel>();
            services.AddSingleton<FelhasznalokView>(s => new FelhasznalokView()
            {
                DataContext = s.GetRequiredService<FelhasznalokViewModel>()
            });

            services.AddSingleton<JogosultsagokViewModel>();
            services.AddSingleton<JogosultsagokView>(s => new JogosultsagokView()
            {
                DataContext = s.GetRequiredService<JogosultsagokViewModel>()
            });

            services.AddSingleton<TeacherViewModel>();
            services.AddSingleton<TeacherView>(s => new TeacherView()
            {
                DataContext = s.GetRequiredService<TeacherViewModel>()
            });
            // JegyKezelés
            services.AddSingleton<JegyKezelesViewModel>();
            services.AddSingleton<JegyKezelesView>(s => new JegyKezelesView()
            {
                DataContext = s.GetRequiredService<JegyKezelesViewModel>()
            });
            services.AddSingleton<JegyViewModel>();
            services.AddSingleton<Jegykezeles>(s => new Jegykezeles()
            {
                DataContext = s.GetRequiredService<JegyViewModel>()
            });
            //Légijáratok
            services.AddSingleton<LegijaratokViewModel>();
            services.AddSingleton<LegijaratokView>(s => new LegijaratokView()
            {
                DataContext = s.GetRequiredService<LegijaratokViewModel>()
            });
            {
                services.AddSingleton<RepulotarsasagViewModel>();
                services.AddSingleton<RepulotarsasagView>(s => new RepulotarsasagView()
                {
                    DataContext = s.GetRequiredService<RepulotarsasagViewModel>()
                });
                services.AddSingleton<GepAdatokViewModel>();
                services.AddSingleton<GepAdatokView>(s => new GepAdatokView()
                {
                    DataContext = s.GetRequiredService<GepAdatokViewModel>()
                });
                services.AddSingleton<TaughtClassesViewModel>();
                services.AddSingleton<TaughtClassesView>(s => new TaughtClassesView()
                {
                    DataContext = s.GetRequiredService<TaughtClassesViewModel>()
                });

                services.AddSingleton<AdministrationViewModel>();
                services.AddSingleton<AdministrationView>(s => new AdministrationView()
                {
                    DataContext = s.GetRequiredService<AdministrationViewModel>()
                });
                services.AddSingleton<GepAdatokTipusViewModel>();
                services.AddSingleton<GepAdatokTipusView>(s => new GepAdatokTipusView()
                {
                    DataContext = s.GetRequiredService<GepAdatokTipusViewModel>()
                });
            }
        }
    }
}
