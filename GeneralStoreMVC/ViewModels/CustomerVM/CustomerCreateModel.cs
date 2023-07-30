using System.ComponentModel.DataAnnotations;

namespace GeneralStoreMVC.ViewModels.CustomerVM
{
    public class CustomerCreateModel
    {
        [Required]
        [MinLength(3,ErrorMessage ="Name must exceed 3 characters!")]
         public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
    }
}