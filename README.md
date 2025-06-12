# dotnet-CI  
  
![CI](https://github.com/Mateodiezq0/dotnet-CI/actions/workflows/ci.yml/badge.svg)  
![Docker Image](https://img.shields.io/docker/pulls/mateodiezq/dotnet-ci-app?logo=docker)  
  
Proyecto de integración continua con .NET 7, Svelte + TypeScript y Docker.    
CI/CD completo con GitHub Actions y deploy a Render.  
  
## 🔗 Demo  
  
[Visitar app en Render](https://dotnet-ci.onrender.com/)  
  
## 📋 Descripción Detallada  
  
Este proyecto es una demostración completa de desarrollo full-stack moderno con prácticas DevOps avanzadas. El sistema implementa dos funcionalidades principales: un juego de adivinanza de palabras estilo Wordle donde los usuarios intentan adivinar la palabra objetivo "svelte", y una calculadora básica para operaciones aritméticas.  
  
### ¿Qué hace exactamente la aplicación?  
  
#### 🎯 Juego de Adivinanza de Palabras  
La aplicación presenta un juego simple donde el usuario debe adivinar una palabra secreta. [1](#3-0)  La palabra objetivo está hardcodeada como "svelte" y el juego funciona de la siguiente manera:  
  
1. **Frontend Interactivo**: [2](#3-1)  El usuario ingresa una palabra en un campo de texto y recibe retroalimentación inmediata del servidor.  
  
2. **Validación Backend**: [3](#3-2)  El endpoint `/comprobar` recibe la palabra, valida que no esté vacía, y compara con la palabra objetivo usando comparación insensible a mayúsculas/minúsculas.  
  
3. **Comunicación Asíncrona**: [4](#3-3)  El frontend utiliza fetch API para comunicarse con el backend, manejando tanto respuestas exitosas como errores.  
  
#### 🧮 Calculadora Funcional  
La aplicación incluye una calculadora básica que demuestra patrones de inyección de dependencias:  
  
1. **Clase de Negocio**: [5](#3-4)  Una clase `Calculadora` simple que implementa operaciones matemáticas básicas (actualmente solo suma).  
  
2. **Inyección de Dependencias**: [6](#3-5)  La calculadora se registra como singleton en el contenedor de DI de ASP.NET Core.  
  
3. **API Endpoint**: [7](#3-6)  El endpoint `/sumar` acepta dos parámetros enteros y retorna el resultado de la suma.  
  
### 🏗️ Arquitectura Técnica  
  
#### Backend (.NET 7)  
- **Framework**: [8](#3-7)  Construido sobre .NET 7.0 usando ASP.NET Core con APIs mínimas  
- **CORS Configuration**: [9](#3-8)  Configuración robusta de CORS que permite comunicación cross-origin con el frontend  
- **Dependency Injection**: Utiliza el contenedor DI nativo de .NET para gestión de servicios  
- **File Serving**: Capacidad de servir archivos estáticos incluyendo reportes de cobertura HTML  
  
#### Frontend (Svelte + TypeScript)  
- **Framework Moderno**: Svelte 5.33.14 con TypeScript para type safety  
- **Build System**: Vite 6.3.5 para desarrollo rápido y builds optimizados  
- **Environment Configuration**: [10](#3-9)  Configuración flexible del backend URL via variables de entorno  
  
## 🧪 Stack Tecnológico Completo  
  
| Componente | Tecnología | Versión | Propósito Específico |  
|-----------|------------|---------|---------------------|  
| Backend Framework | .NET 7.0 + ASP.NET Core | 7.0.x | API REST, inyección de dependencias, middleware |  
| Frontend Framework | Svelte + TypeScript | 5.33.14 | Interfaz reactiva, type safety |  
| Build System | Vite | 6.3.5 | Hot reload, bundling optimizado |  
| Testing Framework | xUnit + Coverlet | Latest | Unit testing, code coverage |  
| Containerización | Docker | Multi-stage | Builds reproducibles, deployment |  
| CI/CD Platform | GitHub Actions | Latest | Automatización completa del pipeline |  
| Code Coverage | ReportGenerator | 5.1.26 | Reportes HTML detallados |  
| Hosting | Render | Cloud | Deployment automático |  
| Notifications | Discord Webhooks | API | Notificaciones de build status |  
| AI Integration | DeepSeek via OpenRouter | API | Análisis inteligente de errores |  
  
## 🔄 Pipeline CI/CD Detallado  
  
### Flujo de Integración Continua  
  
#### 1. Triggers y Configuración [11](#3-10)  El pipeline se activa automáticamente en:  
- Push a la rama `main`  
- Pull requests hacia `main`  
  
#### 2. Preparación del Entorno [12](#3-11)  El workflow configura:  
- Ubuntu como runner environment  
- .NET 7.0 SDK installation  
- [13](#3-12)  Cache inteligente de dependencias NuGet para optimizar tiempos de build  
  
#### 3. Build y Testing [14](#3-13)  El proceso incluye:  
- `dotnet restore`: Restauración de dependencias con logging  
- `dotnet build`: Compilación sin restore para eficiencia  
- `dotnet test`: Ejecución de tests con cobertura XPlat Code Coverage  
- Captura de logs detallados para debugging  
  
#### 4. Análisis de Cobertura [15](#3-14)  Generación de reportes:  
- Instalación de ReportGenerator tool  
- Conversión de archivos Cobertura XML a HTML  
- [16](#3-15)  Copia de reportes a directorios frontend y backend para accesibilidad  
  
#### 5. Containerización [17](#3-16)  Proceso Docker:  
- Build de imagen con tag `dotnet-ci-app`  
- Login automático a Docker Hub usando secrets  
- Push de imagen taggeada al registry  
  
#### 6. Deployment Automático [18](#3-17)  Triggers de deployment:  
- Webhook calls a Render para frontend deployment  
- Webhook calls a Render para backend deployment  
  
### Sistema de Notificaciones Inteligentes  
  
#### Notificaciones de Éxito [19](#3-18)  Cuando el pipeline es exitoso:  
- Embed rico en Discord con información del commit  
- Links directos al GitHub Actions run  
- Metadata del autor y timestamp  
  
#### Análisis AI de Errores [20](#3-19)  En caso de fallos:  
- Captura automática de logs de error (test, docker build, docker login)  
- Envío de logs a DeepSeek AI via OpenRouter API  
- Generación de explicaciones educativas para estudiantes  
- Notificación Discord con análisis AI incluido  
  
## 🐳 Containerización Multi-Stage [21](#3-20)  El Dockerfile implementa:  
  
### Stage 1: Build  
- Base image: `mcr.microsoft.com/dotnet/sdk:7.0`  
- Copia y restauración de dependencias  
- Compilación y publicación en modo Release  
  
### Stage 2: Runtime [22](#3-21)    
- Base image: `mcr.microsoft.com/dotnet/aspnet:7.0` (más liviana)  
- Copia de archivos publicados  
- Inclusión de reportes de cobertura  
- Configuración de entry point  
  
## 🧪 Testing y Calidad  
  
### Unit Testing [23](#3-22)  El proyecto incluye:  
- Tests xUnit para la funcionalidad de calculadora  
- [24](#3-23)  Coverlet collector para análisis de cobertura  
- Validación automática de lógica de negocio  
  
### Code Coverage  
- Generación automática de reportes HTML  
- Métricas detalladas de cobertura por archivo y método  
- Integración en el pipeline CI/CD  
- Accesibilidad via endpoints web  
  
## 📊 Endpoints API Disponibles  
  
| Endpoint | Método | Parámetros | Descripción | Ejemplo |  
|----------|--------|------------|-------------|---------|  
| `/` | GET | Ninguno | Saludo básico | `"Hola CI!"` |  
| `/sumar` | GET | `a` (int), `b` (int) | Suma dos números | `/sumar?a=5&b=3` → `8` |  
| `/comprobar` | GET | `palabra` (string) | Valida palabra objetivo | `/comprobar?palabra=svelte` |  
| `/coverage/{fileName}.html` | GET | `fileName` (string) | Reportes de cobertura | `/coverage/index.html` |  
  
## 🛠️ Desarrollo Local  
  
### Prerrequisitos  
- .NET 7.0 SDK  
- Node.js (para frontend)  
- Docker (opcional)  
  
### Pasos de Setup  
1. **Clonar repositorio**: `git clone [repo-url]`  
2. **Backend setup**:  
   ```bash  
   cd src  
   dotnet restore  
   dotnet build  
   dotnet run
2. **Frontend setup**:  
   ```bash  
   cd frontend  
   npm install  
   npm run dev
## 📈 Características Avanzadas 
### DevOps Features  
- Dependency Caching: Optimización de builds mediante cache de NuGet packages
- Multi-Environment Support: Configuración flexible via environment variables 
- Automated Deployments: Zero-downtime deployments a Render
- Health Monitoring: Logs detallados y error tracking

### Educational Features  
- AI-Powered Error Analysis: Explicaciones automáticas de fallos para estudiantes
- Comprehensive Logging: Trazabilidad completa del pipeline
- Visual Coverage Reports: Reportes HTML interactivos
- Discord Integration: Notificaciones en tiempo real del estado del proyecto

### Security & Best Practices
- Secrets Management: Uso seguro de GitHub Secrets
- CORS Configuration: Políticas de seguridad cross-origin
- Multi-Stage Builds: Separación de build y runtime dependencies
- Dependency Injection: Patrones de arquitectura limpia