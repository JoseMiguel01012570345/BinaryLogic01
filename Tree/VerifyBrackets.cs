namespace Tree;
public class Checker
{
    public bool InOrder { get; private set; }
    List<char> brackets = new List<char>();
    List<List<char>> BRACKETS = new List<List<char>>();
    int count = 0;
    /////////////////////////////////////////////////////////////////////////////
    public Checker(string query)
    {
        InOrder = true;
        CheckBrackets(query);
        AllRight(0, 0);
        Comparer();
    }
    /////////////////////////////////////////////////////////////////////////////
    void Comparer()//determines if a formula is right under criteria of its brackets
    {
        for (int i = 0; i < BRACKETS.Count; i++)
        {
            if (BRACKETS[i].Count < 2)//Every pair should be in the form "[]" otherwise the formula is not true
            {
                InOrder = false;
                return;
            }
        }
        if (BRACKETS.Count * 2 != brackets.Count)
        {
            //if the number of pair"[]" by two is diferent from the the number of brackets in the formula then it is not right
            InOrder = false;
            return;
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    void CheckBrackets(string query)//the number of  open brackets should be the same of closed brackets.Lets get the opened and cloused ones
    {
        for (int i = 0; i < query.Length; i++)
            if (query.ToCharArray()[i] == '[' || query.ToCharArray()[i] == ']') brackets.Add(query[i]);
    }
    /////////////////////////////////////////////////////////////////////////////
    void AllRight(int current, int state)
    {
        for (int i = current; i < brackets.Count; i++)
        {
            count = i;
            if (brackets[i] == '[')
            {
                BRACKETS.Insert(0, new List<char>());
                BRACKETS[0].Add('[');
                AllRight(i + 1, BRACKETS.Count);
                i = count;
            }
            else
            {
                if (BRACKETS.Count - state >= 0 && BRACKETS.Count - state < BRACKETS.Count)
                    BRACKETS[BRACKETS.Count - state].Add(']');
                count = i;
                return;
            }
        }
    }
}
/////////////////////////////////////////////////////////////////////////////