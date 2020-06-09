using MicroBackend.Authorization.Application.Interfaces;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Services
{
    public class FormManager : MongoRepositoryBase<Form>, IFormService
    {
        public FormManager(MongoHelper mongoHelper) : base(mongoHelper)
        {
        }

       
    }
}
