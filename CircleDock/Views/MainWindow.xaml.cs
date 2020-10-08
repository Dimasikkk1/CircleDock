using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace CircleDock.Views
{
    partial class MainWindow : Window
    {
        // Тут код позволяющий окну уходить вверх (Source: https://stackoverflow.com/a/331251)
        // TODO: Из-за этого костыля окно не появляется на месте курсора или по центру экрана.

        //public struct WINDOWPOS
        //{
        //    public IntPtr hwnd;
        //    public IntPtr hwndInsertAfter;
        //    public int x;
        //    public int y;
        //    public int cx;
        //    public int cy;
        //    public uint flags;
        //};

        public MainWindow()
        {
            InitializeComponent();

            //Loaded += (s, e) =>
            //{
            //    HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            //    source.AddHook(new HwndSourceHook(WndProc));
            //};
        }

        //private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    switch (msg)
        //    {
        //        case 0x46://WM_WINDOWPOSCHANGING
        //            if (Mouse.LeftButton != MouseButtonState.Pressed)
        //            {
        //                WINDOWPOS wp = (WINDOWPOS)Marshal.PtrToStructure(lParam, typeof(WINDOWPOS));
        //                wp.flags = wp.flags | 2; //SWP_NOMOVE
        //                Marshal.StructureToPtr(wp, lParam, false);
        //            }
        //            break;
        //    }
        //    return IntPtr.Zero;
        //}
    }
}
