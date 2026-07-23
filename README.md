![PokemonAPI banner](.github/banner.png)

# PokemonAPI — Pokémon REST API in ASP.NET Core

<!-- portfolio-badges:start -->
<!-- Identity -->
[![phmatray - PokemonAPI](https://img.shields.io/static/v1?label=phmatray&message=PokemonAPI&color=blue&logo=github)](https://github.com/phmatray/PokemonAPI)
![Top language](https://img.shields.io/github/languages/top/phmatray/PokemonAPI)
[![Stars](https://img.shields.io/github/stars/phmatray/PokemonAPI?style=social)](https://github.com/phmatray/PokemonAPI/stargazers)
[![Forks](https://img.shields.io/github/forks/phmatray/PokemonAPI?style=social)](https://github.com/phmatray/PokemonAPI/network/members)

<!-- Activity -->
[![Issues](https://img.shields.io/github/issues/phmatray/PokemonAPI)](https://github.com/phmatray/PokemonAPI/issues)
[![Pull requests](https://img.shields.io/github/issues-pr/phmatray/PokemonAPI)](https://github.com/phmatray/PokemonAPI/pulls)
[![Last commit](https://img.shields.io/github/last-commit/phmatray/PokemonAPI)](https://github.com/phmatray/PokemonAPI/commits)
<!-- portfolio-badges:end -->


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
