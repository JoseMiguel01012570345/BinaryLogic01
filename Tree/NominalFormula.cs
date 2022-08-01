namespace Tree;
public class NominalFormula
{
    public List<int> resoultVector = new List<int>();
    public List<int[]> interpretations = new List<int[]>();
    public List<char> formula = new List<char>();
    public List<char> Literals = new List<char>();
    public char operation = ' ';
    /////////////////////////////////////////////////////////////////////////////
    public NominalFormula(TrueTable table)
    {
        resoultVector = table.resoult;
        this.interpretations = table.Interpretation;
        Literals = table.literals;
        FormulaChosing();
    }
    /////////////////////////////////////////////////////////////////////////////
    void FormulaChosing()
    {
        int zeros = 0;
        int ones = 0;
        for (int i = 0; i < resoultVector.Count; i++)
        {
            if (resoultVector[i] == 0) zeros++;
            else ones++;
        }
        if (zeros >= ones) { operation = '∨'; CreateFND(); }
        else { operation = '∧'; CreateFNC(); }
    }
    /////////////////////////////////////////////////////////////////////////////
    void CreateFNC()
    {
        bool var = false;
        for (int i = 0; i < resoultVector.Count; i++)
        {
            if (resoultVector[i] == 0)
            {
                var = true;
                formula.Add('[');
                for (int j = 0; j < interpretations[i].Length; j++)
                {
                    if (interpretations[i][j] == 0)
                    {
                        formula.Add(Literals[j]);
                        formula.Add('∨');
                    }
                    else
                    {
                        formula.Add('¬');
                        formula.Add(Literals[j]);
                        formula.Add('∨');
                    }
                }
                formula.RemoveAt(formula.Count - 1);
                formula.Add(']');
                formula.Add('∧');
            }
        }
        if (var == true)
            formula.RemoveAt(formula.Count - 1);
    }
    /////////////////////////////////////////////////////////////////////////////
    void CreateFND()
    {
        bool var = false;
        for (int i = 0; i < resoultVector.Count; i++)
        {
            if (resoultVector[i] == 1)
            {
                var = true;
                formula.Add('[');
                for (int j = 0; j < interpretations[i].Length; j++)
                {
                    if (interpretations[i][j] == 1)
                    {
                        formula.Add(Literals[j]);//⇔ ⇒ ∨ ∧ ¬
                        formula.Add('∧');
                    }
                    else
                    {
                        formula.Add('¬');
                        formula.Add(Literals[j]);
                        formula.Add('∧');
                    }
                }
                formula.RemoveAt(formula.Count - 1);
                formula.Add(']');
                formula.Add('∨');
            }
        }
        if (var == true)
            formula.RemoveAt(formula.Count - 1);
    }
}
/////////////////////////////////////////////////////////////////////////////