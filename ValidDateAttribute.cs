using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homma
{
    public class ValidDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            NewItem item = (NewItem)validationContext.ObjectInstance;
            if (item.CreationDate > DateTime.Now) {
                return new ValidationResult("You dun fuQ'd up.");
            }
            return ValidationResult.Success;

        } 
    }
    public class ValidItemTypeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext){
            NewItem item = (NewItem)validationContext.ObjectInstance;
            foreach (ItemType it in Enum.GetValues(typeof(ItemType))) {
                if (item.itemType == it)
                    return ValidationResult.Success;
            }
            return new ValidationResult("You dun fuQ'd up.");
        } 
    }

    public class TooLowLevel : Exception
    {
        public TooLowLevel() {

        }

        public TooLowLevel(string message) : base(message) {

        }

        public TooLowLevel(string message, Exception inner) : base(message, inner) {

        }
    }

    // En tienny mitä tehdä tässä. Ota siitä mitä pisteitä nyt otat.
    public class LevelFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is TooLowLevel){
                return;
            }
            context.Result = new BadRequestResult();
        }
    }
}