using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    private SceneType _sceneType;
    private ControlType _controlType;
    private bool _changeSceneRequest;

    [SerializeField] private PlayerControl _playerControl;
    [SerializeField] private Button _startButton;
    [SerializeField] private Image _reticle;
    [SerializeField] private TMP_Text _debugText;

    private Transform _cameraTransform;
    private int _score;




    private void StartScene()
    {
        _controlType = ControlType.SHOOT;
        _reticle.gameObject.SetActive(true);
        _score = 0;
        _startButton = _startButton.GetComponent<Button>();

        if (_startButton == null)
            VisualDebug.Console.Log("_startButton == null");

        VisualDebug.Console.Log("Scene de démarage");
    }




    private void PlayScene()
    {
        _controlType = ControlType.PLACEMENT;
        _reticle.gameObject.SetActive(false);

        VisualDebug.Console.Log("Mode de placement d'objets");
    }




    public void ChangeSceneRequest()
    {
        _changeSceneRequest = true;
    }




    private void ChangeToShoot()
    {
        if (_controlType != ControlType.SHOOT && PlayerControl.getCounter()  >= 1)
        {
            _controlType = ControlType.SHOOT;
            _reticle.gameObject.SetActive(true);

            VisualDebug.Console.Log("Mode de tir activé");
        }
    }




    public void UpdateScore()
    {
        _score++;

        VisualDebug.Console.Log("Score : " +  _score.ToString());
    }




    public ControlType GetControlType()
    { return _controlType; }





    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
        _changeSceneRequest = false;
        _cameraTransform = transform;

        StartScene();
    }




    void Update()
    {
        if (_changeSceneRequest)
        {
            switch (_sceneType)
            {
                case SceneType.START:
                    PlayScene();
                    _sceneType = SceneType.PLAY;
                    break;

                case SceneType.PLAY:
                    StartScene();
                    _sceneType = SceneType.START;
                    break;

                default:
                    VisualDebug.Console.Log("!!! GameManager : Type de '_sceneType' inconnu");
                    break;
            }
            _changeSceneRequest = false;
        }

        ChangeToShoot();
    }
}