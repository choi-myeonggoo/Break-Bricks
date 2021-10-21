using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    List<Data> savedData = new List<Data>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        if(LoadData() != null) savedData.AddRange(LoadData());
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Data CreateSubObject(string name, int score)
    {
        Data newData = new Data();
        newData.name = name;
        newData.score = score;
        return newData;
    }
 
    public void SaveData(string name, int score)
    {
        //don't save lower score than previous of same player
        if (savedData.Exists(x => x.name == name && x.score >= score)) return;
        //remove previous score of same player
        savedData.Remove(savedData.Find(x => x.name == name));
        //save new score of same player
        savedData.Add(CreateSubObject(name, score));
        string json = JsonHelper.ToJson<Data>(savedData.ToArray());
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public Data[] LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data[] data = JsonHelper.FromJson<Data>(json);
            return data;
        }
        return null;
    }
    public Data GetLastPlayer()
    {
        if (savedData.Count == 0) return CreateSubObject("", 0);
        return savedData[savedData.Count - 1]; ;
    }
    public Data GetHighestScorer()
    {
        if (savedData.Count == 0) return CreateSubObject("", 0);
        int maxScoreIdx = 0;
        for (int i = 0; i < savedData.Count - 1; i++)
        {
            if (savedData[i].score > savedData[maxScoreIdx].score) maxScoreIdx = i;
        }
        return savedData[maxScoreIdx];
    }
    public Data[] GetSortedData()
    {
        savedData.Sort();
        return savedData.ToArray();
    }
}
