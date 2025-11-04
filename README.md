## 💻 Como Executar

1. **Clonar o repositório**
   ```bash
   git clone https://github.com/seuusuario/techshoes-api.git
   cd techshoes-api
   ```

2. **Configurar o banco de dados**
   - No arquivo `appsettings.json`, atualize a string de conexão:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=techshoes;user=root;password=suasenha"
     }
     ```

3. **Rodar as migrações**
   ```bash
   dotnet ef database update
   ```

4. **Executar a API**
   ```bash
   dotnet run
   ```

5. **Acessar o Swagger**
   ```
   http://localhost:5000/swagger
   ```
