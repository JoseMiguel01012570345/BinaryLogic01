namespace Tree;
public class Brakets
{
    public List<char> formula = new List<char>();
    /////////////////////////////////////////////////////////////////////////////
    public Brakets(List<char> formula)
    {
        this.formula = formula;

        PutBrackets();
        if (this.formula.Count == 0) return;
    }
    /////////////////////////////////////////////////////////////////////////////
    void PutBrackets()
    {
        for (int i = 0; i < formula.Count; i++)
        {
            try
            {
                if (char.IsLetter(formula[i]))
                {
                    if (i - 1 >= 0 && i + 1 < formula.Count && formula[i - 1] == '[' && formula[i + 1] == ']') continue;
                    if (i - 1 >= 0 && i + 1 < formula.Count && formula[i - 1] == '[' && formula[i - 1] == '¬')
                    {
                        formula.Insert(i - 1, '[');
                        formula.Insert(i + 2, ']');
                        i += 2;
                        continue;
                    }
                    formula.Insert(i, '[');
                    formula.Insert(i + 2, ']');
                    i++;
                    continue;
                }
            }
            catch (Exception e)
            {
                if (e.GetType().ToString() == "System.ArgumentOutOfRangeException")
                {
                    formula = new List<char>();
                    return;
                }
            }
        }
    }
}
/////////////////////////////////////////////////////////////////////////////