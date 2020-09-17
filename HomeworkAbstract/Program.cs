using System;

namespace HomeworkAbstract
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Exit = false;
            do
            {
                Console.WriteLine("Меню: \n1.Ввод данных. \n2.Выход.\nВведите цифру перед пунктом для перехода в пункт меню.");
                int navigate = InputInfo.InputNavigate2();
                switch (navigate)
                {
                    case 1:
                        {
                            Console.WriteLine("Вы хотите ввести данные аспиранта или студента? \nВведите 1 - для ввода данных студента или 2 - для ввода данных аспиранта.");
                            int case1 = InputInfo.InputNavigate2();
                            switch (case1)
                            {
                                case 1:
                                    {

                                        Student student = new Student("", 1, 1);
                                        Console.WriteLine("Вывести данные о студенте?\nВведите 1, если ДА; 2, если НЕТ.");
                                        int select = InputInfo.InputNavigate2();
                                        {
                                            if (select == 1)
                                            {
                                                student.Display();
                                            }
                                        }

                                        Console.WriteLine("Для выхода нажмите - 1, для того, чтобы вернуться в главное меню нажмите 2.");
                                        int select2 = InputInfo.InputNavigate2();
                                        if (select2 == 1)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                                case 2:
                                    {

                                        Aspirant aspirant = new Aspirant("", 1, 1, "");

                                        Console.WriteLine("Для выхода нажмите - 1, для того, чтобы вернуться в главное меню нажмите 2.");
                                        Console.WriteLine("Вывести данные об аспиранте?\nВведите 1, если ДА; 2, если НЕТ.");
                                        int select = InputInfo.InputNavigate2();
                                        {
                                            if (select == 1)
                                            {
                                                aspirant.Display();
                                            }
                                        }
                                        Console.WriteLine("Для выхода нажмите - 1, для того, чтобы вернуться в главное меню нажмите 2.");
                                        int select2 = InputInfo.InputNavigate2();
                                        if (select2 == 1)
                                        {
                                            Exit = true;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }

                    case 2:
                        {
                            Exit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Произошла ошибка.");
                            break;
                        }



                }
            }
            while (Exit == false);

        }
    }
    public abstract class People
    {
        public string Name { get; set; }
        public int Course { get; set; }
        public int Number { get; set; }
        public People(string name, int course, int number)
        {
            Console.WriteLine("Введите имя.");
            Name = InputInfo.InputName();
            Console.WriteLine("Введите курс, на котором учится студент.");
            Course = InputInfo.InputNavigate1();
            Console.WriteLine("Введите номер зачетной книжки.");
            Number = InputInfo.InputInt();
        }
        public abstract void Display();

    }

    class Student : People
    {
        public Student(string name, int course, int number)
            : base(name, course, number)
        {
        }
        public override void Display()
        {
            Console.WriteLine($"Студент {Name}, учится на {Course}-ом курсе, номер зачетной книжки: {Number}.");
        }

    }

    class Aspirant : People
    {
        string CandidateDiss { get; set; }

        public Aspirant(string name, int course, int number, string candidatebook)
            : base(name, course, number)
        {
            Console.WriteLine("Введите название диссертации.");
            CandidateDiss = InputInfo.InputName();
        }
        public override void Display()
        {
            Console.WriteLine($"Студент {Name}, учится на {Course}-ом курсе, номер зачетной книжки: {Number}, {CandidateDiss} - название диссертации.");
        }
    }
    class InputInfo
    {
        public static string InputName()
        {
            string name;
            bool isRight = false;
            do
            {
                name = Console.ReadLine();
                int count = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        if (name[i] == j.ToString()[0])
                        {
                            isRight = false;
                            count += 1;
                            break;
                        }
                        if (count == 0)
                        {
                            isRight = true;
                        }
                    }
                }
                if (isRight == false)
                {
                    Console.WriteLine("Введите имя, состоящее из букв. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return name;
        }
        public static int InputInt()
        {
            int number;
            bool isRight = false;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    isRight = true;
                }
                else
                {
                    Console.WriteLine("Введено неверное значение. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return number;
        }
        public static int InputNavigate1()
        {
            int number;
            bool isRight = false;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 && number <= 4)
                    {
                        isRight = true;
                    }
                    else
                    {
                        Console.WriteLine("Введите одну из цифр: 1, 2, 3, 4.");
                    }
                }
                else
                {
                    Console.WriteLine("Введено неверное значение. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return number;

        }
        public static int InputNavigate2()
        {
            int number;
            bool isRight = false;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 && number <= 2)
                    {
                        isRight = true;
                    }
                    else
                    {
                        Console.WriteLine("Введите: 1 или 2");
                    }
                }
                else
                {
                    Console.WriteLine("Введено неверное значение. Попробуйте снова.");
                }
            }
            while (isRight == false);
            return number;
        }

    }

}
