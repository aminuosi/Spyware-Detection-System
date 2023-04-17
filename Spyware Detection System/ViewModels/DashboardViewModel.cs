using Accessibility;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using Wpf.Ui.Common.Interfaces;

namespace Spyware_Detection_System.ViewModels
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware
    {
        [ObservableProperty]
        private int _counter = 0;

        /// <summary>
        /// 模拟键盘输入的Windows API函数
        /// </summary>
        /// <param name="bVk">键值</param>
        /// <param name="bScan">硬件扫描码</param>
        /// <param name="dwFlags">标志位未指定为按下该键，2为松开该键</param>
        /// <param name="dwExtraInfo">附加值</param>
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        /// <summary>
        /// 模拟鼠标的Windows API函数
        /// </summary>
        /// <param name="dwFlags">操作</param>
        /// <param name="dx">x轴</param>
        /// <param name="dy">y轴</param>
        /// <param name="dwData">鼠标轮移动的数量</param>
        /// <param name="dwExtraInfo">附加值</param>
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        /// <summary>
        /// 模拟鼠标移动的Windows API函数
        /// </summary>
        /// <param name="X">x轴</param>
        /// <param name="Y">y轴</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// 检索处理顶级窗口的类名和窗口名称匹配指定的字符串
        /// </summary>
        /// <param name="lpClassName">类名</param>
        /// <param name="lpWindowName">窗口名</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 将指定的消息发送到一个或多个窗口
        /// </summary>
        /// <param name="hWnd">接收消息的窗口的句柄</param>
        /// <param name="Msg">指定被发送的消息</param>
        /// <param name="wParam">指定附加的消息特定信息</param>
        /// <param name="lParam">指定附加的消息特定信息</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

        /// <summary>
        /// 聚焦窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]  
        private static extern IntPtr SetFocus(IntPtr hWnd);

        [ObservableProperty]
        private Thread t1 = new Thread(SimulateKeyboardInput);
        [ObservableProperty]
        private Thread t2 = new Thread(SimulateTextCreation);
        [ObservableProperty]
        private Thread t3 = new Thread(SimulatePasteCopy);
        [ObservableProperty]
        private Thread t4 = new Thread(SimulateMouseMove);
        [ObservableProperty]
        private Thread t5 = new Thread(SimulateFileOperation);

        [ObservableProperty]
        static private bool s1 = true;
        [ObservableProperty]
        static private bool s2 = true;
        [ObservableProperty]
        static private bool s3 = true;
        [ObservableProperty]
        static private bool s4 = true;
        [ObservableProperty]
        static private bool s5 = true;

        [STAThreadAttribute]
        public void OnNavigatedTo()
        {
        }

        public void OnNavigatedFrom()
        {
        }

        [RelayCommand]
        public void SimulateKeyboardInputThread(){ t1.Start(); }
        [RelayCommand]
        public void KeyboardInputThreadStart() { s1 = true; }
        [RelayCommand]
        public void KeyboardInputThreadPause() { s1 = false; }

        [RelayCommand]
        public void SimulateTextCreationThread() { t2.Start(); }
        [RelayCommand]
        public void TextCreationThreadStart() { s2 = true; }
        [RelayCommand]
        public void TextCreationThreadPause() { s2 = false; }

        [RelayCommand]
        public void SimulateCopyPasteThread() 
        {
            t3.SetApartmentState(ApartmentState.STA);
            t3.Start();
        }

        [RelayCommand]
        public void CopyPasteThreadStart() { s3 = true; }
        [RelayCommand]
        public void CopyPasteThreadPause() { s3 = false; }

        [RelayCommand]
        public void SimulateMouseMoveThread() { t4.Start(); }
        [RelayCommand]
        public void MouseMoveThreadStart() { s4 = true; }
        [RelayCommand]
        public void MouseMoveThreadPause() { s4 = false; }

        [RelayCommand]
        public void SimulateFileOperationThread() { t5.Start(); }
        [RelayCommand]
        public void FileOperationThreadStart() { s5 = true; }
        [RelayCommand]
        public void FileOperationThreadPause() { s5 = false; }

        /// <summary>
        /// 键盘输入模拟
        /// </summary>
        static public void SimulateKeyboardInput() 
        {
            byte bVk_A = 0x41;

            DateTime startTime = DateTime.Now;
            TimeSpan durl = DateTime.Now - startTime;
            while (true) 
            {
                while (durl.TotalSeconds<5)
                {
                    keybd_event(bVk_A, 0, 0, 0);
                    Thread.Sleep(50);
                    keybd_event(bVk_A, 0, 2, 0);
                    durl = DateTime.Now - startTime;
                }

            }
        }

        /// <summary>
        /// 文本创建模拟
        /// </summary>
        static public void SimulateTextCreation() 
        {
            // 使用 Windows API 创建一个记事本窗口
            Process notepad = Process.Start("notepad.exe");
            // 发送文本内容到记事本
            //IntPtr hWnd = FindWindow(null, "无标题 - 记事本");

            // 等待记事本窗口创建完成
            notepad.WaitForInputIdle();

            const UInt32 WM_SETTEXT = 0x000C;
            int i = 0;
            string text;

            DateTime startTime = DateTime.Now;
            TimeSpan durl = DateTime.Now - startTime;
            //SendMessage(notepad.MainWindowHandle, WM_SETTEXT, IntPtr.Zero, text);

            /*const UInt32 WM_CLOSE = 0x0010;
            SendMessage(notepad.MainWindowHandle, WM_CLOSE, IntPtr.Zero.ToInt32(), IntPtr.Zero);*/

            /*SendMessage(hWnd, 0x000C, 0, Marshal.StringToHGlobalAnsi("Hello, world!"));
            Thread.Sleep(500);*/
            // 关闭记事本
            /*SendMessage(hWnd, 0x0010, 0, (IntPtr)0);*/
            //IntPtr hWnd;
            while (true)
            {
                while (durl.TotalSeconds<5)
                {
                    text = "hello world" + i.ToString();
                    //hWnd = FindWindow(null, "无标题 - 记事本");
                    //if (hWnd != IntPtr.Zero)
                    //{
                    SendMessage(notepad.MainWindowHandle, WM_SETTEXT, IntPtr.Zero, text);
                    //}
                    //else { break; }
                    Thread.Sleep(200);
                    i++;
                    
                    // 关闭记事本
                    //SendMessage(hWnd, 0x0010, 0, (IntPtr)0);
                    durl = DateTime.Now - startTime;
                }
            }

            /*// 启动 Windows 记事本
            Process notepad = Process.Start("notepad.exe");

            // 等待记事本窗口创建完成
            notepad.WaitForInputIdle();

            // 获取记事本窗口句柄
            IntPtr notepadHandle = notepad.MainWindowHandle;

            // 发送 WM_SETTEXT 消息以设置记事本文本
            const UInt32 WM_SETTEXT = 0x000C;
            string text = "hello world";
            SendMessage(notepadHandle, WM_SETTEXT, IntPtr.Zero, text);

            // 等待一段时间，以便我们可以看到记事本中的文本
            System.Threading.Thread.Sleep(1000);

            // 将记事本中的文本保存为文件
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string filePath = Path.Combine(desktopPath, "1.txt");
            File.WriteAllText(filePath, text);

            // 关闭记事本
            notepad.Kill();*/
        }


        
        static public void SimulatePasteCopy() 
        {
            // 模拟复制操作
            string text = "文本";
            Clipboard.SetText(text);
            byte bVk_Crtl = 0x11;
            byte bVk_C = 0x43;
            byte bVk_V = 0x56;

            // 使用 Windows API 创建一个记事本窗口
            Process.Start("notepad.exe");
            IntPtr hWnd = FindWindow(null, "无标题 - 记事本");
            //IntPtr hWnd2 = FindWindow(null, "Spyware_Detection_System");
            SetForegroundWindow(hWnd);

            DateTime startTime = DateTime.Now;
            TimeSpan durl = DateTime.Now - startTime;

            while (true) 
            {
                while (durl.TotalSeconds<5) 
                {
                    //模拟crtl+c
                    keybd_event(bVk_Crtl, 0, 0, 0);
                    keybd_event(bVk_C, 0, 0, 0);
                    Thread.Sleep(100);
                    keybd_event(bVk_C, 0, 2, 0);
                    keybd_event(bVk_Crtl, 0, 2, 0);

                    Thread.Sleep(100);
                    //模拟crtl+v
                    keybd_event(bVk_Crtl, 0, 0, 0);
                    keybd_event(bVk_V, 0, 0, 0);
                    Thread.Sleep(100);
                    keybd_event(bVk_V, 0, 2, 0);
                    keybd_event(bVk_Crtl, 0, 2, 0);
                    durl = DateTime.Now - startTime;
                }
                break;
            }
        }

        static public void SimulateMouseMove()
        {
            Random rnd;
            int x, y;
            DateTime startTime = DateTime.Now;
            TimeSpan durl = DateTime.Now - startTime;
            while (true) 
            {
                while (durl.TotalSeconds<5) 
                {
                    rnd = new Random();

                    x = rnd.Next(0,1920);
                    y = rnd.Next(0, 1080);  

                    SetCursorPos(x, y);
                    Thread.Sleep(50);
                    durl = DateTime.Now - startTime;
                }
            }
        }

        static public void SimulateFileOperation()
        {
            DateTime startTime = DateTime.Now;
            TimeSpan durl = DateTime.Now - startTime;
            while (true) 
            {
                while (durl.TotalSeconds<5) 
                {
                    // 创建一个新文件
                    string fileName = "test" + ".txt";
                    File.WriteAllText(fileName, "测试文件");

                    // 删除文件
                    File.Delete(fileName);

                    // 暂停 500 毫秒
                    Thread.Sleep(500);
                    durl = DateTime.Now - startTime;
                }
            }
        }
    }

}
