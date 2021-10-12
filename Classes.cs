using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract double Perimetr();

    }

    class Triangle : Shape
    {
        protected double[] Side = new double[3];
        public Triangle(double side0, double side1, double side2)
        {
            if (IsTriangleExist(side0, side1, side2))
            {
                Side[0] = side0; Side[1] = side1; Side[2] = side2;
            }
            else throw new Exception("Triangle doesn`t exist");
        }
        private bool IsTriangleExist(double side0, double side1, double side2)
        {
            if (side0 > 0 && side1 > 0 && side2 > 0)
            {
                if (side0 + side1 > side2 && side0 + side2 > side1 && side1 + side2 > side0)
                    return true;
            }
            return false;
        }
        public override double CalculateArea() 
        {
            double angle = 0; //btw side0 and side1
            double area = 0;
            angle = Math.Acos((Math.Pow(Side[0], 2) + Math.Pow(Side[1], 2) - Math.Pow(Side[2], 2))
                 / (2 * Side[0] * Side[1])) * 180 / Math.PI;
            area = Side[0] * Side[1] * Math.Sin(angle) / 2;
            return area;
        }
        public override double Perimetr()
        {
            double perimetr = 0;
            foreach(double side in Side)
            {
                perimetr += side;
            }
            return perimetr;
        }
    }
    class Circle: Shape
    {
        private double r = 0;
        public double Radius
        {
            get
            { return r; }
            set
            { r = value; }
        }
        public Circle(double radius)
        {
            r = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * r * r;
        }
        public override double Perimetr()
        {
            return Math.PI * r * 2;
        }
    }

    class Rectangular: Shape
    {
        private double a = 0;
        private double b = 0;
        Rectangular(double a, double b)
        {
            this.a = a; this.b = b;
        }
        public override double CalculateArea()
        {
            return a * b;
        }
        public override double Perimetr()
        {
            return 2 * (a + b);
        }
    }
    class Square: Shape
    {
        private double a;
        public double Side { get { return a; } set { a = value; } }
        Square(double a) { this.a = a; }
        public override double CalculateArea()
        {
            return a * a;
        }
        public override double Perimetr()
        {
            return 4 * a;
        }
    }
    class Rhombus : Shape
    {
        private double d1;
        private double d2;
        Rhombus(double d1, double d2)
        {
            this.d1 = d1; this.d2 = d2;
        }
        public override double CalculateArea()
        {
            return d1 * d2 / 2;
        }
        public override double Perimetr()
        {
            double side = Math.Sqrt(Math.Pow(d1 / 2, 2) + Math.Pow(d2 / 2, 2));
            return side * 4; ;
        }
    }
}
