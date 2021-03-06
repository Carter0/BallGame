﻿
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPorter : MonoBehaviour {

	public Text levelPorterText;
	public int collectableTotal;
	int collectableCount = 0;
	int missingCollectables;
    public int sceneIndex;
    GameObject nextLevel;

    void Awake()
    {
        nextLevel = GameObject.FindGameObjectWithTag("NextLevelButton");
        nextLevel.SetActive(false);
    }

    //when the player collides with the levelPorterText
    //display the text and stop player movement
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag ("LevelPorter")){
           DisplayText ();
        }
    }

	//stop displaying text when the player leaves the levelporter
	void OnTriggerExit (Collider other) {
		 if (other.gameObject.CompareTag ("LevelPorter")){
			StopDisplayText ();

        }

	}

	//displays level complete if all the collectables were collected
	//otherwise, displays how many collectables are left
	void DisplayText () {
		collectableCount = GetComponent <Collectables>().collectableCount;
		missingCollectables = collectableTotal - collectableCount;
		if (collectableCount == collectableTotal) {
			levelPorterText.text = "Level Complete";
			StopPlayerMovement ();
            nextLevel.SetActive(true);
		}

		if (collectableCount < collectableTotal && missingCollectables == 1) {
			levelPorterText.text = "Missing " + missingCollectables + " collectable";
		} else if (collectableCount < collectableTotal) {
			levelPorterText.text = "Missing " + missingCollectables + " collectables";
		}
		

	}

	//stops the players movement
	void StopPlayerMovement () {
		GetComponent <Rigidbody>().velocity = new Vector3(0, 0, 0);
		GetComponent <Movement>().speed = 0;
	}

	//functions stop displaying the levelporter text
	void StopDisplayText () {
		levelPorterText.text = "";

	}
    //load the next level
    public void LoadNextLevel (int sceneIndex) {
        SceneManager.LoadScene (sceneIndex);
    }
	

}
