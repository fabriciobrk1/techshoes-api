using System.Text.RegularExpressions;

namespace CadastroUsuarios.Api.Helpers
{
    public class Validador
    {
        public static bool NomeValido(string nome) =>
            Regex.IsMatch(nome, @"^[A-Za-zÀ-ÿ\s]+$");

        public static bool CPFValido(string cpf) =>
            Regex.IsMatch(cpf, @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");

        public static bool TelefoneValido(string telefone) =>
            Regex.IsMatch(telefone, @"^\(\d{2}\)\s\d{5}\-\d{4}$");

        public static bool EmailValido(string email) =>
            Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");

        public static bool SenhaForte(string senha) =>
            Regex.IsMatch(senha, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$");
    }
}

