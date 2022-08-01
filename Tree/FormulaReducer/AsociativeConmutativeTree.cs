namespace Tree;

public class Reducer
{
    char operation = ' ';
    List<List<char>> FNominal = new List<List<char>>();
    NominalFormula FN;
    public string formulaNominal = "";
    /////////////////////////////////////////////////////////////////////////////
    public Reducer(NominalFormula FN)
    {
        operation = FN.operation;
        this.FN = FN;
        ReduceInterpretations();
        GetMatrix();
        Optimizar(false);
        BuildConjuntiveFormula();
        BuildDisjuntiveFormula();
    }
    /////////////////////////////////////////////////////////////////////////////
    void ReduceInterpretations()
    {
        if (operation == '∨')
        {
            for (int i = 0; i < FN.resoultVector.Count; i++)
            {
                if (FN.resoultVector[i] == 0)
                {
                    FN.interpretations.RemoveAt(i);
                    FN.resoultVector.RemoveAt(i);
                    i--;
                }
            }
        }
        if (operation == '∧')
        {
            for (int i = 0; i < FN.resoultVector.Count; i++)
            {
                if (FN.resoultVector[i] == 1)
                {
                    FN.interpretations.RemoveAt(i);
                    FN.resoultVector.RemoveAt(i);
                    i--;
                }
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    void GetMatrix()
    {
        if (FN.operation == '∧')
        {
            for (int i = 0; i < FN.interpretations.Count; i++)
            {
                for (int j = 0; j < FN.interpretations[i].Length; j++)
                {
                    if (FN.interpretations[i][j] == 1) FN.interpretations[i][j] = 0;
                    else FN.interpretations[i][j] = 1;
                }
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////    
    void Optimizar(bool reduced)
    {
        int diference = 0;
        int index = -1;
        for (int i = 0; i < FN.interpretations.Count; i++)
        {
            for (int j = i + 1; j < FN.interpretations.Count; j++)
            {
                for (int x = 0; x < FN.interpretations[j].Length; x++)
                {
                    if (FN.interpretations[i][x] != FN.interpretations[j][x])
                    {
                        diference++;
                        index = x;
                    }
                    if (diference > 1) { index = -1; break; }
                }
                diference = 0;
                if (index != -1)//si la diferencia es uno entonces podemos reducir la formula
                {
                    reduced = true;
                    FN.interpretations[i][index] = -1;
                    FN.interpretations.RemoveAt(j);
                    j--;
                }
            }
        }
        if (reduced == true) Optimizar(false);//Si no se redujo la formula es porque esta es la mas simplificada
    }
    /////////////////////////////////////////////////////////////////////////////
    void BuildDisjuntiveFormula()//⇔ ⇒ ∨ ∧ ¬
    {
        if (operation == '∨')
            for (int i = 0; i < FN.interpretations.Count; i++)
            {
                formulaNominal += "[";
                for (int j = 0; j < FN.interpretations[i].Length; j++)
                {
                    if (FN.interpretations[i][j] == -1) continue;

                    if (FN.interpretations[i][j] == 1)
                        if (char.IsLetter(formulaNominal[formulaNominal.Length - 1])) formulaNominal += "∧" + FN.Literals[j];
                        else formulaNominal += FN.Literals[j];

                    if (FN.interpretations[i][j] == 0)
                    {
                        if (char.IsLetter(formulaNominal[formulaNominal.Length - 1])) formulaNominal += "∧" + "¬" + FN.Literals[j];
                        else formulaNominal += "¬" + FN.Literals[j];
                    }
                }
                if (i != FN.interpretations.Count - 1) { formulaNominal += "]" + operation; continue; }
                formulaNominal += "]";
            }
    }
    /////////////////////////////////////////////////////////////////////////////
    void BuildConjuntiveFormula()
    {
        if (operation == '∧')
            for (int i = 0; i < FN.interpretations.Count; i++)
            {
                formulaNominal += "[";
                for (int j = 0; j < FN.interpretations[i].Length; j++)
                {
                    if (FN.interpretations[i][j] == -1) continue;

                    if (FN.interpretations[i][j] == 1)
                        if (char.IsLetter(formulaNominal[formulaNominal.Length - 1])) formulaNominal += "∨" + FN.Literals[j];
                        else formulaNominal += FN.Literals[j];

                    if (FN.interpretations[i][j] == 0)
                    {
                        if (char.IsLetter(formulaNominal[formulaNominal.Length - 1])) formulaNominal += "∨" + "¬" + FN.Literals[j];
                        else formulaNominal += "¬" + FN.Literals[j];
                    }
                }
                if (i != FN.interpretations.Count - 1) { formulaNominal += "]" + operation; continue; }
                formulaNominal += "]";
            }
    }
}/////////////////////////////////////////////////////////////////////////////