using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {


	public static bool autoPlay = false;
	public Text text;
	
	
	public void edit ()
	{
		autoPlay = !autoPlay;
		
		print (autoPlay);
		if (autoPlay == true)
		{text.text = "AUTO PLAY : ON";}
		else 
		{
			text.text = "AUTO PLAY : OFF";
		}
		
	}


	public void LoadLevel(string name){
		Ball.hasStarted = false;
		Brick.breakableCount = 0;
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel()
	{
	Ball.hasStarted = false;
	Brick.breakableCount = 0;
	Application.LoadLevel (Application.loadedLevel + 1);
	
	}

	public void BrickDestroyed (){ 
	if (Brick.breakableCount <= 0){
	LoadNextLevel();
	
	}
	
	}

}
