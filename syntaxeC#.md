C# .cs

class chose {
	static void Main(string []args){
		Console.WriteLine("Hey");
	}
}

int a;
decimal b = 100;
float c = 3.14;
double = float avec + de possibilités

string chose;
#\n ou \t (tabulation)
# pour mettre des caractères spéciaux :
#	"c\'est beau" ou @"c'est beau"

string sautDeLigne = "\n";
Console.WriteLine("Passer" + sautDeLigne + "à" +
	sautDeLigne + "la" + sautDeLigne + "ligne");

Console.WriteLine("Passer" + Environment.NewLine + "à" + 
	Environment.NewLine + "la" + Environment.NewLine + "ligne");

# "" = string.Empty


bool estVrai;

+plein de plus précis

a += // a -= // a /=

double moy = 5/2;
-> va retourner 2
double moy = 5.0/2.0;
-> va retourner 2.5



--------------------------- CONVERSIONS - CAST --------------------------------------

# cast explicite
int i = 200;
short s = (short)i;


# ok
int i = 20;
double d = i;

double prix = 125.55;
int valeur = (int)prix; // valeur vaut 125

# string to int
string chaineAge = "20";
int age = Convert.ToInt32(chaineAge); // age vaut 20
# ou
string chaineAge = "20";
int age = int.Parse(chaineAge); // age vaut 20
# ou try parse
int age;
if (int.TryParse("hey20d", out age))
{
    Console.WriteLine("La conversion est possible, age vaut " + age);
}
else
{
    Console.WriteLine("Conversion impossible");
}
-> conversion impossible





--------------------------- READ CONSOLE --------------------------------------

string truc = Console.ReadLine(); -> on lit jusqu'à un appui sur entrée

bool ageIsValid = false;
int age = -1;
while (!ageIsValid)
{
    Console.WriteLine("Veuillez saisir votre age");
    string saisie = Console.ReadLine();
    if (int.TryParse(saisie, out age))
        ageIsValid = true;
    else
    {
        ageIsValid = false;
        Console.WriteLine("L'age que vous avez saisi est incorrect ...");
    }
}
Console.WriteLine("Votre âge est de : " + age);




Console.ReadKey(true); -> un seul caractère / avec true ce que l'on tape ne va pas apparaître à l'écran
EXEMPLE :
Console.WriteLine("Veuillez appuyer sur une touche pour démarrer le calcul ...");
Console.ReadKey(true);
-> ce que l'on met après va attendre l'appui sur une touche


Console.WriteLine("Voulez-vous continuer (O/N) ?");
ConsoleKeyInfo saisie = Console.ReadKey(true);
if (saisie.Key == ConsoleKey.O)
{
    Console.WriteLine("On continue ...");
}
else
{
    Console.WriteLine("On s'arrête ...");
}



--------------------------- IF --------------------------------------
------------------------- SWITCH ----------------------------------------


if(truc > 0){
	Console.WriteLine("Hey");
}

string chose = "osef";
switch(chose){
	case "bou !":
		doTheThing();
		break;
#break == sort du switch
	case "Mars":
	case "Avril":
	case "Mai":
		Console.WriteLine("C'est le printemps !");
	default:
		theDo();
		break;
}


------- Tableau

string[] tab = new string[] { "hey", "coucou", "hola" };
#par ordre alphabétique :
Array.Sort(tab);

------- List

# https://openclassrooms.com/fr/courses/218202-apprenez-a-programmer-en-c-sur-net/218200-les-collections

List<int> liste = new List<int>();
foreach(int element in liste)
{
	Console.WriteLine(element); // NOTE : on ne pourra pas changer ici la valeur de l'élément, car element est une variable d'itération
}

Pour remove un élément :
-> parcourir la liste à l'envers avec un for
(avec foreach pas possible de modifier)
(avec for à "l'endroit" la size ne sera pas bonne (enfin on va continuer 
alors que l'on devrait relire l'élément sur lequel on est (si on a supprimé 2, 3 va maintenant être à la place de 2)))

EXEMPLE :
for (int i = jours.Count - 1; i >= 0; i--)
{
    if (jours[i] == "Mercredi")
        jours.Remove(jours[i]);
}

break : sortir de la boucle
continue : passer à l'itération suivante

for (int i = 0; i < 20; i++)
{
    if (i % 2 == 0)
    {
        continue;
    }
    Console.WriteLine(i);
}
-> ne va afficher que les nombres impairs



--- WHILE ---

int i = 0;
while(i<20){
	i++
}

int i = 0;
do {
	i++;
}
while(i<20); //la condition de sortie est évaluée à la fin 
-> on va passer au moins une fois dans la boucle même si i est égal à 20


while(!trouve) { ... }
while(i < Jours.Length && !trouve) { ... } -> pas de boucle infinie




------- Enumération

enum Jours{
	Lundi, //Lundi vaut 0
	Mardi, //Mardi vaut 1
	Mercredi, //...
	...
}

enum Jours
{
    Lundi = 5, // lundi vaut 5
    Mardi, // mardi vaut 6
    Mercredi = 9, // mercredi vaut 9
    Jeudi = 10, // jeudi vaut 10
    Vendredi, // vendredi vaut 11
    Samedi, // samedi vaut 12
    Dimanche = 20 // dimanche vaut 20
}

Jours joursDeLaSemaine;
#ou
Jours lundi = Jours.Lundi;
Console.WriteLine(lundi);
	-> Lundi //affiche le nom de l'énumération et pas sa valeur entière




--------------------------- EXCEPTION --------------------------------------

# https://openclassrooms.com/fr/courses/218202-apprenez-a-programmer-en-c-sur-net/217867-gerer-les-exceptions

throw new NotImplementedException("Le code n'a pas encore écrit !");

try {
	//chose à try
} catch(DivideByZeroException e){
	Console.WriteLine("Heeey");
}


"extend" exception :
public class NotreException : Exception {

	DateTime m_errorTime;
	static ushort s_errorNumber;

	public NotreException()
		: base("Message par défaut de l'exception.")
	{
		m_errorTime = DateTime.Now;
		s_errorNumber++;
	}

	public NotreException(string message) 
		: base(message)
	{
		m_errorTime = DateTime.Now;
		s_errorNumber++;
	}
}




--------------------------- FICHIER --------------------------------------


# https://openclassrooms.com/fr/courses/218202-apprenez-a-programmer-en-c-sur-net/218129-lire-et-ecrire-dans-un-fichier




--------------------------- TESTS --------------------------------------

# https://openclassrooms.com/fr/courses/2818931-programmez-en-oriente-objet-avec-c/2819216-les-tests-unitaires



--------------------------- PARAMETRES PROG - LIGNE DE COMMANDE --------------------------------------

# https://openclassrooms.com/fr/courses/1526901-apprenez-a-developper-en-c/2867811-la-ligne-de-commande



--------------------------- EVENT - DELEGATE --------------------------------------

# https://openclassrooms.com/fr/courses/2818931-programmez-en-oriente-objet-avec-c/2819111-delegues-evenements-et-expressions-lambdas

