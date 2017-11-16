using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCursor : MonoBehaviour {

	public Texture crosshairImage;
	
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;	

		if (crosshairImage == null)
			throw new ArgumentException ("You must specify a crosshair texture");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {			
			Cursor.lockState = CursorLockMode.None;
		}
	}

	void OnGUI()
	{
		float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
		float yMin = (Screen.height / 2) - (crosshairImage.height / 2);

		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
}
