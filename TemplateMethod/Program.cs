
namespace TemplateMethod
{
    internal class Program
    {
        /// <summary>
        /// Назначение: шаблонный метод определяет основу алгоритма и позволяет подклас-сам переопределять некоторые шаги алгоритма,
        /// не изменяя его структуры в целом.
        /// Другими словами: шаблонный метод — это каркас, в который наследники могут подставить реализации недостающих элементов.
        /// </summary>
        
        public abstract class AbstractClass
        {
            public void TemplateMethod()
            {
                OperationOne();
                OperationTwo();
            }

            public abstract void OperationOne();

            public abstract void OperationTwo();
        }

        public class ConcreteClassOne : AbstractClass
        {
            public override void OperationOne()
            {
                Console.WriteLine("1-я операция 1-го конкретного класса");
            }

            public override void OperationTwo()
            {
                Console.WriteLine("2-я операция 1-го конкретного класса");
            }
        }

        public class ConcreteClassTwo : AbstractClass
        {
            public override void OperationOne()
            {
                Console.WriteLine("1-я операция 2-го конкретного класса");
            }

            public override void OperationTwo()
            {
                Console.WriteLine("2-я операция 2-го конкретного класса");
            }
        }

        static void Main(string[] args)
        {
            ConcreteClassOne concreteClassOne = new ConcreteClassOne();
            ConcreteClassTwo concreteClassTwo = new ConcreteClassTwo();

            concreteClassOne.TemplateMethod();
            concreteClassTwo.TemplateMethod();
        }
    }
}
