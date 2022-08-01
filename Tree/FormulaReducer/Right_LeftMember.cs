namespace Tree;
public class Braces
{
    List<char> formulia = new List<char>();
    char B = '[';
    char NoB = ']';
    public List<string> formuliaList = new List<string>();
    int count0 = 0;
    /////////////////////////////////////////////////////////////////////////////
    public Braces(List<char> Formula)
    {
        formulia = Formula;
        Brace(0, true, 0);
    }
    /////////////////////////////////////////////////////////////////////////////
    public void Brace(int count, bool var, int number)
    {
        string s = "";
        for (int i = count; i < formulia.Count; i++)
        {
            count0 = i;

            if (count0 < formulia.Count && formulia[count0] == NoB)//cerramos corchetes
            {
                if (s != "" && var == true)
                {
                    formuliaList.Add("");
                    formuliaList[formuliaList.Count - 1] += s;
                }
                else if (s != "" && var == false)
                {
                    formuliaList.Add("");
                    formuliaList[formuliaList.Count - 1] += s;
                }
                return;
            }
            if (count0 < formulia.Count && formulia[count0] == B)
            {
                if (formulia[count0] == B && count0 - 1 >= 0 && formulia[count0 - 1] == 'w')
                {
                    s += number + 1;
                    Brace(count0 + 1, true, number + 1);//abrimos corchetes
                }
                else if (formulia[count0] == B)
                {
                    if (count0 - 1 >= 0 && formulia[count0 - 1] == 'W')
                    {
                        s += number + 1;
                    }
                    Brace(count0 + 1, false, number + 1);
                }
                i = count0;
            }
            if (count0 < formulia.Count - 1 && formulia[count0] != B && formulia[count0] != NoB)//si no son corchetes sumamos
                s += formulia[count0];
        }
    }
}
/////////////////////////////////////////////////////////////////////////////