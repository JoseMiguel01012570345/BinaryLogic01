namespace Tree;
public static class Operations

{
    /////////////////////////////////////////////////////////////////////////////
    public static int Nor(int valor1, int valor2)
    {
        if (valor1 == int.MaxValue && valor2 != int.MaxValue) return (valor2 == 1) ? valor2 = 0 : valor2 = 1;
        if (valor2 == int.MaxValue && valor1 != int.MaxValue) return (valor1 == 1) ? valor1 = 0 : valor1 = 1;

        return 0;
    }
    /////////////////////////////////////////////////////////////////////////////
    public static int SSi(int valor1, int valor2)
    {
        if (valor1 == 0 && valor2 == 0) return 1;
        if (valor1 == 1 && valor2 == 1) return 1;
        if (valor1 == 1 && valor2 == 0) return 0;
        if (valor1 == 0 && valor2 == 1) return 0;
        return 0;
    }
    /////////////////////////////////////////////////////////////////////////////
    public static int Implication(int valor1, int valor2)
    {
        if (valor1 == 0 && valor2 == 0) return 1;
        if (valor1 == 1 && valor2 == 1) return 1;
        if (valor1 == 1 && valor2 == 0) return 0;
        if (valor1 == 0 && valor2 == 1) return 1;
        return 0;
    }
    /////////////////////////////////////////////////////////////////////////////
    public static int AND(int valor1, int valor2)
    {
        if (valor1 == 1 && valor2 == 1) return 1;

        return 0;
    }
    /////////////////////////////////////////////////////////////////////////////
    public static int OR(int valor1, int valor2)
    {
        if (valor1 == 1 || valor2 == 1) return 1;

        return 0;
    }
}
/////////////////////////////////////////////////////////////////////////////
