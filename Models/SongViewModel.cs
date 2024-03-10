using System.ComponentModel.DataAnnotations;

namespace StartDialog.Models
{
    public class SongViewModel
    {
        [Required(ErrorMessage = "Поле 'Назва' обовязкове для заповнення")]
        [MaxLength(100, ErrorMessage = "Максимальна довжина - 100 символів")]
       
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле 'Виконавець' обовязкове для заповнення")]
        public string Artist { get; set; }

        [Required(ErrorMessage = "Поле 'Музика' обовязкове для заповнення")]
        public IFormFile File { get; set; } 
    }

}
