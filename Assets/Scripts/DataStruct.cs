using System;

[System.Serializable]
public struct Data : IComparable<Data>
{
    public string name;
    public int score;
    public int CompareTo(Data other)
    {
        //when Call Sort, sort by score in descening order
        return other.score - this.score;
    }
}
