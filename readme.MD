# Trabajo practico 1

## ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
De las relaciones entre las clases dadas podemos distinguir lo siguiente:
- "El Cliente es parte del Pedido" por lo tanto la relacion entre estas  clases es de ***composición**
- "Los Cadetes tienen uno o mas Pedidos" por lo que la relacion entre estas clases se da a través de la **agregación**
- "La Cadeteria tiene uno o mas Cadetes" debido a esta afirmación podemos distinguir que, los cadetes pueden seguir existiendo a pesar de que no haya cadeteria, por lo que la relacion entre estas clases viene dada por **agregación**

## ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?

Para la clase Cadeteria lo métodos a agregar pueden ser:
-   AltaCadete(), BajaCadete(), con añadir un campo para la recaudacion diaria podríamos agregar RecaudacionDiaria()
Para la clase Cadete los métodos a agregar pueden ser:
-   MostrarPedidos(), MostrarID(), MostrarDatos(), EntregarPedido(),     

## Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.

Mencionaremos los campos que seran publicos y el resto seran privados:
- clase: **Cliente**
    todos los campos serán públicos
- clase: **Pedidos**
    todos los campos serán públicos menos el campo "Nro"
- clase:**Cadete**
    publicos serán: todos menos el campo "Direccion"
- clase **Cadeteria**
    publicos todos menos el campo "ListadoCadetes"

## ¿Cómo diseñaría los constructores de cada una de las clases?

Los constructores de las clases pueden ser (sujetos a cambios a la hora de implementar):
**Cliente**:  


