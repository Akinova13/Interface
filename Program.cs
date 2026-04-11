using System;
using System.Collections.Generic;

// ===============================
//   ПРИМЕНЕНИЕ ИНТЕРФЕЙСОВ
// ===============================
namespace InterfaceDemo
{
    // ---------- Точка входа ----------
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Пошаговая рабочая тетрадь: Интерфейсы в C#");
            Console.WriteLine(new string('=', 68));

            TeacherIntro();
            Step1_Movable();
            Step2_Notifications();
            Step3_MultipleInterfaces();
            Step4_ExplicitImplementation();
            FinalReflection();

            // Творческое задание – можно закомментировать, если не нужно
            Playground();
        }

        // -------------------------------------------------
        // ВСТУПЛЕНИЕ
        // -------------------------------------------------
        static void TeacherIntro()
        {
            Console.WriteLine("\n[Вступление преподавателя]");
            Console.WriteLine("Сегодня мы разбираем интерфейсы в C#.");
            Console.WriteLine("Интерфейс задает контракт: если класс его реализует,");
            Console.WriteLine("он обязан предоставить нужное поведение.");
            Console.WriteLine("Мы начнём с простых примеров и дойдем до более практичных.");
        }

        // -------------------------------------------------
        // ШАГ 1 – IMovable
        // -------------------------------------------------
        static void Step1_Movable()
        {
            Console.WriteLine("\n================ ШАГ 1. IMovable ================");
            Console.WriteLine("[Пояснение преподавателя]");
            Console.WriteLine("Разные объекты могут уметь двигаться.");
            Console.WriteLine("Но при этом они не обязаны быть родственными классами.");
            Console.WriteLine("Интерфейс IMovable описывает общую способность Move().");

            List<IMovable> movables = new List<IMovable>
            {
                new Car(),
                new Person(),
                new Robot()
            };

            Console.WriteLine("\nРезультат:");
            foreach (IMovable movable in movables)
                movable.Move();

            Console.WriteLine("\n[Задание студенту]");
            Console.WriteLine("Найдите класс Robot и замените заглушку в Move() на осмысленную реализацию.");
        }

        // -------------------------------------------------
        // ШАГ 2 – Уведомления
        // -------------------------------------------------
        static void Step2_Notifications()
        {
            Console.WriteLine("\n================ ШАГ 2. Уведомления ================");
            Console.WriteLine("[Пояснение преподавателя]");
            Console.WriteLine("Интерфейсы особенно полезны, когда мы хотим");
            Console.WriteLine("подменять реализации без переписывания логики.");

            List<INotificationSender> senders = new List<INotificationSender>
            {
                new EmailSender(),
                new SmsSender()
            };

            Console.WriteLine("\nРезультат:");
            foreach (INotificationSender sender in senders)
                sender.Send("Привет из интерфейса!");

            Console.WriteLine("\n[Задание студенту]");
            Console.WriteLine("Найдите класс SmsSender и замените заглушку в Send() на правильную строку.");
        }

        // -------------------------------------------------
        // ШАГ 3 – Несколько интерфейсов
        // -------------------------------------------------
        static void Step3_MultipleInterfaces()
        {
            Console.WriteLine("\n================ ШАГ 3. Несколько интерфейсов ================");
            Console.WriteLine("[Пояснение преподавателя]");
            Console.WriteLine("Один класс может реализовать сразу несколько интерфейсов.");
            Console.WriteLine("Это важно, потому что в C# нельзя наследоваться от двух классов,");
            Console.WriteLine("но можно поддерживать несколько ролей одновременно.");

            Message message = new Message("Интерфейсы делают архитектуру гибче.");

            Console.WriteLine("\nРезультат:");
            Console.WriteLine($"Текст сообщения: {message.Text}");
            message.Print();

            Console.WriteLine("\n[Задание студенту]");
            Console.WriteLine("Найдите метод Print() в классе Message и замените заглушку.");
        }

        // -------------------------------------------------
        // ШАГ 4 – Явная реализация
        // -------------------------------------------------
        static void Step4_ExplicitImplementation()
        {
            Console.WriteLine("\n================ ШАГ 4. Явная реализация интерфейса ================");
            Console.WriteLine("[Пояснение преподавателя]");
            Console.WriteLine("Иногда один класс реализует два интерфейса с одинаковым методом.");
            Console.WriteLine("Тогда можно реализовать эти методы явно, по‑разному для каждого интерфейса.");

            Sample sample = new Sample();
            IControl control = sample;
            ISurface surface = sample;

            Console.WriteLine("\nРезультат:");
            control.Paint();   // IControl.Paint()
            surface.Paint();   // ISurface.Paint()

            Console.WriteLine("\n[Задание студенту]");
            Console.WriteLine("Найдите реализацию ISurface.Paint() и замените заглушку.");
        }

        // -------------------------------------------------
        // ИТОГ
        // -------------------------------------------------
        static void FinalReflection()
        {
            Console.WriteLine("\n================ ИТОГ ================");
            Console.WriteLine("Проверьте себя:");

            Console.WriteLine("\n1. Что такое интерфейс?");
            Console.WriteLine("   Ответ: Интерфейс — тип, описывающий набор публичных членов без реализации. " +
                              "Класс, реализующий интерфейс, обязуется предоставить эти члены.");

            Console.WriteLine("\n2. Чем интерфейс отличается от абстрактного класса?");
            Console.WriteLine("   Ответ: Абстрактный класс может содержать реализованные члены, поля, конструкторы; " +
                              "интерфейс (до C# 8) только объявляет члены. " +
                              "Класс может наследовать лишь один класс, но реализовывать сколько‑угодно интерфейсов.");

            Console.WriteLine("\n3. Почему один класс может реализовать несколько интерфейсов?");
            Console.WriteLine("   Ответ: Каждый интерфейс описывает отдельный аспект поведения. " +
                              "Множественная реализация интерфейсов позволяет объекту одновременно " +
                              "быть «перемещаемым», «сериализуемым», «сравнимым» и т.п.");

            Console.WriteLine("\n4. Что даёт программирование через интерфейс, а не через конкретный класс?");
            Console.WriteLine("   Ответ: Позволяет писать код, зависимый от абстракций, а не от конкретных реализаций. " +
                              "Упрощает замену реализации, упрощает тестирование (моки), повышает гибкость системы.");

            Console.WriteLine("\n5. В каких задачах интерфейсы особенно полезны?");
            Console.WriteLine("   Ответ: • Паттерн Strategy (разные стратегии поведения).");
            Console.WriteLine("   • Внедрение зависимостей (DI) и репозитории.");
            Console.WriteLine("   • Обратные вызовы/события (IObservable/IObserver).");
            Console.WriteLine("   • Унификация работы с разными типами (IComparable, ICloneable, IEnumerable).");
        }

        // -------------------------------------------------
        // Творческое задание
        // -------------------------------------------------
        static void Playground()
        {
            Console.WriteLine("\n================ Творческое задание =================");
            List<IPlayable> instruments = new List<IPlayable>
            {
                new Guitar(),
                new Piano(),
                new Drum()
            };

            foreach (var instr in instruments)
                instr.Play();
        }
    }

    // ==============================
    // 1️⃣ Интерфейс IMovable
    // ==============================
    interface IMovable
    {
        void Move();
    }

    class Car : IMovable
    {
        public void Move() => Console.WriteLine("Машина едет");
    }

    class Person : IMovable
    {
        public void Move() => Console.WriteLine("Человек идёт");
    }

    class Robot : IMovable
    {
        public void Move()
        {
            // TODO 1 – осмысленная реализация
            Console.WriteLine("Робот перемещается с помощью электродвигателей");
        }
    }

    // ==============================
    // 2️⃣ Интерфейс INotificationSender
    // ==============================
    interface INotificationSender
    {
        void Send(string message);
    }

    class EmailSender : INotificationSender
    {
        public void Send(string message) => Console.WriteLine($"Email: {message}");
    }

    class SmsSender : INotificationSender
    {
        public void Send(string message)
        {
            // TODO 2 – правильный вывод SMS
            Console.WriteLine($"SMS: {message}");
        }
    }

    // ==============================
    // 3️⃣ Интерактивные интерфейсы IMessage + IPrintable
    // ==============================
    interface IMessage
    {
        string Text { get; set; }
    }

    interface IPrintable
    {
        void Print();
    }

    class Message : IMessage, IPrintable
    {
        public string Text { get; set; }

        public Message(string text) => Text = text;

        public void Print()
        {
            // TODO 3 – вывод текста сообщения
            Console.WriteLine(Text);
        }
    }

    // ==============================
    // 4️⃣ Явная реализация IControl и ISurface
    // ==============================
    interface IControl
    {
        void Paint();
    }

    interface ISurface
    {
        void Paint();
    }

    class Sample : IControl, ISurface
    {
        // Явная реализация IControl.Paint()
        void IControl.Paint() => Console.WriteLine("IControl.Paint");

        // Явная реализация ISurface.Paint()
        void ISurface.Paint()
        {
            // TODO 4 – вывод ISurface.Paint()
            Console.WriteLine("ISurface.Paint");
        }
    }

    // ==============================
    // 5️⃣ Творческое задание – IPlayable
    // ==============================
    interface IPlayable
    {
        void Play();
    }

    class Guitar : IPlayable
    {
        public void Play() => Console.WriteLine("Guitar strums: 🎸");
    }

    class Piano : IPlayable
    {
        public void Play() => Console.WriteLine("Piano keys: 🎹");
    }

    class Drum : IPlayable
    {
        public void Play() => Console.WriteLine("Drum beats: 🥁");
    }
}
