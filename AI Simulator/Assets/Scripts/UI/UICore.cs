using Assets.Scripts.Agents;
using Assets.Scripts.Level;
using Assets.Scripts.Agents.Behaviours;
using UnityEngine;
using UnityEngine.UI;

public class UICore : MonoBehaviour {

    private Canvas _canvas;
    private SpriteRenderer _container;
    public Vector2 scrollPosition;
    private string _textLog;
    private bool _logEnabled;

    private static UICore _instance;

    public bool ShowPath { get; private set; }

    // Use this for initialization
    void Awake() {
        _instance = this;
        Load();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            _container.gameObject.SetActive(!_container.gameObject.activeInHierarchy);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("DOWN!");
            TileManager.GetInstance().UndoUnwalkable();
            TileManager.GetInstance().SetOneToUnwalkable();
            AgentManager.GetInstance().TriggerAStar();
        }
        TileManager.GetInstance().UpdateColors();
        foreach (var agent in AgentManager.GetInstance().Agents) {
            if (agent.Behavior.GetType() == typeof(PathFollowingBehaviour)) {
                var behaviour = (PathFollowingBehaviour)agent.Behavior;
                foreach (var n in behaviour.GetPath()) {
                    var sprites = n.Tile.Object.GetComponent<SpriteRenderer>();
                    sprites.color = ShowPath ? Color.green : n.Tile.Color;
                }
            }
        }
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
        if (_logEnabled) {
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(300), GUILayout.Height(300));
            GUILayout.TextField(_textLog, "Label");
            scrollPosition.y = Mathf.Infinity;
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
    }

    public static UICore GetInstance() {
        return _instance;
    }

    private void onTogglePath(bool val) {
        ShowPath = val;

    }

    private void onToggleLog(bool val) {
        _logEnabled = val;
    }

    public void Log(string msg) {
        _textLog += "- " + msg + "\n";
    }

}
