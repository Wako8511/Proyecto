## Cómo probar la API con Postman

1. Abrir Postman.
2. Crear una nueva solicitud HTTP.
3. Seleccionar el método HTTP correspondiente (GET, POST, PUT o DELETE).
4. Usar la URL base:
   https://localhost:7160/api/tareas
5. Enviar las solicitudes según el endpoint que se desee probar.

Crear (https://localhost:7160/api/tareas)
{
    "id": , 
    "title": "",
    "description": "",
    "iscompleted": true
}

VER (https://localhost:7160/api/tareas)

Editar (https://localhost:7160/api/tareas/"ID")
{
  "title": "",
  "description": ""

Cambiar Estado (https://localhost:7160/api/tareas/"ID"/completar)

Eliminar (https://localhost:7160/api/tareas/"ID")