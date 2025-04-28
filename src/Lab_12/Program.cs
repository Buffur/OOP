namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        { // Task1. Координати точки
            Point p1 = new Point(3, 4);
            Point p2 = new Point(0, 0);
            Console.WriteLine($"Відстань між {p1} і {p2}: {p1.DistanceTo(p2)}");
            Console.WriteLine();

            // Task2. Автомобільний парк
            Car car1 = new Car("Toyota", "Camry");
            Car car2 = new Car("BMW", "X5", 2020);
            Car car3 = new Car("Tesla", "Model S", 2022, "Black");

            car1.ShowInfo();
            car2.ShowInfo();
            car3.ShowInfo();
        }
    }

    // Task1
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // Task2
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car(string brand, string model)
        {
            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Марка і модель не можуть бути порожніми");

            Brand = brand;
            Model = model;
            Year = 0;
            Color = "Unknown";
        }
        public Car(string brand, string model, int year) : this(brand, model)
        {
            if (year < 1886 || year > DateTime.Now.Year + 1)
                throw new ArgumentException("Некоректний рік випуску");

            Year = year;
        }
        public Car(string brand, string model, int year, string color) : this(brand, model, year)
        {
            if (string.IsNullOrWhiteSpace(color))
                throw new ArgumentException("Колір не може бути порожнім");

            Color = color;
        }
        public void ShowInfo()
        {
            string yearInfo = Year == 0 ? "невідомий" : Year.ToString();
            string colorInfo = Color == "Unknown" ? "невідомий" : Color;
            Console.WriteLine($"Автомобіль: {Brand} {Model}, рік: {yearInfo}, колір: {colorInfo}");
        }
    }

}