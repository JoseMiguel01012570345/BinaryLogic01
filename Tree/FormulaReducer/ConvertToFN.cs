namespace Tree;
public class ConvertToFN
{
    public List<char> formula = new List<char>();
    List<char> SSIFormula = new List<char>();
    List<char> ImplicationFormula = new List<char>();
    public ConvertToFN(List<char> formula)
    {
        this.formula = formula;
        DetectSymbols();
    }
    void DetectSymbols()//⇔ ⇒ ∨ ∧ ¬
    {
        for (int i = 0; i < formula.Count; i++)
        {
            List<char> LeftFormula = new List<char>();
            List<char> RightFormula = new List<char>();
            if (formula[i] == '⇔')
            {
                LeftFormula = GetLeftFormula(i);
                i -= LeftFormula.Count;
                RightFormula = GetRightFormula(i);
                GetFNFormSSI(LeftFormula, RightFormula);
                ConvertFormula(i);
                i = 0;
            }
            if (formula[i] == '⇒')
            {
                LeftFormula = GetLeftFormula(i);
                i -= LeftFormula.Count;
                RightFormula = GetRightFormula(i);
                GetFNFormImplication(LeftFormula, RightFormula);
                ConvertFormula(i);
                i = 0;
            }
        }
    }
    void ConvertFormula(int index)
    {
        if (formula[index] == '⇔')//si nos encotramos un ssi reemplazamos en FinalFormula
        {
            formula.RemoveAt(index);
            for (int j = 0; j < SSIFormula.Count; j++)
                formula.Insert(index + j, SSIFormula[j]);
        }
        if (formula[index] == '⇒')//si nos encotramos una implicacion reemplazamos en FinalFormula
        {
            formula.RemoveAt(index);
            for (int j = 0; j < ImplicationFormula.Count; j++)
                formula.Insert(index + j, ImplicationFormula[j]);
        }
    }
    List<char> GetLeftFormula(int index)
    {
        List<char> formulia = new List<char>();
        int Count = 0;

        if (formula[index - 1] == ']')
        {
            Count++;
            formulia.Insert(0, formula[index - 1]);
            formula.RemoveAt(index - 1);
            for (int i = index - 2; i >= 0; i--)
            {
                if (formula[i] == ']') Count++;
                if (formula[i] == '[') Count--;
                if (Count == 0)
                {
                    formulia.Insert(0, formula[i]);
                    formula.RemoveAt(i);
                    return formulia;
                }
                formulia.Insert(0, formula[i]);
                formula.RemoveAt(i);
            }
        }
        if (char.IsLetter(formula[index - 1]))
        {
            formulia.Add(formula[index - 1]);
            formula.RemoveAt(index - 1);
            return formulia;
        }
        return formulia;
    }
    List<char> GetRightFormula(int index)
    {
        int Count = 0;
        List<char> formulia = new List<char>();

        if (formula[index + 1] == '[')
        {
            Count++;
            formulia.Add(formula[index + 1]);
            formula.RemoveAt(index + 1);
            for (int i = index + 1; i <= formula.Count; i++)
            {
                if (formula[i] == ']') Count--;
                if (formula[i] == '[') Count++;
                if (Count == 0)
                {
                    formulia.Add(formula[i]);
                    formula.RemoveAt(i);
                    return formulia;
                }
                formulia.Add(formula[i]);
                formula.RemoveAt(i);
                i--;
            }
        }
        if (char.IsLetter(formula[index + 1]))
        {
            formulia.Add(formula[index + 1]);
            formula.RemoveAt(index + 1);
            return formulia;
        }
        return formulia;
    }
    void GetFNFormImplication(List<char> A, List<char> B)//⇔ ⇒ ∨ ∧ ¬
    {
        ImplicationFormula.Add('¬');
        for (int i = 0; i < A.Count; i++)
            ImplicationFormula.Add(A[i]);

        ImplicationFormula.Add('∨');
        for (int i = 0; i < B.Count; i++)
            ImplicationFormula.Add(B[i]);
    }
    void GetFNFormSSI(List<char> A, List<char> B)
    {
        SSIFormula.Add('[');
        SSIFormula.Add('¬');
        //formula A
        for (int i = 0; i < A.Count; i++)
            SSIFormula.Add(A[i]);

        SSIFormula.Add('∨');
        //formula B
        for (int i = 0; i < B.Count; i++)
            SSIFormula.Add(B[i]);

        SSIFormula.Add(']');
        SSIFormula.Add('∧');
        SSIFormula.Add('[');
        SSIFormula.Add('¬');
        //formula B
        for (int i = 0; i < B.Count; i++)
            SSIFormula.Add(B[i]);

        SSIFormula.Add('∨');
        ////formula A
        for (int i = 0; i < A.Count; i++)
            SSIFormula.Add(A[i]);

        SSIFormula.Add(']');
    }
}