using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Agents;
using Assets.Scripts.Agents.Behaviours;
using Assets.Scripts.AStar;
using Assets.Scripts.Level;
using UnityEngine;
using UnityEngine.UI;

public class UICore : MonoBehaviour {

    private Canvas _canvas;
    private SpriteRenderer _container;
    private string _textLog;
    private bool _logEnabled;

    private static UICore _instance;

    // Use this for initialization
    void Awake () {
        _instance = this;
	    Load();
	}
	
	// Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.X))
            _container.gameObject.SetActive(!_container.gameObject.activeInHierarchy);
    }


    private void Load() {
        _canvas = GetComponent<Canvas>();
        _container = _canvas.GetComponentInChildren<SpriteRenderer>();
        _container.sortingOrder = 2;
        _container.color = new Color(1f, 1f, 1f, 0f);
        _container.gameObject.SetActive(false);
        _container.transform.Find("TogglePath").GetComponent<Toggle>().onValueChanged.AddListener(onTogglePath);
        _container.transform.Find("ToggleLog").GetComponent<Toggle>().onValueChanged.AddListener(onToggleLog);
        _textLog = "";

    }

    void OnGUI() {
        if(_logEnabled)
            GUI.TextArea(new Rect(0, 0, 200, 300), _textLog, 200);
    }

    public static UICore GetInstance() {
        return _instance;
    }

    private void onTogglePath(bool val) {
        foreach (AgentBase agent in AgentManager.GetInstance().Agents) {
            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                PathFollowingBehaviour behaviour = (PathFollowingBehaviour) agent.Behavior;
                foreach (Node n in behaviour.GetPath()) {
                    SpriteRenderer sprites = n.Tile.Object.GetComponent<SpriteRenderer>();
                    sprites.color = val ? Color.green : n.Tile.Color;
                }

            }
        } 
    }

    private void onToggleLog(bool val) {
        _logEnabled = val;
    }

    public void Log(string msg) {
        _textLog += "- "+msg + "\n";
    }

}
