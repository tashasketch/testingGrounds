﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignRead : MonoBehaviour {

	public GameObject dialogueBox;
	public Text dialogueText;
	public string dialogue;
	public bool playerInRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && playerInRange) {
			if (dialogueBox.activeInHierarchy) {
				dialogueBox.SetActive (false);
			}else{
				dialogueBox.SetActive (true);
				dialogueText.text = dialogue;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			playerInRange = true;

		}
	
	
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			playerInRange = false;
			dialogueBox.SetActive (false);
		}
	}
}
