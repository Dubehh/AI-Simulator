using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICore : MonoBehaviour {

    private Canvas _canvas;
    private SpriteRenderer _container;

	// Use this for initialization
	void Start () {
	    Load();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.X)) {
	        _container.gameObject.SetActive(!_container.gameObject.activeInHierarchy);
	    }
	}

    private void Load() {
        _canvas = GetComponent<Canvas>();
        _container = _canvas.GetComponentInChildren<SpriteRenderer>();
        _container.sortingOrder = 2;
        _container.color = new Color(1f, 1f, 1f, 0f);
        _container.gameObject.SetActive(false);

    }

}
