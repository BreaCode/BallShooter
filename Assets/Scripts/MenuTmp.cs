using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

namespace BallShooter
{
    public sealed class MenuTmp : MonoBehaviour
    {
        //Здесь пока колхоз
        //Я знаю что так нельзя, но сделал просто чтоб работало
        private GameObject _menu;
        private GameObject _settings;
        private GameObject _gui;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private TMP_Text _HP;
        [SerializeField] private TMP_Text _Score;
        [SerializeField] private GameData _data;


        private void Start()
        {
            _menu = GameObject.Find("PauseMenu");
            _gui = GameObject.Find("GUI");
            _continueButton.onClick.AddListener(Continue);
            _restartButton.onClick.AddListener(Restart);
            _quitButton.onClick.AddListener(Close);
            _menu.SetActive(false);
            GameEventSystem.current.onGUIUpdate += GUIUpdate;
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

        private void GUIUpdate()
        {
            _HP.text = $"HP : {_data.Health}";
            _Score.text = $"Score : {_data.Score}";
        }

        private void Restart()
        {
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
        }
    }
}
