using System;
using UnityEngine;
using UnityEngine.UI;

namespace MiniFight.UI
{
    [RequireComponent(typeof(Canvas))]
    public class MainMenuWindow : MonoBehaviour
    {
        public event Action PlayClicked;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;

        public void Close()
        {
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClick);
            _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        }

        private void OnSettingsButtonClick()
        {
            //TODO...
        }

        private void OnPlayButtonClick()
        {
            PlayClicked?.Invoke();
        }
    }
}