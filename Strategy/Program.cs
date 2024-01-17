namespace Strategy
{
    internal class Program
    {
        /// <summary>
        /// Назначение: определяет семейство алгоритмов, инкапсулирует каждый из них и де-лает их взаимозаменяемыми.
        /// Стратегия позволяет изменять алгоритмы независи-мо от клиентов, которые ими пользуются.
        /// Другими словами: стратегия инкапсулирует определенное поведение с возможно-стью его подмены.
        /// </summary>

        public interface IStrategy
        {
            void Algorithm();
        }

        public class ConcreteStrategyOne : IStrategy
        {
            public void Algorithm()
            {
                Console.WriteLine("Выполняется алгоритм 1-ой конкретной стратегии");
            }
        }

        public class ConcreteStrategyTwo : IStrategy
        {
            public void Algorithm()
            {
                Console.WriteLine("Выполняется алгоритм 2-ой конкретной стратегии");
            }
        }

        public class Context
        {
            public IStrategy Strategy { get; set; }

            public void ExecuteAlgorithm()
            {
                Strategy.Algorithm();
            }
        }

        static void Main(string[] args)
        {
            Context context = new Context();
            IStrategy strategy;

            strategy = new ConcreteStrategyOne();
            context.Strategy = strategy;
            context.ExecuteAlgorithm();

            strategy = new ConcreteStrategyTwo();
            context.Strategy = strategy;
            context.ExecuteAlgorithm();
        }
    }
}
