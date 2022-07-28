namespace Tree;
public class NominalFormula
{
    List<int> resoultVector = new List<int>();
    List<int[]> interpretations = new List<int[]>();
    List<char> Literals = new List<char>();
    public NominalFormula(TrueTable table)
    {
        resoultVector = table.resoult;
        this.interpretations = table.Interpretation;
        Literals = table.literals;
        FormulaChosing();
    }
    void FormulaChosing()
    {
        int zeros = 0;
        int ones = 0;
        for (int i = 0; i < resoultVector.Count; i++)
        {
            if (resoultVector[i] == 0) zeros++;
            else ones++;
        }
        if (zeros >= ones) CreateFND();
        else CreateFND();
    }
    public List<char> formula = new List<char>();
    void CreateFNC()
    {
        for (int i = 0; i < resoultVector.Count; i++)
        {
            if (resoultVector[i] == 0)
            {
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
        formula.RemoveAt(formula.Count - 1);
    }
    void CreateFND()
    {
        for (int i = 0; i < resoultVector.Count; i++)
        {
            if (resoultVector[i] == 1)
            {
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
        formula.RemoveAt(formula.Count - 1);
    }
}