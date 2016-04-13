﻿using System;
using System.Linq;

namespace DAL.Repositories.Practice
{

    using model = DAL.Models;
    using domain = LearnByPractice.Domain.Practice;

    class TehnologijaRepository : RepositoryBase
    {
         public TehnologijaRepository()
        {
        }
        public domain.TehnologijaCollection GetAll()
        {
            model.LearnByPracticeDataContext context = CreateContext();
            IQueryable<model.Tehnologija> query = context.Tehnologijas;
            domain.TehnologijaCollection result = new domain.TehnologijaCollection();
            foreach (model.Tehnologija modelObject in query)
            {
                domain.Tehnologija domainObject = new domain.Tehnologija();
                domainObject.Id = modelObject.ID;
                domainObject.Ime = modelObject.Ime;
                //domainObject.Oblast = modelObject.Oblast;
              result.Add(domainObject);
            }

            return result;
        }

        public domain.Tehnologija Get(int id)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                IQueryable<model.Tehnologija> query = context.Tehnologijas.Where(c => c.ID == id);

                domain.Tehnologija domainObject = ToDomain(query.Single());

                return domainObject;
            }
        }

        private domain.Tehnologija ToDomain(model.Tehnologija tehnologija)
        {
            throw new NotImplementedException();
        }


        public domain.Tehnologija Insert(domain.Tehnologija domainObject)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                model.Tehnologija modelObject = new model.Tehnologija();
                domainObject.Ime = modelObject.Ime;
                //domainObject.Oblast = modelObject.Oblast;
                context.Tehnologijas.InsertOnSubmit(modelObject);
                context.SubmitChanges();
                domain.Tehnologija result = ToDomain(modelObject);

                return result;

            }
        }
    }
    }
