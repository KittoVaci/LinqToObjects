# LinqToObjects
## Zadání
Zadání bylo doplnit volání LinQ na předpřipravenou "Databázi" a vytáhnout z ní data podle zadání 1-7.C
## Řešení
Až na 6. a 7. zadání je vše celkem přimočaré.
U 6. a 7. se musel používat zanořený from a z něj brát výsledky, aby se dosáhlo i opakování
6B a 7B se dali udělat jednoduše z 6 resp. 7 jen pomocí .Distinct(), ale tohle řešení se mi nelíbí z několika důvodů:
1) Jakmile je chyba v jednom, tak ani to druhé nefunguje.
2) řešení 6B nemůže být jednoduše přesunoto někam jinam a musel by se s ním kopírovat i řešení 6. (7 resp.)
3) řešení 6B je na první pohled intuitivnější a více přimočaré, takže se k němu dá kdykoliv vrátit a upravit ho...
4) Kdyby se zadání 6B (7B resp.) změnilo, tak se jednoduše může stát, že řešení 6 nám nepomůže a tedy 6B by nebylo rozšiřovatelné jednoduše.
5) Kdyby se změnilo zadání 6 (7 resp.) tak, že by se omezili nějaké výsledky (třeba, že ty osoby musí být starší 20 let), tak se změní rovnou i řešení 6B, byť by zadání zůstalo stejné.
