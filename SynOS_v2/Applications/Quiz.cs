
using System.Security.Cryptography;
using Libary;
using Libary.Components;
using Libary.Extension;

namespace SynOS_v2.Applications
{
    public class Question
    {
        public string question;
        public ListSelection answerSelection;
        public int correctAnswer;
        public int selectedAnswer = -1;
    }
    public class Quiz : Application
    {
        List<Question> questionList = new();

        public override void Init()
        {
            questionList.Add(new()
            {
                question = "Wie heißt der Typ einer Text Variable?",
                answerSelection = new ListSelection()
                {
                    elements = new()
                    {
                        "int",
                        "float",
                        "string",
                        "bool"
                    },
                },
                correctAnswer = 2
            });
            questionList.Add(new()
            {
                question = "Wo wird '()' eingesetzt?",
                answerSelection = new ListSelection()
                {
                    elements = new()
                    {
                        "Methoden",
                        "Klassen",
                        "Variablen",
                    }
                },
                correctAnswer = 0
            });
            questionList.Add(new()
            {
                question = "Wofür sind Klassen da?",
                answerSelection = new ListSelection()
                {
                    elements = new()
                    {
                        "Damit lässt sich ein Wert speichern ('Hallo', 1, true)",
                        "Mit Klassen kann ich Objekte definieren/erstellen",
                        "Die braucht man nicht"
                    }
                },
                correctAnswer = 1
            });
            questionList.Add(new()
            {
                question = "Wo kann ich Variablen deklarieren?",
                answerSelection = new ListSelection()
                {
                    elements = new()
                    {
                        "Nur in einer Klasse",
                        "Nur in einer Methode",
                        "In einer Klasse und Methode",
                    }
                },
                correctAnswer = 2
            });
            questionList.Add(new()
            {
                question = "Wo kann ich Variablen deklarieren?",
                answerSelection = new ListSelection()
                {
                    elements = new()
                    {
                        "Nur in einer Klasse",
                        "Nur in einer Methode",
                        "In einer Klasse und Methode",
                    }
                },
                correctAnswer = 2
            });
            questionList.Add(new()
            {
                question = "Wo muss das kleine 'f' hin?",
                answerSelection = new ListSelection()
                {
                    elements = new()
                    {
                        "Hinter den Wert von einen string",
                        "Hinter den Wert von einen float",
                        "Hinter eine Klasse",
                    }
                },
                correctAnswer = 1
            });
        }

        public override void Update()
        {
            var qs = questionList;

            foreach (var item in qs)
            {
                $"\n {item.answerSelection.Show($" &6┌─‹ &5Beantworte diese frage \n&3{item.question}")}".Print();
            }
            
        }
    }
}
