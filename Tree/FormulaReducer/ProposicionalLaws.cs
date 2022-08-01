namespace Tree;
public static class ProposicionalLaws
{
    public static List<char> formulaReduced = new List<char>();

    public static List<char> Reduce(List<char> ReduceMe)
    {
        Law1(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law2(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law3(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law4(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law5(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law6(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law7(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law8(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law9(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law10(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law11(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law12(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law15(ReduceMe);
        Law16(ReduceMe);
        Law13(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law14(ReduceMe);
        if (formulaReduced.Count != 0) return formulaReduced;
        Law17(ReduceMe);
        return formulaReduced;
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law1(List<char> formula)//recives:A∨A returns:A
    {
        if (formula.Count == 3)// A∨A
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∨' && formula[0] == formula[2])
            {
                //A
                formulaReduced.Add(formula[0]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law2(List<char> formula)//recives:A∧A returns:A
    {
        if (formula.Count == 3)//A∧A
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∧' && formula[0] == formula[2])
            {
                //A
                formulaReduced.Add(formula[0]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law3(List<char> formula)//recives:A∧0 returns:0
    {
        if (formula.Count == 3)//A∧0
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∧' && formula[2] == 0)
            {
                //0
                formulaReduced.Add('0');
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law4(List<char> formula)//recives:A∨0 returns:A
    {
        if (formula.Count == 3)//A∨0
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∨' && formula[2] == 0)
            {
                //A
                formulaReduced.Add(formula[0]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law5(List<char> formula)//recives:A∧1 returns:A
    {
        if (formula.Count == 3)//A∧1
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∧' && formula[2] == 1)
            {
                //A
                formulaReduced.Add(formula[0]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law6(List<char> formula)//recives:A∧¬A returns:0
    {
        if (formula.Count == 4)//A∧¬A
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∧' &&
             formula[2] == '¬' && formula[0] == formula[3])
            {
                //0
                formulaReduced.Add('0');
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law7(List<char> formula)//recives:A∨¬A returns:1
    {
        if (formula.Count == 4)//A∨¬A
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∨' &&
             formula[2] == '¬' && formula[0] == formula[3])
            {
                //1
                formulaReduced.Add('1');
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law8(List<char> formula)//recives:¬[¬A] returns:A
    {
        if (formula.Count == 5)//¬[¬A]
        {
            if (formula[0] == '¬' && formula[1] == '[' &&
             formula[2] == '¬' && char.IsLetter(formula[3]) && formula[4] == ']')
            {
                //A
                formulaReduced.Add(formula[3]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law9(List<char> formula)//recives:¬1 returns:0
    {
        if (formula.Count == 2)//¬1
        {
            if (formula[0] == '¬' && formula[1] == '1')
            {
                //0
                formulaReduced.Add('0');
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law10(List<char> formula)//recives:0 returns:1
    {
        if (formula.Count == 2)//¬0
        {
            if (formula[0] == '¬' && formula[1] == '0')
            {
                //1
                formulaReduced.Add('1');
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law11(List<char> formula)//recives:¬[A∨B] returns:¬A∧¬B
    {
        if (formula.Count == 6)//¬[A∨B]
        {
            if (formula[0] == '¬' && formula[1] == '[' &&
             char.IsLetter(formula[2]) && formula[3] == '∨'
             && char.IsLetter(formula[4]) && formula[4] == ']')
            {
                //¬A∧¬B
                formulaReduced.Add('¬');
                formulaReduced.Add(formula[2]);
                formulaReduced.Add('∧');
                formulaReduced.Add('¬');
                formulaReduced.Add(formula[4]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law12(List<char> formula)//recives:¬[A∧B] returns:¬A∨¬B
    {
        if (formula.Count == 6)//¬[A∧B]
        {
            if (formula[0] == '¬' && formula[1] == '[' &&
             char.IsLetter(formula[2]) && formula[3] == '∧' &&
              char.IsLetter(formula[4]) && formula[4] == ']')
            {
                //¬A∨¬B
                formulaReduced.Add('¬');
                formulaReduced.Add(formula[2]);
                formulaReduced.Add('∨');
                formulaReduced.Add('¬');
                formulaReduced.Add(formula[4]);
                return;
            }
        }
    }
    ////////////////////////////////////////////////////////////////////////////
    static void Law13(List<char> formula)//recives:A∨[A∧B] returns:A
    {
        if (formula.Count == 8)//A∨[A∧B]
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∨' &&
             formula[2] == '[' && formula[0] == formula[3] &&
              formula[4] == '∧' && char.IsLetter(formula[4]) && formula[5] == ']')
            {
                //A
                formulaReduced.Add(formula[0]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law14(List<char> formula)//recives:A∧[A∨B] returns: A
    {
        if (formula.Count == 8)//A∧[A∨B]
        {
            if (char.IsLetter(formula[0]) && formula[1] == '∧' &&
             formula[2] == '[' && formula[0] == formula[3] &&
             formula[4] == '∨' && char.IsLetter(formula[4]) && formula[5] == ']')
            {
                //A
                formulaReduced.Add(formula[0]);
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law15(List<char> formula)//recives:[A∨B]∧[A∨C] returns: A∨[B∧C]
    {
        if (formula.Count == 10)//[A∨B]∧[A∨C]
        {
            if (formula[0] == '[' && char.IsLetter(formula[1]) &&
             formula[2] == '∨' && char.IsLetter(formula[3]) &&
              formula[4] == ']' && formula[5] == '∧' && formula[6] == '[' && formula[1] == formula[7] &&
             formula[8] == '∨' && char.IsLetter(formula[9]) &&
              formula[10] == ']')
            {
                //A∨[B∧C]
                formulaReduced.Add(formula[1]);
                formulaReduced.Add('∨');
                formulaReduced.Add('[');
                formulaReduced.Add(formula[3]);
                formulaReduced.Add('∧');
                formulaReduced.Add(formula[9]);
                formulaReduced.Add(']');
                return;
            }
        }
    }
    /////////////////////////////////////////////////////////////////////////////
    static void Law16(List<char> formula)//recives:[A∨∧B]∨[A∧C] returns: A∧[B∨C]
    {
        if (formula.Count == 10)//[A∨∧B]∨[A∧C]
        {
            if (formula[0] == '[' && char.IsLetter(formula[1]) &&
             formula[2] == '∧' && char.IsLetter(formula[3]) &&
              formula[4] == ']' && formula[5] == '∨' && formula[6] == '[' && formula[1] == formula[7] &&
             formula[8] == '∧' && char.IsLetter(formula[9]) &&
              formula[10] == ']')
            {
                //A∧[B∨C]
                formulaReduced.Add(formula[1]);
                formulaReduced.Add('∧');
                formulaReduced.Add('[');
                formulaReduced.Add(formula[3]);
                formulaReduced.Add('∨');
                formulaReduced.Add(formula[9]);
                formulaReduced.Add(']');
                return;
            }
        }
    }
    static void Law17(List<char> formula)
    {
        int count = 0;
        for (int i = 0; i < formula.Count; i++)
        {
            if (char.IsLetter(formula[i])) count++;
        }
        if (count == 1)
        {
            formulaReduced = formula;
            return;
        }
    }
}
/////////////////////////////////////////////////////////////////////////////