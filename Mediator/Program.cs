namespace Mediator
{
    internal class Program
    {
        public abstract class Mediator
        {
            public abstract void Send(string message, Colleague coleague);
        }

        public abstract class Colleague
        {
            protected readonly Mediator Mediator;

            public Colleague(Mediator mediator) => 
                Mediator = mediator;
        }

        public class ConcreteColleagueOne : Colleague
        {
            public ConcreteColleagueOne(Mediator mediator) : base(mediator) { }

            public void Send(string message) => 
                Mediator.Send(message, this);

            public void Notify(string message) => 
                Console.WriteLine(message);
        }

        public class ConcreteColleagueTwo : Colleague
        {
            public ConcreteColleagueTwo(Mediator mediator) : base(mediator) { }

            public void Send(string message) => 
                Mediator.Send(message, this);

            public void Notify(string message) => 
                Console.WriteLine(message);
        }

        public class ConcreteMediator : Mediator
        {
            public ConcreteColleagueOne ConcreteColleagueOne { get; set; }
            public ConcreteColleagueTwo ConcreteColleagueTwo { get; set; }

            public override void Send(string message, Colleague colleague)
            {
                if (colleague == ConcreteColleagueOne)
                    ConcreteColleagueOne.Notify(message);
                else
                    ConcreteColleagueTwo.Notify(message);
            }
        }

        static void Main(string[] args)
        {
            ConcreteMediator concreteMediator = new ConcreteMediator();
            
            ConcreteColleagueOne concreteColleagueOne = new ConcreteColleagueOne(concreteMediator);
            ConcreteColleagueTwo concreteColleagueTwo = new ConcreteColleagueTwo(concreteMediator);

            concreteMediator.ConcreteColleagueOne = concreteColleagueOne;
            concreteMediator.ConcreteColleagueTwo= concreteColleagueTwo;

            concreteColleagueOne.Send("1-ый коллега отправляет сообщение 2-му");
            concreteColleagueTwo.Send("2-ой коллега отправляет сообщение 1-му");
        }
    }
}
