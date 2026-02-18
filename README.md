# PokemonAPI — Pokémon REST API in ASP.NET Core

A WebAPI providing comprehensive information about Pokémon games, built with ASP.NET Core, Entity Framework Core, and Swashbuckle. Query Pokémon stats, types, moves, and game data via a clean REST interface.

## ✨ Features
- Full Pokédex data via REST API
- Pokémon stats, types, abilities, and move sets
- Built on the official Veekun Pokémon database
- Swagger/OpenAPI documentation with Swashbuckle
- Entity Framework Core for data access

## 📦 Installation
```bash
git clone https://github.com/phmatray/PokemonAPI
cd PokemonAPI
# Download the database (see README for link)
dotnet run
```

## 🚀 Quick Start
```bash
dotnet run
# API available at: https://localhost:5001
# Swagger UI: https://localhost:5001/swagger
```

```http
GET /api/pokemon/pikachu
GET /api/pokemon?type=electric&limit=10
```

## 📄 License
MIT — see LICENSE
