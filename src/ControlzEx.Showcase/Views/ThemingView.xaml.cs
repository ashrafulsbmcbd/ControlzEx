﻿namespace ControlzEx.Showcase.Views
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using ControlzEx.Theming;
    using JetBrains.Annotations;

    public partial class ThemingView : INotifyPropertyChanged
    {
        public ThemingView()
        {
            this.InitializeComponent();
        }

        public Theme CurrentTheme
        {
            get => ThemeManager.DetectTheme(Window.GetWindow(this));

            set
            {
                if (value is null == false)
                {
                    ThemeManager.ChangeTheme(Window.GetWindow(this), value);
                }

                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.CurrentBaseColor));
            }
        }

        public string CurrentBaseColor
        {
            get => this.CurrentTheme.BaseColorScheme;

            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    ThemeManager.ChangeThemeBaseColor(Window.GetWindow(this), value);
                }

                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.CurrentTheme));
            }
        }

        public string CurrentColorScheme
        {
            get => this.CurrentTheme.ColorScheme;

            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    ThemeManager.ChangeThemeColorScheme(Window.GetWindow(this), value);
                }

                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.CurrentTheme));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}