namespace WorkShop.Domain.Core.Models
{
    public class ResultModel<T>: ValidateModel
    {
        public T Object {get;set;}
        
    }
}