using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO5_test
{
    class Functions
    {
        static void Main(string[] args)
        {

        }

        public double Convertik(double dm)
        {
            if (dm <= 0)
            {
                throw new Exception("Входящее значение не может быть меньше, либо равным нулю.");
            }
            return (dm * 2.54);
        }

        public bool Chetnost(int num1)
        {
            if (num1 % 2 == 0)
                return true;
            else
                return false;
        }

        public int Max_Arr_El(int[] arr)
        {
            if (arr.Length == 0)
                throw new Exception("Пустой массив.");

            int max = arr[0];

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (max < arr[i])
                    max = arr[i];
                else
                    continue;
            }
            return max;
        }

        public int Ostatok(int num1, int num2)
        {
            if(num2==0)
                throw new Exception("Делитель не должен быть равен нулю.");
            return num1 % num2;
        }
    }
}
