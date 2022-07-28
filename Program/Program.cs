using Tree
;

//⇔ ⇒ ∨ ∧ ¬
string s = "p⇔q";
Brakets bra = new Brakets(s.ToCharArray().ToList());

BuildTree B = new BuildTree(bra.formula);
TrueTable A = new TrueTable(B);
NominalFormula C = new NominalFormula(A);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Su Formula es {0} y su forma nominal es:", s);

for (int i = 0; i < C.formula.Count; i++)
    Console.Write(C.formula[i]);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();