using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TRPO5_test
{
    [TestFixture]
    class Functions_test
    {
        [TestCase]
        public void Convertik()
        {
            Functions f = new Functions();
            Assert.AreEqual(7.62, f.Convertik(3));

            Assert.AreEqual(7.62, f.Convertik(double.MaxValue));
            //var ex1 = Assert.Throws<Exception>(() => f.Convertik(double.MaxValue));
            Assert.That(ex1.Message, Is.EqualTo("Не лезь..."));

            var ex = Assert.Throws<Exception>(() => f.Convertik(-3));
            Assert.That(ex.Message, Is.EqualTo("Входящее значение не может быть меньше, либо равным нулю."));
        }

        [TestCase]
        public void Chetnost()
        {
            Functions f = new Functions();
            Assert.AreEqual(true, f.Chetnost(4));
            Assert.AreEqual(false, f.Chetnost(9));
            Assert.AreEqual(true, f.Chetnost(-8));
            Assert.AreEqual(false, f.Chetnost(-7));
        }

        [TestCase]
        public void Ostatok()
        {
            Functions f = new Functions();
            Assert.AreEqual(0, f.Ostatok(-2,2));
            Assert.AreEqual(1, f.Ostatok(5,2));
            Assert.AreEqual(2, f.Ostatok(5, 3));
            var ex = Assert.Throws<Exception>(() => f.Ostatok(2, 0));
            Assert.That(ex.Message, Is.EqualTo("Делитель не должен быть равен нулю."));
        }

        [TestCase]
        public void Max_Arr_El()
        {
            int[] arr = new int[] { };
            int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
            int[] arr2 = new int[] { -1, -2, -3, -4, -5 };

            Functions f = new Functions();
            Assert.AreEqual(5, f.Max_Arr_El(arr1));
            Assert.AreEqual(-1, f.Max_Arr_El(arr2));
            var ex = Assert.Throws<Exception>(() => f.Max_Arr_El(arr));
            Assert.That(ex.Message, Is.EqualTo("Пустой массив."));
        }
    }
}
