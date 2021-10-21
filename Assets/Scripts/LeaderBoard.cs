using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{
    public GameObject scoreBox;
    public GameObject scoreList;
    // Start is called before the first frame update
    void Start()
    {
        Data[] datas = DataManager.Instance.GetSortedData();
        for(int i=0; i<datas.Length; i++)
        {
            Debug.Log(datas[i].name+datas[i].score);
            GameObject score = Instantiate(scoreBox);
            score.transform.GetChild(0).GetComponent<Text>().text = datas[i].name+" : "+datas[i].score;
            score.transform.SetParent(scoreList.transform);
        }
        
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
     
}
