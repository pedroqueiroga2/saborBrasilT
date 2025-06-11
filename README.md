# Sabor do Brasil

Bem-vindo ao **Sabor do Brasil**!

Este projeto é um site para compartilhar pratos típicos brasileiros, onde usuários podem cadastrar, curtir e comentar pratos, além de criar uma conta com foto de perfil.

---

## Funcionalidades

- **Cadastro e Login de Usuário**
  - Cadastro com nome, CPF, e-mail, senha e foto de perfil.
  - Login com persistência de sessão via localStorage.

- **Página Principal**
  - Lista de pratos cadastrados, com imagem, descrição, autor e data.
  - Curtidas (like/unlike) em cada prato (apenas para usuários logados).
  - Botão para adicionar novo prato (apenas para usuários logados).
  - Ao clicar em um prato, abre a página de detalhes.

- **Cadastro de Prato**
  - Formulário para adicionar novo prato com imagem, nome e descrição.

- **Comentários**
  - Usuários logados podem comentar nos pratos.

- **Foto de Perfil**
  - Upload de foto de perfil no cadastro.
  - Quando logado, a logo do site é substituída pela foto de perfil do usuário.

---

## Estrutura de Pastas

```
wwwroot/
├── index.html                # Página principal (lista de pratos)
├── login.html                # Tela de login
├── Cadastro.html             # Tela de cadastro de usuário
├── Cadastro de Produto.html  # Tela de cadastro de prato
├── uploads/                  # Imagens de pratos e perfis
│   └── ...
└── ...
```

---

## Como rodar

1. **Backend**
   - Certifique-se de que a API está rodando (exemplo: ASP.NET Core).
   - Por padrão, a API deve responder em `http://localhost:5172/`.

2. **Frontend**
   - Abra o arquivo `wwwroot/index.html` no navegador **ou** acesse via rota do backend (ex: `http://localhost:5172/index.html`).

---

## Observações Técnicas

- O estado de login é salvo no localStorage (`isLoggedIn`, `userId`, `userName`, `userPhoto`).
- O botão "Adicionar Prato" só aparece para usuários logados.
- A logo do site é trocada pela foto de perfil do usuário após login.
- O upload de foto de perfil é feito no cadastro do usuário.
- O upload de imagem do prato é feito no cadastro de prato.
- As curtidas e comentários são integrados com a API.

---

## Requisitos

- Navegador moderno (Chrome, Edge, Firefox)
- Backend compatível com as rotas usadas no frontend (`/api/publicacoes`, `/api/comentarios`, `/Usuario/Login`, `/Usuario/Cadastrar` etc.)

---

## Personalização

- Para trocar a logo padrão, substitua o arquivo em `wwwroot/uploads/main-header.avif`.
- Para alterar estilos, edite os `<style>` dos arquivos HTML.

---

**Sabor do Brasil** - Compartilhe o melhor da nossa culinária!

