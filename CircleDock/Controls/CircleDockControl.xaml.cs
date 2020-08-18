using CircleDock.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CircleDock.Controls
{
    public partial class CircleDockControl : UserControl
    {
        public ObservableCollection<Shortcut> Shortcuts
        {
            get => (ObservableCollection<Shortcut>)GetValue(ShortcutsProperty);
            set => SetValue(ShortcutsProperty, value);
        }
        public static readonly DependencyProperty ShortcutsProperty =
            DependencyProperty.Register(
                "Shortcuts",
                typeof(ObservableCollection<Shortcut>),
                typeof(CircleDockControl),
                new PropertyMetadata(new ObservableCollection<Shortcut>()));

        public double ShortcutsWidth
        {
            get { return (double)GetValue(ShortcutsWidthProperty); }
            set { SetValue(ShortcutsWidthProperty, value); }
        }
        public static readonly DependencyProperty ShortcutsWidthProperty =
            DependencyProperty.Register(
                "ShortcutsWidth", 
                typeof(double), 
                typeof(CircleDockControl), 
                new PropertyMetadata(0d));

        public double ShortcutsHeight
        {
            get { return (double)GetValue(ShortcutsHeightProperty); }
            set { SetValue(ShortcutsHeightProperty, value); }
        }
        public static readonly DependencyProperty ShortcutsHeightProperty =
            DependencyProperty.Register(
                "ShortcutsHeight", 
                typeof(double),
                typeof(CircleDockControl), 
                new PropertyMetadata(0d));

        public double ShortcutsBorderThickness
        {
            get { return (double)GetValue(ShortcutsBorderThicknessProperty); }
            set { SetValue(ShortcutsBorderThicknessProperty, value); }
        }
        public static readonly DependencyProperty ShortcutsBorderThicknessProperty =
            DependencyProperty.Register(
                "ShortcutsBorderThickness",
                typeof(double),
                typeof(CircleDockControl),
                new PropertyMetadata(0d));

        public double Rotation
        {
            get => (double)GetValue(RotationProperty);
            set => SetValue(RotationProperty, value);
        }
        public static readonly DependencyProperty RotationProperty =
            DependencyProperty.Register(
                "Rotation",
                typeof(double),
                typeof(CircleDockControl),
                new PropertyMetadata(0d));

        public double ActualRotation
        {
            get => (double)GetValue(ActualRotationProperty);
            set => SetValue(ActualRotationProperty, value);
        }
        public static readonly DependencyProperty ActualRotationProperty =
            DependencyProperty.Register(
                "ActualRotation",
                typeof(double),
                typeof(CircleDockControl),
                new PropertyMetadata(0d));

        public ICommand ShortcutCommand
        {
            get => (ICommand)GetValue(ShortcutCommandProperty);
            set => SetValue(ShortcutCommandProperty, value);
        }
        public static readonly DependencyProperty ShortcutCommandProperty =
            DependencyProperty.Register(
                "ShortcutCommand",
                typeof(ICommand),
                typeof(CircleDockControl),
                new PropertyMetadata(null));

        public CircleDockControl() => InitializeComponent();
    }
}
