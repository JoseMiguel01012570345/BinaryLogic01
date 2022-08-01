namespace Tree;
public class TrueTable//table that contain all the possible interpretations values for the literals
{
    public List<char> literals = new List<char>();
    List<char> AllVariables = new List<char>();
    public List<int[]> Interpretation = new List<int[]>();
    public List<int> resoult = new List<int>();
    MiniTree Storing = new MiniTree();
    BuildTree Store;
    /////////////////////////////////////////////////////////////////////////////
    public TrueTable(BuildTree Store)
    {
        AllVariables = Store.Literals;
        this.literals = UnUsefull(AllVariables);
        this.Store = Store;
        M.Interpretate(0, this.Storing, literals.Count);//interpretate formula
        M.StoreInterpretation(0, this.Storing, new int[literals.Count], literals.Count);//store interpretation
        Interpretation = M.Interpretation;
        Evaluator(Store);
    }
    /////////////////////////////////////////////////////////////////////////////
    List<char> UnUsefull(List<char> literals)
    {
        for (int i = 0; i < literals.Count; i++)
        {
            for (int j = i + 1; j < literals.Count; j++)
            {
                if (literals[i] == literals[j])
                {
                    literals.RemoveAt(j); j--;
                }
            }
        }
        return literals;
    }
    /////////////////////////////////////////////////////////////////////////////
    void Evaluator(BuildTree Store)
    {
        StoreTree copy = new StoreTree(' ');
        for (int i = 0; i < Interpretation.Count; i++)
        {
            int[] values = ValuesForLiterals(i);
            Store.Store = GiveValuesToLiterals(Store.Store, values);//fase one: give values to literals
            copy = CopyByValue(Store.Store, copy);
            resoult.Add(FormulaInterpretated(copy).FormulaVALUE);//conseguir los valores de una interpretacion
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    StoreTree CopyByValue(StoreTree original, StoreTree copy)
    {
        copy.FormulaVALUE = original.FormulaVALUE;
        copy.literal = original.literal;
        copy.ValueLeftMember = original.ValueLeftMember;
        copy.ValueRightMember = original.ValueRightMember;
        copy.operacion = original.operacion;
        if (original.LeftMember != null)
        {
            copy.LeftMember = new StoreTree(original.operacion);
            CopyByValue(original.LeftMember, copy.LeftMember);
        }
        if (original.RightMember != null)
        {
            copy.RightMember = new StoreTree(original.operacion);
            CopyByValue(original.RightMember, copy.RightMember);
        }
        return copy;
    }
    /////////////////////////////////////////////////////////////////////////////
    StoreTree FormulaInterpretated(StoreTree tree)//interpretamos la formula
    {
        if (tree.LeftMember != null && tree.LeftMember.FormulaVALUE != int.MaxValue)//si el valor de la formula existe
            tree.ValueLeftMember = tree.LeftMember.FormulaVALUE;
        else//en caso contrario seguimos buscando
        {
            if (tree.LeftMember != null)
                tree.LeftMember = FormulaInterpretated(tree.LeftMember);
            if (tree.LeftMember != null && tree.LeftMember.FormulaVALUE != int.MaxValue)//si el valor de la formula existe
                tree.ValueLeftMember = tree.LeftMember.FormulaVALUE;
        }
        ////////////////////////////////////////////////////////////////////////////
        if (tree.RightMember != null && tree.RightMember.FormulaVALUE != int.MaxValue)//si el valor de la formula existe
            tree.ValueRightMember = tree.RightMember.FormulaVALUE;
        else//seguimos buscando
        {
            if (tree.RightMember != null)
                tree.RightMember = FormulaInterpretated(tree.RightMember);
            if (tree.RightMember != null && tree.RightMember.FormulaVALUE != int.MaxValue)//si el valor de la formula existe
                tree.ValueRightMember = tree.RightMember.FormulaVALUE;
        }
        tree.Opearte();//si tenemos los valores entonces efectuamos la operacion
        return tree;
    }
    /////////////////////////////////////////////////////////////////////////////
    int[] ValuesForLiterals(int i)//get the array of values by literal
    {
        int[] values = new int[AllVariables.Count];
        for (int j = 0; j < Interpretation[i].Length; j++)
        {
            values[j] = Interpretation[i][j];

            List<int> x = Indexes(AllVariables[j], AllVariables, j + 1);//verificar las ocurencias de una misma variable
            if (x.Count != 0)
                for (int z = 0; z < x.Count; z++)
                    values[z] = Interpretation[i][j];
        }
        return values;
    }
    /////////////////////////////////////////////////////////////////////////////
    StoreTree GiveValuesToLiterals(StoreTree Store, int[] values)//travel till find a literal and give its value
    {
        if (char.IsLetter(Store.literal))
        {
            int index = AllVariables.IndexOf(Store.literal);
            Store.FormulaVALUE = values[index];
            return Store;
        }
        if (Store.LeftMember != null)
            Store.LeftMember = GiveValuesToLiterals(Store.LeftMember, values);
        if (Store.RightMember != null)
            Store.RightMember = GiveValuesToLiterals(Store.RightMember, values);

        return Store;
    }
    /////////////////////////////////////////////////////////////////////////////
    List<int> Indexes(char a, List<char> AllLiterals, int start)//devuelve los indices en los que se encuntran el char a en el grupo de variables
    {
        List<int> aux = new List<int>();
        for (int i = start; i < AllLiterals.Count; i++)
            if (AllLiterals[i] == a)
                aux.Add(i);

        return aux;
    }
    /////////////////////////////////////////////////////////////////////////////
}