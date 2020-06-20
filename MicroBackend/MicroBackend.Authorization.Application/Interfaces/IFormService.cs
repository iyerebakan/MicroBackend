using MicroBackend.Authorization.Domain.Dtos;
using MicroBackend.Authorization.Domain.Models;
using MicroBackend.Domain.Core.Mongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Application.Interfaces
{
    public interface IFormService
    {
        void Add(Form form);
        List<FormListDto> GetList();
    }
}
