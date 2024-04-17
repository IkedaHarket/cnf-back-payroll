# Proceso de Contribución `Backend.PortalPrivado.API`

Para contribuir en `Backend.PortalPrivado.API`, se debe seguir los siguientes pasos:

1. Obtener última versión de repositorio, **branch develop**
2. Crear branch local con la siguiente nomenclatura:

      * **feature**: `git checkout -b feature-codigo-historia-usuario_caracteristica`
         * Ejemplo: `git checkout -b feature-zen76_creacion_tabla_usuario`
  
3. Realizar los cmabios respectivos y generar commit: `git commit`
4. El mensaje del commit, debe tener la siguinte estructura:

      * `<Titulo>`
      * `- <descripción de modificación n°1>`
      * `- <descripción de modificación n°2>`
      * Ejemplo:
  
        ``` lenguaje_especificacion

            Componente Usuario

            - Agregar contenido html en componente tabla.
            - Integración API Clientes.  

        ```

5. Subir cambios hacía rama original `git push origin <nombre_proyecto/localizacion>`
6. Crear merge request para lider técnico del proyecto.