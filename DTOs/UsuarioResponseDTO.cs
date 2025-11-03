namespace CadastroUsuarios.Api.DTOs
{
    public class UsuarioResponseDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
