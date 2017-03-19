using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Level;
using UnityEngine;

public class SimulatorCore : MonoBehaviour {

    void Awake() {
        TileManager.GetInstance().Load();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
