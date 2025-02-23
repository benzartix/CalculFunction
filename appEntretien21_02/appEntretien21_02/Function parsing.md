## Synopsys

Pour une fonction polynome du second degrée donnée sous la forme <span style="border: 1px solid yellow; padding: 0 6px 0 6px;">f(x)=ax²+bx+c</span>, on souhaite calculer le résultat
de cette fonction pour une valeur de x.

Par exemple, pour la fonction <span style="border: 1px solid yellow; padding: 0 6px 0 6px;">simple(x)=x²+x+1</span>, et <span style="border: 1px solid yellow; padding: 0 6px 0 6px;">x=4</span>, le résultat attendu est 21.

Note : certains coefficients peuvent être manquants, comme dans cet exemple: <span style="border: 1px solid yellow; padding: 0 6px 0 6px;">linear(x)=-3x+2</span>

Implémentez la méthode <span style="border: 1px solid yellow; padding: 0 6px 0 6px;">int ApplyFunction(string quadraticfunction, int x)</span> qui prend une fonction polynome et une valeur x en paramètres et retourne la valeur de cette fonction pour cette valeur x.

#### Contraintes:
- -1000 <a,b,c,x< 1000
- Les produits du polynome sont toujours donnés dans le même ordre : les plus grands exposants d'abord. Par exemple <span style="border: 1px solid yellow; padding: 0 6px 0 6px;">k(x)=-2+3x-4x²</span> n'est pas un paramètre valide


### Cas de tests notables
- <span style="border: 1px solid yellow;">const(x)=42</span>
- <span style="border: 1px solid yellow;">f(x)=2x²+x+1</span>
- <span style="border: 1px solid yellow;">square(x)=x²</span>
- <span style="border: 1px solid yellow;">func(x)=5x²-7</span>
- <span style="border: 1px solid yellow;">linear(x)=-24x+9</span>
- <span style="border: 1px solid yellow;">large(x)=999x²-998x+997</span>
- <span style="border: 1px solid yellow;">g(x)=-4x²+5x</span>
- <span style="border: 1px solid yellow;">f(x)=ax²+bx+c</span>

