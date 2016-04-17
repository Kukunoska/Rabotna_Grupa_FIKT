﻿using System;
using System.Linq;
using domain = LearnByPractice.Domain.Organizational;
using model = DAL.Models;

namespace DAL.Repositories.Organizational
{
    public class VidOrganizacijaRespository : RepositoryBase
    {
        public VidOrganizacijaRespository()
       {
       }

       public domain.VidOrganizacijaCollection GetAll()
       {
           model.LearnByPracticeDataContext context = CreateContext();
           IQueryable<model.Vid_Organizacija> query = context.Vid_Organizacijas;
           domain.VidOrganizacijaCollection result = new domain.VidOrganizacijaCollection();
           foreach (model.Vid_Organizacija modelObject in query)
           {
               domain.VidOrganizacija domainObject = new domain.VidOrganizacija();
               domainObject.Id = modelObject.ID;
               domainObject.Ime = modelObject.Ime;
               result.Add(domainObject);
           }

           return result;
       }

       public domain.VidOrganizacija Get(int id)
       {
           using (model.LearnByPracticeDataContext context = CreateContext())
           {
               IQueryable<model.Vid_Organizacija> query = context.Vid_Organizacijas.Where(c => c.ID == id);

               domain.VidOrganizacija domainObject = ToDomain(query.Single());

               return domainObject;
           }
       }

  
       public domain.VidOrganizacija Insert(domain.VidOrganizacija domainObject)
       {
           using (model.LearnByPracticeDataContext context = CreateContext())
           {
               model.Vid_Organizacija modelObject = new model.Vid_Organizacija();
               modelObject.Ime = domainObject.Ime;
               context.Vid_Organizacijas.InsertOnSubmit(modelObject);
               context.SubmitChanges();
               domain.VidOrganizacija result = ToDomain(modelObject);
               return result;

           }
       }

     private domain.VidOrganizacija ToDomain(model.Vid_Organizacija vid_Organizacija)
       {
           throw new NotImplementedException();
       }

    }

    }
