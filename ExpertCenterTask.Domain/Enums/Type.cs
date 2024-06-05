using System.ComponentModel.DataAnnotations;

namespace ExpertCenterTask.Domain.Enums
{
    public enum Type
    {
        [Display(Name = "Число")]
        Number = 1,

        [Display(Name = "Строка")]
        SingleString = 2,

        [Display(Name = "Текст")]
        MultiString = 3
    }
}
