# 📚 Blazor BookStore Management Frontend

A modern **Blazor WebAssembly (.NET 6)** frontend application built for the BookStore Management System.  
This application interacts with the backend GraphQL API to perform secure CRUD operations on **Authors** and **Books**.

---

## 🚀 Features

- 🔐 **JWT Authentication** using login credentials
- 👥 **Authors Management**
  - View, Add, Update, Delete Authors
  - View all Books under each Author
- 📘 **Books Management**
  - View, Add, Update, Delete Books
- 🧠 **GraphQL Integration** with typed queries and mutations
- 🎨 **Responsive Blazor UI** with modal-based forms
- 💾 **Local Storage Token Management** for session persistence

---

## 🧩 Tech Stack

| Layer | Technology |
|--------|-------------|
| Framework | Blazor WebAssembly (.NET 6) |
| Authentication | JWT (JSON Web Token) |
| API Integration | GraphQL Client |
| Storage | Blazored.LocalStorage |
| Styling | Bootstrap / Blazor Components |
| State Management | CascadingAuthenticationState / ClaimsPrincipal |

---

## 🔧 Project Setup

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/your-repo/bookstore-frontend.git
cd bookstore-frontend
```

### 2️⃣ Configure the Backend API URL
In `Program.cs` or `appsettings.json`, update your backend GraphQL endpoint (running on .NET 6 backend):
```csharp
builder.Services.AddScoped(s => new GraphQLHttpClient("https://localhost:5001/graphql", new SystemTextJsonSerializer()));
```

### 3️⃣ Run the Project
```bash
dotnet run
```
Open in browser: [https://localhost:7119](https://localhost:7119)

---

## 🔑 Login Credentials

| Username | Password |
|-----------|-----------|
| aim_admin | Test@321 |

---

## ⚙️ How It Works

1. **Login** → Uses JWT authentication via GraphQL `login` mutation.  
2. **Token Storage** → JWT is stored securely in local storage.  
3. **Authenticated Access** → GraphQL requests automatically include the JWT for secure data access.  
4. **CRUD Operations** → Manage Authors and Books through modals (create/edit/delete).  
5. **Token Expiry Handling** → If token is expired or missing, user is redirected to login page automatically.

---

## 🧠 Application Flow

```
[Login Screen] → [Dashboard]
                   ├── Authors List → Author Details (Books)
                   └── Books List → Add / Edit / Delete
```

---

## 🧱 Folder Structure

```
📦 FEBookStoreManagement
 ┣ 📂 Pages
 ┃ ┣ 📜 Login.razor
 ┃ ┣ 📜 Authors.razor
 ┃ ┗ 📜 Books.razor
 ┣ 📂 Components
 ┃ ┣ 📜 AddOrUpdateAuthorModal.razor
 ┃ ┗ 📜 AddOrUpdateBookModal.razor
 ┣ 📂 Utilities
 ┃ ┗ 📜 JwtAuthenticationServiceProvider.cs
 ┣ 📂 GraphQL
 ┃ ┣ 📜 Queries
 ┃ ┗ 📜 Mutations
 ┗ 📜 Program.cs
```

---

## 🛡️ Security

- All GraphQL queries and mutations are secured with JWT authentication.  
- If token is invalid or expired, Blazor automatically redirects to login page.  
- API calls are protected via GraphQL authorization policies.

---

## 🧰 Development Notes

- Automatic token validation and logout when expired.  
- Pre-rendering safe checks for Blazor server-side JS interop.  
- Extensible structure for future modules.

---

## 🧑‍💻 Author

**AIM BookStore Management Team**  
Built with ❤️ using **Blazor** and **GraphQL**.

---
