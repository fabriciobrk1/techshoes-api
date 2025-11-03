using CadastroUsuarios.Api.Data;
using CadastroUsuarios.Api.DTOs;
using CadastroUsuarios.Api.Helpers;
using CadastroUsuarios.Api.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace CadastroUsuarios.Api.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Sucesso, string Mensagem)> RegistrarUsuario(UsuarioCreateDTO dto)
        {
            try
            {
                // Validações
                if (!Validador.NomeValido(dto.NomeCompleto))
                    return (false, "Nome inválido (somente letras e espaços).");

                if (dto.Idade < 18)
                    return (false, "Usuário deve ter 18 anos ou mais.");

                if (!Validador.CPFValido(dto.CPF))
                    return (false, "CPF inválido.");

                if (!Validador.TelefoneValido(dto.Telefone))
                    return (false, "Telefone inválido.");

                if (!Validador.EmailValido(dto.Email))
                    return (false, "E-mail em formato inválido.");

                if (!Validador.SenhaForte(dto.Senha))
                    return (false, "Senha fraca. Use letras maiúsculas, minúsculas e números.");

                if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                    return (false, "E-mail já cadastrado.");

                if (await _context.Usuarios.AnyAsync(u => u.CPF == dto.CPF))
                    return (false, "CPF já cadastrado.");

                var usuario = new Usuario
                {
                    NomeCompleto = dto.NomeCompleto,
                    Idade = dto.Idade,
                    CPF = dto.CPF,
                    Telefone = dto.Telefone,
                    Endereco = dto.Endereco,
                    Cidade = dto.Cidade,
                    Estado = dto.Estado,
                    Email = dto.Email,
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return (true, "Usuário registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return (false, $"Erro interno: {ex.Message}");
            }
        }

        public async Task<UsuarioResponseDTO?> Login(UsuarioLoginDTO dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (usuario == null) return null;

            bool senhaOk = BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);
            if (!senhaOk) return null;

            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                NomeCompleto = usuario.NomeCompleto,
                Email = usuario.Email
            };
        }
    }
}

