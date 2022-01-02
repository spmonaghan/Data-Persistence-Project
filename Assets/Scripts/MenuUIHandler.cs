using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{
    public string newName;

    public GameObject nameInput;
    public TextMeshProUGUI HighScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        newName = InfoManager.Instance.currentName;
        nameInput.GetComponent<TMP_InputField>().text = newName;
        if (InfoManager.Instance.highScore != 0) 
        {
            HighScoreDisplay.text = "Best Score: " + InfoManager.Instance.highScoreName + " with " + InfoManager.Instance.highScore; 
        }
        else
        {
            HighScoreDisplay.text = "Best Score: Nothing Yet!";
        }
    }

    public void UpdateName()
    {
        newName = nameInput.GetComponent<TMP_InputField>().text;
        InfoManager.Instance.currentName = newName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        InfoManager.Instance.SaveInformation();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
