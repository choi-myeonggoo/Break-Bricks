using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public Text score;
    public TMP_InputField nameField;
    public static string playerName;
    // Start is called before the first frame update
    void Start()
    {
        Data player = DataManager.Instance.GetLastPlayer();
        nameField.text = player.name;
        score.text = score.text + player.name +" : "+player.score.ToString();
    }
    public void ToGame()
    {
        playerName = nameField.text;
        SceneManager.LoadScene(1);
    }
    public void ToLeaderBoard()
    {
        SceneManager.LoadScene(2);
    }
    public void ToOption()
    {
        playerName = nameField.text;
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
