using MiniFight.Interfaces;
using MiniFight.UI;
using System;
using UnityEngine;

namespace MiniFight.Contexts
{
    public class UISceneContext : BaseContext
    {
        public event Action Play;
        public event Action Exit;
        public event Action Restart;

        [SerializeField] private MainMenuWindow _mainMenuPrefab;
        [SerializeField] private EndGameWindow _endGamePrefab;

        private MainMenuWindow _mainMenu;
        private EndGameWindow _endGame;

        public override void StartContext()
        {
            if (_mainMenu != null) { return; }

            _mainMenu = Instantiate(_mainMenuPrefab, transform);
            _mainMenu.PlayClicked += OnPlayClicked;
        }

        public void ShowResult(IFightResult result)
        {
            if (_endGame != null) { return; }

            _endGame = Instantiate(_endGamePrefab, transform);
            _endGame.Initialize(result);
            _endGame.ExitClicked += OnExitClicked;
            _endGame.RestartClicked += OnRestartClicked;

        }

        private void OnRestartClicked()
        {
            CloseExitWindow();

            Restart?.Invoke();
        }

        private void OnExitClicked()
        {
            CloseExitWindow();

            Exit?.Invoke();
        }

        private void CloseExitWindow()
        {
            _endGame.ExitClicked -= OnExitClicked;
            _endGame.RestartClicked -= OnRestartClicked;
            _endGame.Close();
            _endGame = null;
        }

        private void OnPlayClicked()
        {
            _mainMenu.PlayClicked -= OnPlayClicked;
            _mainMenu.Close();
            _mainMenu = null;

            Play?.Invoke();
        }
    }
}