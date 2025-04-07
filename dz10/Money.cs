using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz10
{
    public class Money
    {
        private int grivna;
        private int kopeka;

        public int Grivna
        {
            get { return grivna; }
            private set
            {
                if (value < 0)
                    throw new BankruptException("Сумма не может быть отрицательной");
                grivna = value;
            }
        }

        public int Kopiyka
        {
            get { return kopeka; }
            private set
            {
                if (value < 0 || value >= 100)
                {
                    Grivna += value / 100;
                    value = value % 100;
                }
                kopeka = value;
            }
        }

        public Money(int hryvnia, int kopiyka)
        {
            Grivna = hryvnia;
            Kopiyka = kopiyka;
            Normalize();
        }

        private void Normalize()
        {
            Grivna += Kopiyka / 100;
            Kopiyka = Kopiyka % 100;
        }


        public static Money operator +(Money m1, Money m2)
        {
            return new Money(m1.Grivna + m2.Grivna, m1.Kopiyka + m2.Kopiyka);
        }


        public static Money operator -(Money m1, Money m2)
        {
            int totalKopek1 = m1.Grivna * 100 + m1.Kopiyka;
            int totalKopek2 = m2.Grivna * 100 + m2.Kopiyka;
            int result = totalKopek1 - totalKopek2;

            if (result < 0)
                throw new BankruptException("отрицательная сумма");

            return new Money(0, result);
        }

        public static Money operator /(Money m, int del)
        {
            if (del <= 0)
                throw new ArgumentException("2 число должно быть больще 0");

            int totalKopek = m.Grivna * 100 + m.Kopiyka;
            int result = totalKopek / del;

            return new Money(0, result);
        }


        public static Money operator *(Money m, int multiplier)
        {
            if (multiplier < 0)
                throw new ArgumentException("Больше нуля должно быть число");

            return new Money(m.Grivna * multiplier, m.Kopiyka * multiplier);
        }


        public static Money operator ++(Money m)
        {
            return new Money(m.Grivna, m.Kopiyka + 1);
        }


        public static Money operator --(Money m)
        {
            int totalKopek = m.Grivna * 100 + m.Kopiyka - 1;

            if (totalKopek < 0)
                throw new BankruptException("отрицательная сумма");

            return new Money(0, totalKopek);
        }


        public static bool operator <(Money m1, Money m2)
        {
            return (m1.Grivna * 100 + m1.Kopiyka) < (m2.Grivna * 100 + m2.Kopiyka);
        }

        public static bool operator >(Money m1, Money m2)
        {
            return (m1.Grivna * 100 + m1.Kopiyka) > (m2.Grivna * 100 + m2.Kopiyka);
        }

        public static bool operator ==(Money m1, Money m2)
        {
            return (m1.Grivna == m2.Grivna) && (m1.Kopiyka == m2.Kopiyka);
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1 == m2);
        }

        public override int GetHashCode()
        {
            return Grivna * 100 + Kopiyka;
        }

        public override string ToString()
        {
            return $"{Grivna} грн {Kopiyka} коп";
        }
    }


}

