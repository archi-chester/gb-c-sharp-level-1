using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    /// <summary>
    /// Класс простой дроби
    /// </summary>
    public class Fraction
    {
        /// <summary>
        /// числитель дроби
        /// </summary>
        private int _numerator;

        public int Numerator
        {
            get
            {
                return this._numerator;
            }
            set
            {
                this._numerator = value;
            }
        }

        /// <summary>
        /// знаменатель дроби
        /// </summary>
        private int _denominator;

        public int Denominator
        {
            get
            {
                return this._denominator;
            }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Ошибка. Деление на ноль");
                    throw new ArgumentException("Деление на ноль");
                }
                else
                {
                    this._denominator = value;
                };
            }
        }

        /// <summary>
        /// Конструктор простой дроби
        /// </summary>
        /// <param name="numerator">числитель дроби</param>
        /// <param name="denominator">знаменталель дроби</param>
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;

        }

        /// <summary>
        /// Метод для создания дроби из консоли
        /// </summary>
        /// <returns></returns>
        public static Fraction CreateFraction()
        {
            int numerator;
            int denominator;

            Console.WriteLine("Создание простой дроби из консоли:");

            Console.WriteLine("Введите числитель:");
            while (!int.TryParse(Console.ReadLine(), out numerator))
            {
                Console.WriteLine("Ошибка ввода. Введите числитель повторно:");
            }
                        
            Console.WriteLine("Введите знаменатель:");
            while (!int.TryParse(Console.ReadLine(), out denominator))
            {
                Console.WriteLine("Ошибка ввода. Введите знаменатель повторно:");
            }

            Fraction f = new Fraction(numerator, denominator);
            Console.WriteLine($"Создана дробь: {f.Numerator} / {f.Denominator} , десятичное представление: {f}");
            return f;
        } 

        /// <summary>
        /// Оператор сложения
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            //  приводим к общему знаменателю числители обоих дробей и возвращаем сумму числителей (следом упрощаем)
            return new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator)._simplier();
        }

        /// <summary>
        /// Оператор вычитания
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            //  приводим к общему знаменателю числители обоих дробей и возвращаем разность числителей (следом упрощаем)
            return new Fraction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator)._simplier();
        }

        /// <summary>
        /// Оператор умножения
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            //  приводим к общему знаменателю числители обоих дробей и возвращаем произведение числителей / знаменателей (следом упрощаем)
            return new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator)._simplier();
        }

        /// <summary>
        /// Оператор деления
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        public static Fraction operator /(Fraction f1, Fraction f2)
        {

            if (f2.Numerator == 0 || f2.Denominator == 0)
                throw new ArgumentException("Деление на ноль");
            //  приводим к общему знаменателю числители обоих дробей и возвращаем произведение числителей / знаменателей (следом упрощаем)
            Fraction f = new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
            
            return f._simplier();
        }

        /// <summary>
        /// Упрощение дроби
        /// </summary>
        /// <returns></returns>
        private Fraction _simplier()
        {

            Fraction temp = new Fraction(this.Numerator, this.Denominator);

            int fractionNod;
            do
            {
                fractionNod = _nod(this.Numerator, this.Denominator);
                if (fractionNod == 1 || fractionNod == 0)
                    break;
                this.Numerator /= fractionNod;
                this.Denominator /= fractionNod;
            } while (fractionNod > 1);

            if (this.Numerator == 0 || this.Denominator == 0) Console.WriteLine($"Divizion by Zero: {temp}");

            //Console.WriteLine($"Simplier: {this.Numerator} / {this.Denominator}");
            return this;
        }

        /// <summary>
        /// Получение наибольшего общего делителя
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>нод</returns>
        private static int _nod(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            else
            {
                while (b != 0)
                {
                    var temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }
        }

        /// <summary>
        /// Возвращаем текстовое представление объекта
        /// </summary>
        /// <returns>Дробь строкой</returns>
        public override string ToString()
        {
            return $"{(float) this.Numerator / (float) this.Denominator}";
        }
    }
}
