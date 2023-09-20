using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class PointProgram
    {
        public struct Point
        {
            public int x;
            public int y;
            public int z;

            public override string ToString()
            {
                return '(' + x.ToString() + "," + y.ToString() + "," + z.ToString() + ')';
            }

            public Point(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            private static readonly Point startOfCoodinateSystem = new Point(0, 0, 0);

            public static Point returnStartOfCoordinateSystem()
            {
                return startOfCoodinateSystem;
            }
        }

        public static class DistanceBetweenTwoPoints
        {
            public static double getDistance(Point point1, Point point2)
            {
                int dx = point2.x - point1.x;
                int dy = point2.y - point1.y;
                int dz = point2.z - point1.z;

                return dx * dx + dy * dy + dz * dz;
            }
        }

        public class Path
        {
            private LinkedList<Point> points = new LinkedList<Point>();

            public void AddPoint(Point point)
            {
                points.AddLast(point);
            }
        }

        public static class PathStorage
        {
            static public Path readPathFromFile(string filePath)
            {
                Path path = new Path();
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Length != fs.Position)
                    {
                        int x = br.ReadInt32();
                        int y = br.ReadInt32();
                        int z = br.ReadInt32();

                        path.AddPoint(new Point(x, y, z));
                    }
                }

                return path;
            }
        }

        class GenericList<T>
        {
            T[] data = null;
            int capacity = 0;
            int size = 0;

            public GenericList(int capacity)
            {
                data = new T[capacity];
                this.capacity = capacity;
            }

            public void pushBack(T item)
            {
                if (data == null)
                {
                    return;
                }

                if (capacity == size)
                {
                    autoGrow();
                }

                data[size++] = item;
            }

            public T getElement(int index)
            {
                if (index < 0 || index >= size || data == null)
                {
                    throw new IndexOutOfRangeException();
                }

                return data[index];
            }

            public void removeElemwnt(int index)
            {
                if (index < 0 || index >= size || data == null)
                {
                    throw new IndexOutOfRangeException();
                }

                (data[index], data[size]) = (data[size], data[index]);

                size--;
            }

            public void insertElemetAtGivenPosition(int index, T item)
            {
                if (index < 0 || index >= size || data == null)
                {
                    throw new IndexOutOfRangeException();
                }

                data[index] = item;
            }

            public void clearList()
            {
                data = null;
                size = 0;
                capacity = 0;
            }

            int findElementByValue(T item)
            {
                int index = -1;

                if (data == null)
                {
                    throw new Exception();
                }

                for (int i = 0; i < size; i++)
                {
                    if (EqualityComparer<T>.Default.Equals(data[i], item))
                    {
                        index = i;
                    }
                }

                return index;
            }

            public override string ToString()
            {
                string result = string.Empty;

                for (int i = 0; i < size; i++)
                {
                    result += data[i];
                    result += " ";
                }

                return result;
            }

            void autoGrow()
            {
                capacity *= 2;

                T[] tempData = new T[capacity];

                for (int i = 0; i < size; ++i)
                {
                    tempData[i] = data[i];
                }

                data = tempData;
            }

            public T getMin()
            {
                T minItem = data[0];

                if (data == null || size == 0)
                {
                    throw new Exception();
                }

                for (int i = 1; i < size; i++)
                {
                    if (Comparer<T>.Default.Compare(data[i], minItem) < 0)
                    {
                        minItem = data[i];
                    }
                }

                return minItem;
            }

            public T getMax()
            {
                T maxItem = data[0];

                if (data == null || size == 0)
                {
                    throw new Exception();
                }

                for (int i = 1; i < size; i++)
                {
                    if (Comparer<T>.Default.Compare(data[i], maxItem) > 0)
                    {
                        maxItem = data[i];
                    }
                }

                return maxItem;
            }
        }

        class Matrix<T>
        {
            T[,] matrix = null;
            int countOfRows = 0;
            int countOfCols = 0;

            public Matrix(int countOfRows, int countOfCols)
            {
                this.countOfRows = countOfRows;
                this.countOfCols = countOfCols;

                matrix = new T[countOfRows, countOfCols];
            }

            public Matrix(T[,] matrix, int countOfRows, int countOfCols)
            {
                this.matrix = matrix;
                this.countOfRows = countOfRows;
                this.countOfCols = countOfCols;
            }

            public ref T getElementByRef(int indexOfRow, int indexOfCol)
            {
                if (matrix == null || indexOfRow > countOfRows || indexOfCol > countOfCols)
                {
                    throw new Exception("Invalid input or the matrix is null");
                }

                return ref matrix[indexOfRow, indexOfCol];
            }

            public T getElement(int indexOfRow, int indexOfCol)
            {
                T elemetToReturn = getElementByRef(indexOfRow, indexOfCol);
                
                return elemetToReturn;
            }

            public static T add<T>(T number1, T number2)
            {
                dynamic dynamic1 = number1;
                dynamic dynamic2 = number2;
                
                return dynamic1 + dynamic2;
            }

            static public Matrix<T> operator +(Matrix<T> lhs, Matrix<T> rhs)
            {
                if (lhs == null || rhs == null || lhs.countOfCols != rhs.countOfCols || lhs.countOfRows != rhs.countOfRows)
                {
                    throw new Exception("The Matrixs can not be added");
                }

                Matrix<T> result = new Matrix<T>(lhs.countOfRows, lhs.countOfCols);

                for (int i = 0; i < lhs.countOfRows; i++)
                {
                    for (int j = 0; j < lhs.countOfCols; j++)
                    {
                        result.getElementByValue(i, j) = add(lhs.getElement(i, j), rhs.getElement(i, j));
                    }
                }

                return result;
            }

            static public bool hasZero(Matrix<T> matrix)
            {
                bool hasZero = false;

                for (int i = 0; i < matrix.countOfRows && !hasZero; i++)
                {
                    for (int j = 0; j < matrix.countOfCols && !hasZero; j++)
                    {
                        if (EqualityComparer<T>.Equals(matrix.matrix[i, j], 0))
                        {
                            hasZero = true;
                        }
                    }
                }

                return hasZero;
            }

            static public bool operator true(Matrix<T> matrix)
            {
                return hasZero(matrix);
            }
            static public bool operator false(Matrix<T> matrix)
            {
                return hasZero(matrix);
            }
        }

        static void Main(string[] args)
        {
            GenericList<int> myGnlist = new GenericList<int>(2);

            myGnlist.pushBack(1);
            myGnlist.pushBack(2);

            Console.WriteLine(myGnlist.ToString());

            myGnlist.pushBack(3);
            Console.WriteLine(myGnlist.ToString());

            Console.WriteLine("{0}, {1} ", myGnlist.getMin(), myGnlist.getMax());
        }
    }
}