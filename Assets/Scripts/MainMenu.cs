using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;

	public int MazeScene;
	public void PlayMaze()
	{
		ToggleColorblindMode();
		SceneManager.LoadScene(MazeScene);
	}

	public void QuitMaze()
	{
		Debug.Log("Quit Game");
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
	}

	public void ToggleColorblindMode()
	{
		if (colorblindMode.isOn)
		{
			trapMat.color = new Color32(255, 112, 0, 1);
			goalMat.color = Color.blue;
		}
		else
		{
			trapMat.color = Color.red;
			goalMat.color = Color.green;
		}
	}
}
