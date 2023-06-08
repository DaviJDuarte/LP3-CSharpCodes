// Hello World!

Console.WriteLine("Hello, World!");

// Horario Atual

Console.WriteLine("The current time is: " + DateTime.Now);

// Variaveis

string nomeDoAluno = "Davi Duarte";
Console.WriteLine("O nome do aluno é: " + nomeDoAluno);

int idade = 17;
Console.WriteLine("A idade do aluno é: " + idade);

// Constantes

const int MaioridadePenal = 18;
System.Console.WriteLine("A idade de maioridade penal é: " + MaioridadePenal + " anos");

// Inferencia de tipos

var nomeDoAluno2 = "Renatinho";
var idade2 = 60;
var estaVivo = true;

System.Console.WriteLine("O aluno " + nomeDoAluno2 + " tem " + idade2 + " anos");
System.Console.WriteLine("Renatinho está vivo?: " + estaVivo);

// Estruturas de decisao
// IF ELSE

int age = 18;
if (age >= 18)
{
    Console.WriteLine("Você é maior de idade!");
}
else
{
    Console.WriteLine("Você é menor de idade!");
}

// SWITCH CASE

var mes = 11;
switch (mes)
{
    case 1:
        System.Console.WriteLine("O mês é Janeiro!");
        break;
    case 2:
        System.Console.WriteLine("O mês é Fevereiro!");
        break;
    case 3:
        System.Console.WriteLine("O mês é Março!");
        break;
    case 4:
        System.Console.WriteLine("O mês é Abril!");
        break;
    case 5:
        System.Console.WriteLine("O mês é Maio!");
        break;
    case 6:
        System.Console.WriteLine("O mês é Junho!");
        break;
    case 7:
        System.Console.WriteLine("O mês é Julho!");
        break;
    case 8:
        System.Console.WriteLine("O mês é Agosto!");
        break;
    case 9:
        System.Console.WriteLine("O mês é Setembro!");
        break;
    case 10:
        System.Console.WriteLine("O mês é Outubro!");
        break;
    case 11:
        System.Console.WriteLine("O mês é Novembro!");
        break;
    case 12:
        System.Console.WriteLine("O mês é Dezembro!");
        break;
    default:
        System.Console.WriteLine("Mês Inválido!");
        break;
}

//Estruturas de repeticao
// WHILE

int numero = -1;
while (numero != 10)
{
    Console.Write("Digite um número: ");
    numero = Convert.ToInt32(Console.ReadLine());
    if (numero < 10)
    {
        Console.WriteLine("Você errou, tente um número maior.");
    }
    else if (numero > 10)
    {
        Console.WriteLine("Você errou, tente um número menor.");
    }
    else
    {
        Console.WriteLine("Parabéns, você acertou!");
    }
}

//DO WHILE

int contador = 15;
do
{
    Console.WriteLine("O contador vale: " + contador);
    contador++;
} while (contador <= 10);

//FOR

for (int i = 1; i<=10; i++){
    System.Console.WriteLine("A variável i agora vale: " + i);
}

//Arrays

string[] alunos = new string[5]{"Davi", "Gabriel", "Igor", "Tarsila", "Raissa"};

for(int i = 0; i<5; i++){
    System.Console.WriteLine(alunos[i]);
}

//FOR EACH

foreach(var aluno in alunos){
    System.Console.WriteLine(aluno);
}

//Outras propriedades de arrays

string aulaIntro = "Introdução ás Coleções";
string aulaModelando = "Modelando a Classe Aula";
string aulaSets = "Trabalhando com Conjuntos";

string[] aulas = new string[3];
aulas[0] = aulaIntro;
aulas[1] = aulaModelando;
aulas[2] = aulaSets;

foreach(var aula in aulas){
    System.Console.WriteLine(aula);
}

//Array Length

for(int i = 0; i< aulas.Length; i++){
    System.Console.WriteLine(aulas[i]);
}

//Array Index Of

System.Console.WriteLine("Aula Modelando está no índice: " + Array.IndexOf(aulas, aulaModelando));

//Array Last Index Of

System.Console.WriteLine(Array.LastIndexOf(aulas, aulaModelando));