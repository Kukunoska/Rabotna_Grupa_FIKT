﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using LearnByPractice.Domain.Security;
using LearnByPractice.Domain.Education;
using LearnByPractice.Domain.Organizational;
using LearnByPractice.DAL.Repositories.Security;
using LearnByPractice.DAL.Repositories.Education;
using LearnByPractice.DAL.Repositories.Organizational;

namespace LearnByPractice.Tests.DAL.Respositories.Security
{
    public class KorisnikRespositoryTests
    {
        [Test]
        public void GetAllTest()
        {
 
            KorisnikRepository repository = new KorisnikRepository();
            KorisnikCollection zemi = repository.GetAll();
            Assert.IsNotNull(zemi);

            //Assert.IsTrue(zemi.Count >= 3);

            foreach ( Korisnik korisnik in zemi)
            {
                Console.WriteLine("KорисникИД: {0}, Име: {1}, Презиме: {2}, Пол: {3}, Студиска Програма: {4}, Организација: {5}, Еmail: {6}, Мобилен: {7}, ", korisnik.IdKorisnik, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.studiskaPrograma.Ime, korisnik.organizacija.Ime, korisnik.Email, korisnik.Mobilen);
            }
        }
        protected PolEnum SlucaenIzbor()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int randomInt = random.Next(1, 3);
            switch (randomInt)
            {
                case 1:
                    return PolEnum.Mashki;

                case 2:
                    return PolEnum.Zhenski;

                default:
                    throw new InvalidOperationException("Добиена е случајна вредност надвор од дадените граници.");
            }
        }

        [Test]
        public void InsertTest()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            StudiskaProgramaRepository studiskaProgRep = new StudiskaProgramaRepository();
            StudiskaProgramaCollection siteStudiskiProg = new StudiskaProgramaCollection();
            int StudProgID = random.Next(0, siteStudiskiProg.Count);
            StudiskaPrograma izbranaProg = siteStudiskiProg[StudProgID];

            VidOrganizacijaRespository orgRep = new VidOrganizacijaRespository();
            VidOrganizacijaCollection siteOrganizacii = new VidOrganizacijaCollection();
            int VidOrgID = random.Next(0, siteOrganizacii.Count);
            VidOrganizacija izbranaOrg = siteOrganizacii[VidOrgID];
            
            Korisnik korisnik = new Korisnik();
            korisnik.Ime = string.Format("Корисник {0}", Guid.NewGuid().ToString());
            korisnik.Prezime = string.Format("Корисник {0}", Guid.NewGuid().ToString());
            korisnik.Pol = SlucaenIzbor();
            korisnik.studiskaPrograma.Ime = izbranaProg.Ime;
            korisnik.organizacija.Ime = izbranaOrg.Ime;
            korisnik.Email = string.Format("Корисник {0}", Guid.NewGuid().ToString());
            korisnik.Mobilen = string.Format("Корисник {0}", Guid.NewGuid().ToString());

            KorisnikRepository repository = new KorisnikRepository();
            Korisnik dodadete = repository.Insert(korisnik); 

            Assert.IsNotNull(dodadete);
            Assert.AreEqual(korisnik.Ime, dodadete.Ime);
            Assert.AreEqual(korisnik.Prezime, dodadete.Prezime);
            Assert.AreEqual(korisnik.Pol, dodadete.Pol);
            Assert.AreEqual(korisnik.studiskaPrograma.Ime, dodadete.studiskaPrograma.Ime);
            Assert.AreEqual(korisnik.organizacija.Ime, dodadete.organizacija.Ime);
            Assert.AreEqual(korisnik.Email, dodadete.Email);
            Assert.AreEqual(korisnik.Mobilen, dodadete.Mobilen);

            Console.WriteLine("Додаден е нов корисник: KорисникИД: {0}, Име: {1}, Презиме: {2}, Пол: {3}, Студиска Програма: {4}, Организација: {5}, Еmail: {6}, Мобилен: {7}, ", dodadete.IdKorisnik, dodadete.Ime, dodadete.Prezime, dodadete.Pol, dodadete.studiskaPrograma.Ime, dodadete.organizacija.Ime, dodadete.Email, dodadete.Mobilen);
        }

    }
    }