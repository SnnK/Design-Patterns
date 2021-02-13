using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    public class Program
    {
        static void Main()
        {
            RoundShapeFactory RoundShapeFactory = new RoundShapeFactory();

            RoundShape roundShape = RoundShapeFactory.Get(Color.Red);
            RoundShape roundShape2 = RoundShapeFactory.Get(Color.Red);
            RoundShape roundShape3 = RoundShapeFactory.Get(Color.Red);
            RoundShape roundShape4 = RoundShapeFactory.Get(Color.Black);

            roundShape.Draw(10, 20);
            roundShape2.Draw(40, 45);
            roundShape3.Draw(90, 12);
            roundShape4.Draw(60, 21);

            Console.Read();
        }
    }

    public enum Color
    {
        Red,
        Blue,
        Black
    }

    public class RoundShape
    {
        public object Material { get; set; }
        public object Helium { get; set; }

        private readonly Color Color;

        public RoundShape(Color color)
        {
            Color = color;
        }

        public void Draw(int location_x, int location_y)
        {
            Console.WriteLine($"{Color} renginde {Material} ve {Helium} kullanılarak yuvarlak şekil oluşturuldu. Konum: {location_x}, {location_y}");
        }
    }

    public class RoundShapeFactory
    {
        private readonly Dictionary<Color, RoundShape> _RoundShapes;

        public RoundShapeFactory()
        {
            _RoundShapes = new Dictionary<Color, RoundShape>();
        }

        public RoundShape Get(Color color)
        {
            if (_RoundShapes.ContainsKey(color))
            {
                return _RoundShapes[color];
            }

            RoundShape RoundShape = new RoundShape(color);

            _RoundShapes.Add(color, RoundShape);

            return RoundShape;
        }
    }
}