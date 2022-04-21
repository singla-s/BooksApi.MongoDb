using System;
using System.ComponentModel.DataAnnotations;

namespace BooksApi.MongoDb.Validator
{
    public class ReleaseDateValidator: ValidationAttribute
    {
        public override bool IsValid(object inDate)
        {
            var validation = (DateTime)inDate <= DateTime.Now.Date;
            return validation;
        }
    }
}
