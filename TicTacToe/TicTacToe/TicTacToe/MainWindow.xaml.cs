using System;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _playersDefeats;
        private int _playersVictories;
        private int _compDefeats;
        private int _compVictories;
        private int _compPlusDefeats;
        private int _compPlusVictories;
        private int _playersDraws;
        private int _compDraws;
        private int _compPlusDraws;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void IncPlayersDefeats()
        {
            _playersDefeats++;
            PlayerDefeat.Content = _playersDefeats.ToString();
        }

        private void IncPlayersVictories()
        {
            _playersVictories++;
            PlayerVictory.Content = _playersVictories.ToString();
        }

        private void IncCompDefeats()
        {
            _compDefeats++;
            CompDefeat.Content = _compDefeats.ToString();
        }

        private void IncCompVictories()
        {
            _compVictories++;
            CompVictory.Content = _compVictories.ToString();
        }

        private void IncCompPlusDefeats()
        {
            _compPlusDefeats++;
            CompPlusDefeat.Content = _compPlusDefeats.ToString();
        }

        private void IncCompPlusVictories()
        {
            _compPlusVictories++;
            CompPlusVictory.Content = _compPlusVictories.ToString();
        }

        private void IncPlayersDraws()
        {
            _playersDraws++;
            PlayerDraw.Content = _playersDraws.ToString();
        }

        private void IncCompDraws()
        {
            _compDraws++;
            CompDraw.Content = _compDraws.ToString();
        }

        private void IncCompPlusDraws()
        {
            _compPlusDraws++;
            CompPlusDraw.Content = _compPlusDraws.ToString();
        }

        private void OpenNewPlayerGame(object sender, RoutedEventArgs args)
        {
            var w = new GameWindow();
            AbstractGameLogic logic = new TwoPlayersGameLogic(
                IncPlayersVictories, 
                IncPlayersDefeats,
                IncPlayersDraws,
                w);
            w.Show();
        }

        private void OpenNewCompGame(object sender, RoutedEventArgs args)
        {
            var w = new GameWindow();
            AbstractGameLogic logic = new CompGameLogic(
                IncCompVictories,
                IncCompDefeats,
                IncCompDraws,
                w);
            w.Show();
        }

        private void OpenNewCompPlusGame(object sender, RoutedEventArgs args)
        {
            var w = new GameWindow();
            AbstractGameLogic logic = new CompPlusGameLogic(
                IncCompPlusVictories,
                IncCompPlusDefeats,
                IncCompPlusDraws,
                w);
            w.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
