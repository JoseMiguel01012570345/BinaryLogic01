namespace Tree;
public static class M
{
    public static List<int[]> Interpretation = new List<int[]>();
    /////////////////////////////////////////////////////////////////////////////
    public static MiniTree Interpretate(int interator, MiniTree mini, int literalsLenght)//build a tree of interpretations
    {
        if (literalsLenght == 0) return mini;

        if (interator == literalsLenght - 1)
        {
            mini.left = new MiniTree();
            mini.right = new MiniTree();
            return mini;
        }
        mini.left = Interpretate(interator += 1, mini.left = new MiniTree(), literalsLenght);
        interator -= 1;
        mini.right = Interpretate(interator += 1, mini.right = new MiniTree(), literalsLenght);
        return mini;
    }
    /////////////////////////////////////////////////////////////////////////////
    static public void StoreInterpretation(int iterator, MiniTree tree, int[] row, int literalsLenght)//stores the interpretations considered at a MiniTree object in matrix
    {
        //caso base
        if (iterator == literalsLenght)
        {
            if (Interpretation.Contains(row)) return;
            Interpretation.Add(row);
            return;
        }
        if (tree.left != null)
        {
            row[iterator] = 1;
            int[] aux = new int[row.Length];
            row.CopyTo(aux, 0);
            StoreInterpretation(iterator += 1, tree.left, aux, literalsLenght);
            iterator -= 1;
        }
        if (tree.right != null)
        {
            row[iterator] = 0;
            int[] aux = new int[row.Length];
            row.CopyTo(aux, 0);
            StoreInterpretation(iterator += 1, tree.right, aux, literalsLenght);
        }
        return;
    }
}/////////////////////////////////////////////////////////////////////////////