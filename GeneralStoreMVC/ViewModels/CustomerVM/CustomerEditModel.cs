using System.ComponentModel.DataAnnotations;

namespace GeneralStoreMVC.ViewModels.CustomerVM
{
    public class CustomerEditModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}