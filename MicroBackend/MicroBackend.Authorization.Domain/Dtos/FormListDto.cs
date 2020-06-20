using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Authorization.Domain.Dtos
{
    public class FormListDto
    {
        public string FormId { get; set; }
        public string FormName { get; set; }
        public string FolderName { get; set; }
    }
}
