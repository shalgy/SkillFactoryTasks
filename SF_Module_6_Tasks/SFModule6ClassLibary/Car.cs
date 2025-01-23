using Microsoft.VisualBasic.FileIO;

namespace SFModule6ClassLibrary
{
    enum TurnDirection
    {
        None = 0,
        Left,
        Right
    }

    public class Car
    {
        private double Fuel;

        private int Mileage;

        private string color;

        private TurnDirection turn;

        public Car()
        {
            Fuel = 50;
            Mileage = 0;
            color = "White";
        }

        public virtual void Move()
        {
            // Move a kilometer
            Mileage++;
            Fuel -= 0.5;
        }

        private void Turn(TurnDirection direction)
        {
            turn = direction;
        }

        public void FillTheCar()
        {
            Fuel = 50;
        }

        public string GetColor()
        {
            return color;
        }

        public void ChangeColor(string newColor)
        {
            if (color != newColor)
                color = newColor;
        }

        public bool IsTurningLeft()
        {
            return turn == TurnDirection.Left;
        }

        public bool IsTurningRight()
        {
            return turn == TurnDirection.Right;
        }
    }
    class HybridCar : Car
    {
        // Свойства и другие методы, присущие HybridCar
        public override void Move()
        {
            base.Move();
            Console.WriteLine("Вызван метод Move класса HybridCar");

            switch (FuelType)
            {
                case FuelType.Gas:
                    Gas -= 0.5;
                    break;
                case FuelType.Electricity:
                    Electricity -= 0.5;
                    break;
            }
        }
    }
}
