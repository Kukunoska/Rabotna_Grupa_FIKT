﻿using System;
using LearnByPractice.Domain.Organizational;

namespace LearnByPractice.Domain.Practice
{
    /// <summary>Класа за пријава.</summary>
    public class Prijava
    {
        /// <summary>Шифра </summary>
        /// <value>Ја зема/поставува шифрата на пријавата</value>
        public int Id { get; set; }

        /// <summary>Објект од класа <c>Organizacija</c> </summary>
        public Organizacija organizacija = new Organizacija();

        /// <summary>Датум на пријавата</summary>
        /// <value>Го зема/поставува датумот на пријавата</value>
        public DateTime Datum
        { get; set; }

        /// <summary> Конструктор на класата <c>Prijava</c>, без параметри. </summary>
        public Prijava() { Datum = DateTime.Today; }
    }
}
