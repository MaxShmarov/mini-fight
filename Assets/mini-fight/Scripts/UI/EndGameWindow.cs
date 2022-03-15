using MiniFight.Interfaces;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MiniFight.UI
{
    [RequireComponent(typeof(Canvas))]
    public class EndGameWindow : MonoBehaviour
    {
        public event Action ExitClicked;
        public event Action RestartClicked;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TextMeshProUGUI _header;
        [SerializeField] private TextMeshProUGUI _fightersLeft;
        [SerializeField] private TextMeshProUGUI _fightingTime;

        private const string HEADER_FORMAT = "{0} victory";
        private const string TIME_FORMAT = "{0:D2}:{1:D2}";

        public void Initialize(IFightResult result)
        {
            _header.text = string.Format(HEADER_FORMAT, result.WinnerName);
            _fightersLeft.text = result.AliveMembersCount.ToString();
            _fightingTime.text = string.Format(TIME_FORMAT, (int)result.Time.TotalMinutes, result.Time.Seconds);
        }

        public void Close()
        {
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClick);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClick);
            _exitButton.onClick.RemoveListener(OnExitButtonClick);
        }

        private void OnRestartButtonClick()
        {
            RestartClicked?.Invoke();
        }

        private void OnExitButtonClick()
        {
            ExitClicked?.Invoke();
        }
    }
}