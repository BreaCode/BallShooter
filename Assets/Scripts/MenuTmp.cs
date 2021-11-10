using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

namespace BallShooter
{
    public sealed class MenuTmp : MonoBehaviour
    {
        private GameObject _menu;
        private GameObject _gui;
        private GameObject _looseScreen;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Button _retryButton;
        [SerializeField] private TMP_Text _hp;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _looseScore;
        [SerializeField] private GameData _data;


        private void Start()
        {
            _menu = GameObject.Find("PauseMenu");
            _gui = GameObject.Find("GUI");
            _looseScreen = GameObject.Find("Loose");
            _continueButton.onClick.AddListener(Continue);
            _restartButton.onClick.AddListener(Restart);
            _retryButton.onClick.AddListener(Restart);
            _quitButton.onClick.AddListener(Close);
            _menu.SetActive(false);
            _looseScreen.SetActive(false);
            GameEventSystem.current.onGUIUpdate += GUIUpdate;
            GameEventSystem.current.onLoose += Loose;
        }

        void Update()
        {
            //Это должно быть в инпуте
            if (Input.GetButtonDown("Pause"))
            {
                Time.timeScale = 0f;
                _menu.SetActive(true);
                _gui.SetActive(false);
            }
        }

        private void Loose()
        {
            _gui.SetActive(false);
            _looseScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        private void GUIUpdate()
        {
            _hp.text = $"HP : {_data.Health}";
            _score.text = $"Score : {_data.Score}";
            _looseScore.text = _score.text;
        }

        private void Restart()
        {
            DataInitialization.Initialization(_data);
            SceneManager.LoadScene(0);
        }
        private void Continue()
        {
            Time.timeScale = 1f;
            _menu.SetActive(false);
            _gui.SetActive(true);
        }
        private void Close()
        {
            Application.Quit();
        }

        private void OnDisable()
        {
            GameEventSystem.current.onGUIUpdate -= GUIUpdate;
            GameEventSystem.current.onLoose -= Loose;
        }
    }
}
