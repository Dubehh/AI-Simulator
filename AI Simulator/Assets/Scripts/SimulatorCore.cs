using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Agents;
using Assets.Scripts.Level;
using UnityEngine;

public class SimulatorCore : MonoBehaviour {

    void Awake() {
        TileManager.GetInstance().Load();
    }

    // Use this for initialization
    void Start() {
        AgentManager.GetInstance().Load();
    }

    // Update is called once per frame
    void Update() {
        AgentManager.GetInstance().Update();
    }

}
