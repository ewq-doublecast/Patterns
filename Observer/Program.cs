namespace Observer
{
    internal class Program
    {
        /// <summary>
        /// Назначение: определяет зависимость типа «один ко многим» между объектами таким образом,
        /// что при изменении состояния одного объекта все зависящие от него оповещаются об этом и автоматически обновляются.
        /// Другими словами: наблюдатель уведомляет все заинтересованные стороны о произошедшем событии или об изменении своего состояния.
        /// </summary>

        public interface IObservable
        {
            void AddObserver(IObserver observer);
            void RemoveObserver(IObserver observer);
            void NotifyObservers();
            void UpdateState();
        }

        public interface IObserver
        {
            void Update(string message);
        }

        public class ConcreteObservable : IObservable
        {
            private List<IObserver> _observers;

            private string _state;

            public ConcreteObservable()
            {
                _observers = new List<IObserver>();
                _state = string.Empty;
            }

            public void AddObserver(IObserver observer) => 
                _observers.Add(observer);

            public void RemoveObserver(IObserver observer) => 
                _observers?.Remove(observer);

            public void NotifyObservers()
            {
                foreach (var observer in _observers)
                    observer.Update(_state);
            }

            public void UpdateState()
            {
                Random random = new Random();
                _state = random.Next(100, 500).ToString();
                NotifyObservers();
            }
        }

        public class ConcreteObserverOne : IObserver
        {
            public void Update(string message) => 
                Console.WriteLine($"[Наблюдатель 1] Сообщение от наблюдаемого объекта: {message}");
        }

        public class ConcreteObserverTwo : IObserver
        {
            private readonly IObservable _observable;

            public ConcreteObserverTwo(IObservable observable) => 
                _observable = observable;

            public void Update(string message) =>
                Console.WriteLine($"[Наблюдатель 2] Сообщение от наблюдаемого объекта: {message}");

            public void StopObservation() => 
                _observable.RemoveObserver(this);
        }

        static void Main(string[] args)
        {
            IObservable observable = new ConcreteObservable();

            ConcreteObserverOne concreteObserverOne = new ConcreteObserverOne();
            ConcreteObserverTwo concreteObserverTwo = new ConcreteObserverTwo(observable);

            observable.AddObserver(concreteObserverOne);
            observable.AddObserver(concreteObserverTwo);

            observable.UpdateState();

            concreteObserverTwo.StopObservation();

            observable.UpdateState();
        }
    }
}
