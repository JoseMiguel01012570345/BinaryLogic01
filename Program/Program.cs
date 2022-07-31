using Tree
;

//⇔ ⇒ ∨ ∧ ¬
string s = "[¬q]⇔[p∧q]";
ConvertToFN x = new ConvertToFN(s.ToCharArray().ToList());

// Brakets bra = new Brakets(s.ToCharArray().ToList());

// BuildTree B = new BuildTree(bra.formula);
// TrueTable A = new TrueTable(B);
// NominalFormula C = new NominalFormula(A);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
//Console.WriteLine("Su Formula es {0} y su forma nominal es:", s);


for (int i = 0; i < x.formula.Count; i++)
    Console.Write(x.formula[i]);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();