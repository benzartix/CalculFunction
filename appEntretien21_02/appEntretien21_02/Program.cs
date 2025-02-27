using CalculFonctionQuadratique;
using CalculFonctionQuadratique.Core.Calcul;
using CalculFonctionQuadratique.Core.Parsing;
using System;

//IApply app = new Apply();
//Console.WriteLine(app.ApplyFunction("const(x)=42", 4));
//Console.WriteLine(app.ApplyFunction("f(x)=2x^2+x+1", 4));
//Console.WriteLine(app.ApplyFunction("square(x)=x^2", 4));
//Console.WriteLine(app.ApplyFunction("func(x)=5x^2-7", 4));
//Console.WriteLine(app.ApplyFunction("linear(x)=-24x+9", 4));
//Console.WriteLine(app.ApplyFunction("large(x)=999x^2-998x+997", 4));
//Console.WriteLine(app.ApplyFunction("g(x)=-4x^2+5x", 4));
//Console.WriteLine(app.ApplyFunction("ahmed(x)=28", 4));


IParsing parsing = new Parsing();
ICalcul calcul = new Calcul();
Apply apply = new Apply(parsing, calcul);

Console.WriteLine(apply.ApplyFunction("const(x)=42", 4));
Console.WriteLine(apply.ApplyFunction("f(x)=2x^2+x+1", 4));
Console.WriteLine(apply.ApplyFunction("square(x)=x^2", 4));
Console.WriteLine(apply.ApplyFunction("func(x)=5x^2-7", 4));
Console.WriteLine(apply.ApplyFunction("linear(x)=-24x+9", 4));
Console.WriteLine(apply.ApplyFunction("large(x)=999x^2-998x+997", 4));
Console.WriteLine(apply.ApplyFunction("g(x)=-4x^2+5x", 4));
Console.WriteLine(apply.ApplyFunction("ahmed(x)=28", 4));




Console.ReadKey();