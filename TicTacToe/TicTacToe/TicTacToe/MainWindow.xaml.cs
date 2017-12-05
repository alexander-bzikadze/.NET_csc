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

        private InformationPasser _informationPasser;

        public MainWindow()
        {
            InitializeComponent();

            _informationPasser = new InformationPasser(this);
            PlayerButton.Click += _informationPasser.OpenNewPlayerGame;
            CompButton.Click += _informationPasser.OpenNewCompGame;
            CompPlusButton.Click += _informationPasser.OpenNewCompPlusGame;
        }

        private class InformationPasser
        {
            MainWindow _mother;

            internal InformationPasser(MainWindow mother)
            {
                _mother = mother;
            }

            private void PrepareWindowAndLogic(GameWindow gameWindow, AbstractGameLogic logic)
            {
                gameWindow.MoveMade += logic.ReactOnMove;
                gameWindow.SetGameType(logic.GameType);
                gameWindow.Show();
            }

            internal void OpenNewPlayerGame(object sender, RoutedEventArgs args)
            {
                var gameWindow = new GameWindow();
                AbstractGameLogic logic = new TwoPlayersGameLogic(
                    () => { _mother.IncPlayersVictories(); gameWindow.FirstWins(); },
                    () => { _mother.IncPlayersDefeats(); gameWindow.SecondWins(); },
                    () => { _mother.IncPlayersDraws(); gameWindow.NoneWins(); },
                    gameWindow.SetCell,
                    l => { gameWindow.MoveMade -= l.ReactOnMove; });
                PrepareWindowAndLogic(gameWindow, logic);
            }

            internal void OpenNewCompGame(object sender, RoutedEventArgs args)
            {
                var gameWindow = new GameWindow();
                AbstractGameLogic logic = new CompGameLogic(
                    () => { _mother.IncCompVictories(); gameWindow.FirstWins();  },
                    () => { _mother.IncCompDefeats(); gameWindow.SecondWins(); },
                    () => { _mother.IncCompDraws(); gameWindow.NoneWins(); },
                    gameWindow.SetCell,
                    l => { gameWindow.MoveMade -= l.ReactOnMove; });
                PrepareWindowAndLogic(gameWindow, logic);
            }

            internal void OpenNewCompPlusGame(object sender, RoutedEventArgs args)
            {
                var gameWindow = new GameWindow();
                AbstractGameLogic logic = new CompPlusGameLogic(
                    () => { _mother.IncCompPlusVictories(); gameWindow.FirstWins(); },
                    () => { _mother.IncCompPlusDefeats(); gameWindow.SecondWins(); },
                    () => { _mother.IncCompPlusDraws(); gameWindow.NoneWins(); },
                    gameWindow.SetCell,
                    l => { gameWindow.MoveMade -= l.ReactOnMove; });
                PrepareWindowAndLogic(gameWindow, logic);
            }
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

        private void Window_Closed(object sender, EventArgs e)
        {
            PlayerButton.Click -= _informationPasser.OpenNewPlayerGame;
            CompButton.Click -= _informationPasser.OpenNewCompGame;
            CompPlusButton.Click -= _informationPasser.OpenNewCompPlusGame;
            App.Current.Shutdown();
        }
    }
}
