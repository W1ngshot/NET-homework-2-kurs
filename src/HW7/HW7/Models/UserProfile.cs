using System.ComponentModel.DataAnnotations;

namespace HW7.Models
{
    public class UserProfile
    {
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [RegularExpression(@"^([A-Z]([a-z]+))|([А-Я]([а-я]+))$", ErrorMessage = "Неверные данные")]
        public string Surname { get; set; }
        
        [Display(Name = "Имя")] 
        [Required(ErrorMessage = "Это обязательное поле")]
        [RegularExpression(@"^([A-Z]([a-z]+))|([А-Я]([а-я]+))$", ErrorMessage = "Неверные данные")]
        public string Name { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Это обязательное поле")]
        [RegularExpression(@"^(([1-9])|([1-9][0-9])|(100))$", ErrorMessage = "Возраст может быть от 1 до 100")]
        public int Age { get; set; }
        
        [Display(Name = "Пол")]
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        [Display(Name = "Мужчина")]
        Male,
        [Display(Name = "Женщина")]
        Female
    }
}