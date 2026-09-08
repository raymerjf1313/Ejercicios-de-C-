# Script para crear estructura de carpetas para ejercicios C#
# Ejecutar desde PowerShell como administrador

# Crear carpeta raíz
$rootPath = "CSharp-Ejercicios"
New-Item -ItemType Directory -Path $rootPath -Force | Out-Null
Set-Location $rootPath

# Crear estructura de carpetas
$folders = @(
    "01-Conceptos-Basicos\Variables-y-Tipos",
    "01-Conceptos-Basicos\Operadores",
    "01-Conceptos-Basicos\Control-de-Flujo",
    "02-Programacion-Orientada-Objetos\Clases-y-Objetos",
    "02-Programacion-Orientada-Objetos\Herencia",
    "02-Programacion-Orientada-Objetos\Polimorfismo",
    "02-Programacion-Orientada-Objetos\Encapsulacion",
    "03-Estructuras-Datos\Arrays",
    "03-Estructuras-Datos\Listas",
    "03-Estructuras-Datos\Diccionarios",
    "03-Estructuras-Datos\Pilas-Colas",
    "04-LINQ-y-Colecciones",
    "05-Manejo-Excepciones",
    "06-Async-Await",
    "07-Proyectos-Integrales"
)

foreach ($folder in $folders) {
    New-Item -ItemType Directory -Path $folder -Force | Out-Null
}

# Crear .gitignore para C#
$gitignore = @"
# Build results
[Dd]ebug/
[Dd]ebugPublic/
[Rr]elease/
[Rr]eleases/
x64/
x86/
[Ww][Ii][Nn]32/
[Aa][Rr][Mm]/
[Aa][Rr][Mm]64/
bld/
[Bb]in/
[Oo]bj/
[Ll]og/
[Ll]ogs/

# Visual Studio cache/options directory
.vs/

# User-specific files
*.rsuser
*.suo
*.user
*.userosscache
*.sln.docstates

# Rider
.idea/
*.sln.iml

# Visual Studio Code
.vscode/

# OS
.DS_Store
Thumbs.db
"@

$gitignore | Out-File -FilePath ".gitignore" -Encoding UTF8

# Crear README.md inicial
$readme = @"
# C# Ejercicios

Repositorio para almacenar ejercicios de C# organizados por temas y conceptos.

## Estructura del Proyecto

- **01-Conceptos-Basicos**: Variables, tipos de datos, operadores y control de flujo
- **02-Programacion-Orientada-Objetos**: Clases, herencia, polimorfismo y encapsulación
- **03-Estructuras-Datos**: Arrays, listas, diccionarios y estructuras avanzadas
- **04-LINQ-y-Colecciones**: Consultas LINQ y trabajo con colecciones
- **05-Manejo-Excepciones**: Manejo de errores y excepciones
- **06-Async-Await**: Programación asincrónica
- **07-Proyectos-Integrales**: Proyectos completos que integran varios conceptos

## Cómo usar este repositorio

1. Clona el repositorio: `git clone <tu-url>`
2. Navega a la carpeta del ejercicio específico
3. Crea subcarpetas con el formato: `Ejercicio01_Nombre`, `Ejercicio02_Nombre`, etc.
4. Realiza tus cambios y haz commit con mensajes descriptivos

## Instrucciones de Git

Para subir tus cambios:

\`\`\`
git add .
git commit -m "Descripción de los cambios"
git push origin main
\`\`\`

---
Organiza y documenta tus ejercicios conforme avances en tu aprendizaje de C#.
"@

$readme | Out-File -FilePath "README.md" -Encoding UTF8

# Inicializar Git
git init
git config user.name "Tu Nombre"
git config user.email "tu@email.com"

Write-Host "✓ Estructura creada exitosamente en: $(Get-Location)" -ForegroundColor Green
Write-Host "✓ Archivos: .gitignore y README.md generados" -ForegroundColor Green
Write-Host ""
Write-Host "Próximos pasos:" -ForegroundColor Yellow
Write-Host "1. Ve a GitHub y crea un repositorio llamado 'CSharp-Ejercicios'" -ForegroundColor Cyan
Write-Host "2. Ejecuta estos comandos:" -ForegroundColor Cyan
Write-Host "   git remote add origin https://github.com/TuUsuario/CSharp-Ejercicios.git" -ForegroundColor Cyan
Write-Host "   git branch -M main" -ForegroundColor Cyan
Write-Host "   git add ." -ForegroundColor Cyan
Write-Host "   git commit -m 'Estructura inicial de ejercicios C#'" -ForegroundColor Cyan
Write-Host "   git push -u origin main" -ForegroundColor Cyan
