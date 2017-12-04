using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        public void SetGameType(string type)
        {
            Label.Content = type;
        }

        public event EventHandler<ReactOnMoveArguments> MoveMade;

        public void SetCell(int x, int y, string cell)
        {
            Button button;
            Debug.Assert(x >= 0 && x <= 2);
            Debug.Assert(y >= 0 && y <= 2);
            if (x == 0 && y == 0)
            {
                button = Button00;
            }
            else if (x == 0 && y == 1)
            {
                button = Button01;
            }
            else if (x == 0 && y == 2)
            {
                button = Button02;
            }
            else if (x == 1 && y == 0)
            {
                button = Button10;
            }
            else if (x == 1 && y == 1)
            {
                button = Button11;
            }
            else if (x == 1 && y == 2)
            {
                button = Button12;
            }
            else if (x == 2 && y == 0)
            {
                button = Button20;
            }
            else if (x == 2 && y == 1)
            {
                button = Button21;
            }
            else if (x == 2 && y == 2)
            {
                button = Button22;
            }
            else
            {
                throw new Exception("Unexpected state of the program");
            }
            button.Content = cell;
        }

        private void ClickButton00(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(0, 0));
        private void ClickButton01(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(0, 1));
        private void ClickButton02(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(0, 2));
        private void ClickButton10(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(1, 0));
        private void ClickButton11(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(1, 1));
        private void ClickButton12(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(1, 2));
        private void ClickButton20(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(2, 0));
        private void ClickButton21(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(2, 1));
        private void ClickButton22(object sender, RoutedEventArgs args) => MoveMade?.Invoke(this, new ReactOnMoveArguments(2, 2));
    }
}
