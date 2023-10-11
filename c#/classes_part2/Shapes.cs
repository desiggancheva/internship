using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes2
{
    public abstract class Shape
    {
        protected uint width;
        protected uint height;

        protected Shape(uint width, uint height)
        {
            this.width=width;
            this.height=height;
        }

        public abstract double calculateSurface();
    }

    public class Triangle : Shape
    {
        public Triangle(uint width, uint height) : base(width, height) { }
        public override double calculateSurface() 
        {
            return width * height / 2;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(uint width, uint height) : base(width, height) { }
        public override double calculateSurface()
        {
            return width * height;
        }
    }
    
    public class Square : Shape
    {
        public Square(uint side) : base(side, side) { }
        public override double calculateSurface()
        {
            return width * width;
        }
    }
}
