# ProiectTestare
## 1)Should send successfully a contact message
Intru pe pagina si accesez din nav Contact care va deschide un modal, completez formular si dupa ce ii dau submit primesc un alert. Fac assert la mesajul primit.
## 2)Should add an product to cart
Intru pe pagina principala de unde utilizand lista de elemente selectez unul dupa titlu si accesez pagina aferenta acestuia. Pe pagina produsului dau click pe butonul Add to Cart.
Fac assert la mesajul primit din alert.
## 3)Should add multiple products to cart
Similar cu cel anterior, doar ca include cativa pasi suplimentari. Dupa adaugarea primului produs navighez la pagina principala si repet actiunea pentru inca unul. Dupa ce 
il adaug pe cel de-al doilea utilizand meniul voi naviga catre pagina Cart. Iar in cart fac un assert pentru a confirma ca sunt 2 produse.
## 4)Should delete a product from cart
Repeta actiunile celui de mai sus, doar ca dupa ce ajunge in cart, va accesa butonul de delete al unui produs(dupa titlu) si va face assert la numarul de produse. Initial 2 
dupa stergere 1.
## 5)Should recalculate total amount after deleting a product
Similar cu cel anterior. Doar ca foloseste elemente suplimentare: pretului produsului care va fi sters si pretul total. Fac assert la totalul nou, trebuie sa fie egal cu 
totalul vechi - pretului produsului sters.
## 6)Should not be able to place order without name
Intru pe pagina si accesez din menu pagin Cart (din fericire nu e nevoie sa fii logat si nici sa ai produse in cart pentru a plasa comanda :)) ) Click pe butonul de plasare a 
comenzii, dupa care completez campurile, mai putin cel pentru name, si dau submit. Fac assert la mesajul din alert.
## 7)Should place order
Similar cu cel anterior, doar ca completez toate campurile corespunzator si voi primi un mesaj de succes pe care il voi folosi pentru assert.
## 8)Should login successfully
Intru pe pagina si deschid din menu modalul corespunzator pentru login. completez cu credentiale valide si fac assert dupa un element de meniu disponibil doar pentru utilizatorii
logati.
## 9)Should register successfully
Intru pe pagina si deschid din menu modalul corespunzator pentru register. Credentialele sunt generate random (string cu lungime de 12). Fac assert la mesajul primit.
