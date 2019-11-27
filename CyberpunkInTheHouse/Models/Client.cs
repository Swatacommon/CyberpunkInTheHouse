using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CyberpunkInTheHouse.Models
{
    public class Client
    {
        private static Client clienty;

        private int id;
        private int role;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private int telephone;
        private string adres;

        [ScaffoldColumn(false)]
        public int Id { get => id; set => id = value; }

        [ScaffoldColumn(false)]
        public int Role { get => role; set => role = value; }

        //TODO: Не совсем доделанная регулярка, надо добавить русский язык и нормально протестить, почему-то можно несколько больших букв вначале строки и дописать остальные регулярки для свойств
        [RegularExpression(@"^([A-Z][a-z]+|[A-ЯЁ][а-яё]+)*", ErrorMessage = "Введите корректное имя")]
        [Required(ErrorMessage = "Введите Имя")]
        [Display(Name = "First name")]
        public string FirstName { get => firstName; set => firstName = value; }


        [RegularExpression(@"^[A-Z](['-][a-zA-Z]+)*", ErrorMessage = "Введите корректную фамилию")]
        [Display(Name = "Last name")]
        public string LastName { get => lastName; set => lastName = value; }


        [Required(ErrorMessage = "Введите Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный Email")]
        [Display(Name = "Email")]
        public string Email { get => email; set => email = value; }

        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Некорректный пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get => password; set => password = value; }


        [Required(ErrorMessage = "Введите телефон")]
        [Display(Name = "Telephone")]
        public int Telephone { get => telephone; set => telephone = value; }


        [Required(ErrorMessage = "Введите адрес")]
        [Display(Name = "Adres")]
        public string Adres { get => adres; set => adres = value; }


        public static Client Clienty { get => clienty; set => clienty = value; }

        public Client(int id, int role, string firstName, string lastName, string email, int telephone, string adres)
        {
            Id = id;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            Adres = adres;
        }

        public Client() { }
    }
}