﻿using System;
using System.Linq;
using model = DAL.Models;
using domain = LearnByPractice.Domain.Education;

namespace DAL.Repositories.Education
{
    public class PredmetRepository : RepositoryBase
    {
        public PredmetRepository()
        {
        }
        public domain.PredmetCollection GetAll()
        {
            model.LearnByPracticeDataContext context = CreateContext();
            IQueryable<model.Predmet> query = context.Predmets;
            domain.PredmetCollection result = new domain.PredmetCollection();
            foreach (model.Predmet modelObject in query)
            {
                domain.Predmet domainObject = new domain.Predmet();
                domainObject.Id = modelObject.ID;
                domainObject.Ime = modelObject.Ime;
                result.Add(domainObject);
            }

            return result;
        }

        public domain.Predmet Get(int id)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                IQueryable<model.Predmet> query = context.Predmets.Where(c => c.ID == id);

                domain.Predmet domainObject = ToDomain(query.Single());

                return domainObject;
            }
        }


        public domain.Predmet Insert(domain.Predmet domainObject)
        {
            using (model.LearnByPracticeDataContext context = CreateContext())
            {
                model.Predmet modelObject = new model.Predmet();
                modelObject.Ime = domainObject.Ime;
                context.Predmets.InsertOnSubmit(modelObject);
                context.SubmitChanges();
                domain.Predmet result = ToDomain(modelObject);

                return result;

            }
        }

        private domain.Predmet ToDomain(model.Predmet modelObject)
        {
            throw new NotImplementedException();
        }
    }
}

