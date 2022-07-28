namespace Tree;
public class BuildTree
{
    public StoreTree Store = new StoreTree(' ');
    public List<char> Literals = new List<char>();
    public BuildTree(List<char> formula)
    {
        this.Store = StoreIntoTree(formula, this.Store, 0);
    }
    public StoreTree StoreIntoTree(List<char> Formula, StoreTree Store, int count)
    {
        if (Formula.Count == 1 && char.IsLetter(Formula[0]))//si es un literal llegamos al fondo
        {
            Store.literal = Formula[0];
            Literals.Add(Store.literal);
            return Store;
        }
        for (int i = 0; i < Formula.Count; i++)
        {
            if (Formula[i] == '[') { count++; continue; }
            if (Formula[i] == ']') { count--; continue; }
            if (Formula[i] == '¬' && count == 0 && i == 0)//es necesario observar el caso del operador de negacion
            {
                if (Check(Formula))//verificamos si el operador de negacion encapsula a toda la formula
                {
                    //si es asi entonces le asignamos una rama
                    Store = new StoreTree(Formula[i]);
                    Formula.RemoveAt(0);
                    Store.LeftMember = StoreIntoTree(SubString(Formula, 0, Formula.Count), Store.LeftMember = new StoreTree(' '), count);
                    return Store;//y devolvemos
                }
            }
            if (count == 0 && (Formula[i] == '⇔' || Formula[i] == '⇒' || Formula[i] == '∨' || Formula[i] == '∧'))//evaluar el resto de los operadores
            {
                if ((Formula[i - 1] == ']') && (Formula[i + 1] == '['))
                {
                    Store = new StoreTree(Formula[i]);
                    Store.LeftMember = StoreIntoTree(SubString(Formula, 0, i), Store.LeftMember = new StoreTree(' '), count);//asignamos el miembro izquierdo
                    Store.RightMember = StoreIntoTree(SubString(Formula, i + 1, Formula.Count), Store.RightMember = new StoreTree(' '), count);//asignamos el miembro derecho

                    return Store;//y devolvemos
                }
            }
        }
        return Store;
    }
    bool Check(List<char> Formula)
    {
        int count = 0;
        if (Formula[1] == '[')
        {
            count++;
            for (int i = 2; i < Formula.Count; i++)
            {
                if (Formula[i] == '[') { count++; continue; }
                if (Formula[i] == ']') { count--; continue; }
                if ((count == 0) && (i != Formula.Count - 1)) return false;
            }
        }
        return true;
    }
    List<char> SubString(List<char> formula, int start, int finish)
    {
        List<char> C = new List<char>();
        if (formula[start] == '[') { start += 1; finish -= 1; }
        for (int i = start; i < finish; i++)
        {
            C.Add(formula[i]);
        }
        return C;
    }
}
public class StoreTree
{
    public char literal;//si no es null entonces LeftMember y RightMember son nulos
    public int FormulaVALUE = int.MaxValue;
    public StoreTree LeftMember;
    public int ValueLeftMember = int.MaxValue;
    public StoreTree RightMember;
    public int ValueRightMember = int.MaxValue;
    public char operacion;
    public StoreTree(char operacion)
    {
        this.operacion = operacion;
    }
    public void Opearte()
    {
        if (ValueLeftMember != int.MaxValue && ValueRightMember != int.MaxValue)
        {
            if (operacion == '∧') FormulaVALUE = Operations.AND(ValueLeftMember, ValueRightMember);
            if (operacion == '∨') FormulaVALUE = Operations.OR(ValueLeftMember, ValueRightMember);
            if (operacion == '⇒') FormulaVALUE = Operations.Implication(ValueLeftMember, ValueRightMember);
            if (operacion == '⇔') FormulaVALUE = Operations.SSi(ValueLeftMember, ValueRightMember);
        }
        if (operacion == '¬') FormulaVALUE = Operations.Nor(ValueLeftMember, ValueRightMember);
    }
}
